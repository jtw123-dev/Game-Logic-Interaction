using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector3 _pos; 
    private float distance;

    // Update is called once per frame
    void Update()
    {
        if (distance > 1)
        {
            Vector3 direction = _pos - transform.position;
            direction.Normalize();
            transform.Translate(direction * 2 *Time.deltaTime);     
        }
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hitInfo;

           if (Physics.Raycast(rayOrigin,out hitInfo))
            {
                if (hitInfo.collider.tag=="Floor")
                {
                    _pos = hitInfo.point;
                    
                    distance = Vector3.Distance(_pos, transform.position);
                }
            }
        }
        //if left click
        //send out ray
        //if hit floor
        //send player there

        //move towards target 
        //code logic
    }
}
