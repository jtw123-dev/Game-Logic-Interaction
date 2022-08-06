using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ShootEnemy : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo,Mathf.Infinity,1<<6))
            {
                hitInfo.collider.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }
}
