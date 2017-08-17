using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements

[ExecuteInEditMode]
public class Math : MonoBehaviour {

    public Transform arribaDerecha;
    public Transform arribaIzquierda;
    public Transform arribaMedio;
    public Transform MedioDerecha;
    public Transform MedioIzquierda;
    public Transform MedioMedio;
    public Transform AbajoDerecha;
    public Transform AbajoIzquierda;
    public Transform AbajoMedio;

    public Slider ejeX;
    public Slider ejeY;

    public Vector3 spawn;

    // Use this for initialization
    void Start () {

        spawn = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
        //Debug.DrawRay(transform.position, arribaDerecha.position - transform.position, Color.red);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            ejeX.value += 2;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ejeX.value -= 2;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            ejeY.value += 2;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ejeY.value -= 2;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = spawn;
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ejeX.value = 0;
            ejeY.value = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            #region Arriba...
            if(ejeX.value > 80 && ejeY.value < -80)
            {
                transform.GetComponent<Rigidbody>().AddForce((arribaDerecha.position - transform.position) * 100F);
            }

            if (ejeX.value < -80 && ejeY.value < -80)
            {
                transform.GetComponent<Rigidbody>().AddForce((arribaIzquierda.position - transform.position) * 100F);
            }

            if (ejeX.value == 0 && ejeY.value < -80)
            {
                transform.GetComponent<Rigidbody>().AddForce((arribaMedio.position - transform.position) * 100F);
            }
            #endregion

            #region Medio...

            if ((ejeX.value < 20 && ejeX.value > -20) && (ejeY.value < 20 && ejeY.value > -20))
            {
                transform.GetComponent<Rigidbody>().AddForce((MedioMedio.position - transform.position) * 100F);
            }

            if ((ejeX.value > 20) && (ejeY.value < 20 && ejeY.value > -20))
            {
                transform.GetComponent<Rigidbody>().AddForce((MedioDerecha.position - transform.position) * 100F);
            }

            if ((ejeX.value < -20) && (ejeY.value < 20 && ejeY.value > -20))
            {
                transform.GetComponent<Rigidbody>().AddForce((MedioIzquierda.position - transform.position) * 100F);
            }

            #endregion


            #region Abajo...
            if (ejeX.value > 80 && ejeY.value > 20)
            {
                transform.GetComponent<Rigidbody>().AddForce((AbajoDerecha.position - transform.position) * 100F);
            }

            if (ejeX.value < -80 && ejeY.value > 20)
            {
                transform.GetComponent<Rigidbody>().AddForce((AbajoIzquierda.position - transform.position) * 100F);
            }

            if (ejeX.value == 0 && ejeY.value > 20)
            {
                transform.GetComponent<Rigidbody>().AddForce((AbajoMedio.position - transform.position) * 100F);
            }
            #endregion
        }
    }
}
