using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(rayOrigin,out hit))
            {
                if (hit.transform.tag == "Cube")
                {
                    hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
                }
                else if (hit.transform.tag == "Capsule")
                {
                    hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
                }
            }
        }
    }
}
