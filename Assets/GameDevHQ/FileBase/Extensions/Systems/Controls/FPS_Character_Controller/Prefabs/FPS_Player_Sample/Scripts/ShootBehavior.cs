using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootBehavior : MonoBehaviour
{
    [SerializeField] GameObject _bulletHole;
    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 center = new Vector3(0.5f, 0.5f, 0);
            Ray rayOrigin = Camera.main.ViewportPointToRay(center);
            
            RaycastHit hitInfo;
           if (Physics.Raycast(rayOrigin,out hitInfo))
            {
                Instantiate(_bulletHole, hitInfo.point, Quaternion.FromToRotation(Vector3.forward,hitInfo.normal));
            }
        }
    }
}
