using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPadBehaviour : MonoBehaviour
{
    [SerializeField]
    private int _speed;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ragdoll"))
        {
            other.gameObject.GetComponent<RigidBody>().AddForce(_speed * Vector3.up, ForceMode.Impulse);
        }
    }
}
