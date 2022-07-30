using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSphere : MonoBehaviour
{
    [SerializeField] private GameObject _sphere;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hitData;
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(rayOrigin, out hitData))
            {
                Vector3 hitPosition = hitData.point;
                Instantiate(_sphere, hitPosition, Quaternion.identity);
            }

        }
    }
}
