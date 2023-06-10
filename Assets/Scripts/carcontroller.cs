using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class carcontroller : MonoBehaviour
{
    
    public float speed = 100;
    private float movement = 0f;
    public float rotation = 20f;
    public float rotate = 0f;
    public float fuel = 1 ; 
    public float fc = 0.0001f;
    public Rigidbody2D wheel1;
    public  Rigidbody2D wheel2;
    public Rigidbody2D car;
    public Transform camera;
    public UnityEngine.UI.Image image;   
    public AudioSource play;
    public float value = 0.5f;


    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {   

        movement = -Input.GetAxisRaw("Vertical") * speed ;
        rotate = -Input.GetAxisRaw("Horizontal") *rotation;
        image.fillAmount = fuel;
    }
    private void FixedUpdate() {
        if (fuel>0)
        {
        //     if (movement==0f)
        // {
        //     wheel1.useMotor = false;
        //     wheel2.useMotor = false;
        // }
        // else
        // {
        //     wheel1.useMotor = true;
        //     wheel2.useMotor = true ; 
        //     JointMotor2D motor = new JointMotor2D {motorSpeed = movement  , maxMotorTorque = 10000};
        //     wheel1.motor = motor;
        //     wheel2.motor = motor;

        // }
        
        if (Mathf.Abs(wheel1.angularVelocity)<5000 | Mathf.Abs(wheel2.angularVelocity)<5000 ){
            wheel1.AddTorque(movement * Time.fixedDeltaTime);
            wheel2.AddTorque(movement* Time.fixedDeltaTime);
            
        }
        // value = (float) (value * Mathf.Abs(wheel1.angularVelocity) *0.004);
        // play.volume = 0.4f;
        // play.Play();

        // else{
        //     wheel1.AddTorque(movement);
        //     wheel2.AddTorque(movement);
        // }
        
        car.AddTorque(rotate * Time.fixedDeltaTime);
        }
        // else{
        //     wheel1.useMotor = false;
        //     wheel2.useMotor = false;
        // }
        
        Vector3 position = car.position;
        position.z = -15;
        camera.position = position;
        fuel = fuel - fc * Mathf.Abs(movement) *Time.fixedDeltaTime;
        // Debug.Log();

    }
}
