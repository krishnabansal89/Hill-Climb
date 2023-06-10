using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuelController : MonoBehaviour
{
    public carcontroller carcontroller;
    

    // Update is called once per frame
    private void  OnTriggerEnter2D(Collider2D collision) {
        carcontroller.fuel = 1;
        Destroy(gameObject);
    }
}
