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
        Vector3 mouseScreenPos = Input.mousePosition;
        Ray ray = _mainCamera.ScreenPointToRay(mouseScreenPos);
        if (Physics.Raycast(ray, out RaycastHit hitData))
        {
            _mouseWorldPosition = hitData.point;
        }

        Debug.DrawRay(transform.position, _mouseWorldPosition);


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
