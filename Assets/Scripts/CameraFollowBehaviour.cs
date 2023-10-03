using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBehaviour : MonoBehaviour
{

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _followSpeed;

    [SerializeField]
    private float _xAxis;
    [SerializeField]
    private float _yAxis;
    [SerializeField]
    private float _zAxis;

    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(_target.position.x + _xAxis, _target.position.y + _yAxis, _zAxis);
        transform.position = Vector3.Slerp(transform.position, newPosition, _followSpeed * Time.deltaTime);
    }

}
