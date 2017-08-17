using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckCollision : MonoBehaviour {

    public Transform pelota;
    public Transform direccion;

    public float fuerza;

    private void OnTriggerEnter(Collider other)
    {
        //if (!other.name.Contains("Plane"))
        //{
        //    Debug.LogFormat("Collider: {0}", other.name);

        //    //pelota.GetComponent<Rigidbody>().AddForce((pelota.position - transform.position) * fuerza);

        //    pelota.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * fuerza);
        //}
    }

    private void Update()
    {
        //Ray ray = new Ray(transform.position + Vector3.up, -Vector3.up);
        //RaycastHit hitInfo = new RaycastHit();

        //Debug.DrawRay(transform.position, pelota.position - transform.position, Color.red);

        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    pelota.GetComponent<Rigidbody>().AddForce((transform.position - pelota.position) * fuerza);
        //}
    }


}
