using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcontroller : MonoBehaviour
{
    public float speed = 1500;
    private float movement = 0f;
    public WheelJoint2D wheel1;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Vertical") * speed;
    }
    private void FixedUpdate() {
        if (movement==0f)
        {
            wheel1.useMotor = false;
        }
        else
        {
            wheel1.useMotor = true;
            JointMotor2D motor = new JointMotor2D {motorSpeed = movement , maxMotorTorque = 10000};
            wheel1.motor = motor;
        }
    }
}
