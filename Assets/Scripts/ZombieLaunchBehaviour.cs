using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLaunchBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _forceScale = 1;

    private Rigidbody[] _rigidBodies;
    private Animator _animator;
    private Camera _mainCamera;
    private Vector3 _mouseWorldPosition;
    private bool _forceAdded = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBodies = GetComponentsInChildren<Rigidbody>();
        _animator = GetComponent<Animator>();
        _mainCamera = Camera.main;
        SetRagdollEnabled(false);
    }

    public void SetRagdollEnabled(bool enabled)
    {
        foreach (Rigidbody rigidBody in _rigidBodies)
        {
            rigidBody.isKinematic = !enabled;
        }
    }

    public void AddForceToRigidBodies(Vector3 force)
    {
        foreach (Rigidbody rigidBody in _rigidBodies)
        {
            rigidBody.AddForce(force, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_forceAdded)
        {
            return;
        }
        Vector3 mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        _mouseWorldPosition = _mainCamera.ScreenToWorldPoint(mouseScreenPos);
        _mouseWorldPosition.z = 0;

        if (Input.GetMouseButtonDown(0))
        {
            _forceAdded = true;
            Vector3 zombieToMouse = _mouseWorldPosition - transform.position;
            _animator.enabled = false;
            SetRagdollEnabled(true);
            AddForceToRigidBodies(zombieToMouse * _forceScale);
        }

    }
}
