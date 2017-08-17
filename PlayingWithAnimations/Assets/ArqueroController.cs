using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArqueroController : MonoBehaviour {

    private bool Izquierda = false;
    private bool Derecha = false;

    Animator anim;

    // Use this for initialization
    void Start () {
        anim = transform.GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {

        var h = Input.GetAxis("Horizontal");

        anim.SetFloat("Direccion", h);


        if (Input.GetKeyDown(KeyCode.A))
        {
            Izquierda = true;
            Derecha = !Izquierda;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Derecha = true;
            Izquierda = !Derecha;

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            
            if (Izquierda)
                anim.SetTrigger("Izquierda");
            if (Derecha)
                anim.SetTrigger("Derecha");

            anim.SetTrigger("Abajo");

            transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 50f);
        }

    }
}
