using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPadBehaviour : MonoBehaviour
{
    [SerializeField]
    private int _speed;

    [SerializeField]
    private Rigidbody _ragdollHip;

    private void OnCollisionEnter(Collision other)
    {
            Debug.Log("A collision has happened.");
            //other.gameObject.GetComponent<Rigidbody>().AddForce(_speed * Vector3.up, ForceMode.Impulse);
            _ragdollHip.AddForce(_speed * Vector3.up, ForceMode.Impulse);  
    }
}
