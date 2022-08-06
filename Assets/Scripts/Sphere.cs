using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private Rigidbody _body;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
        if (_body ==null)
        {
            Debug.Log("Rigidbody is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position,Vector3.down,1f))
        {
            Debug.Log("Hit something");
            //_body.isKinematic = true;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, Vector3.down * 1f);
        Debug.DrawLine(transform.position, Vector3.down * 2f);
    }
}
