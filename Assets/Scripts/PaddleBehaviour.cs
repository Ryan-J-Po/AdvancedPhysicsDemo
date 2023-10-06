using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour
{
    private HingeJoint _hingeJoint;
    // Start is called before the first frame update
    void Awake()
    {
        _hingeJoint = GetComponent<HingeJoint>();
        _hingeJoint.useMotor = false;
    }

    // Update is called once per frame
    void Update()
    {
        _hingeJoint.useMotor = false;

        if (Input.GetMouseButton(1))
        {
            _hingeJoint.useMotor = true;
        }

    }
}
