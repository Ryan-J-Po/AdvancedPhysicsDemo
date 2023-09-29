using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBehaviour : MonoBehaviour
{

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _followSpeed;


    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(_target.position.x, _target.position.y, -11f);
        transform.position = Vector3.Slerp(transform.position, newPosition, _followSpeed*Time.deltaTime);
    }
}
