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

    public float Impulso;

    public Vector3 ShootPosition;
    public Vector3 LimitesStartPosition;
    public Transform Limites;

    // Use this for initialization
    void Start () {

        spawn = transform.position;
        ShootPosition = new Vector3(0, 0, 0);
        LimitesStartPosition = Limites.position;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.DrawRay(transform.position, arribaDerecha.position - transform.position, Color.red);

        Debug.DrawRay(transform.position, Limites.position - transform.position, Color.black);

        if (Input.GetAxis("HJ") > 0)
        {
            ejeX.value += 2;
            ShootPosition.x += 0.1f;
        }
        if (Input.GetAxis("HJ") < 0)
        {
            ejeX.value -= 2;
            ShootPosition.x -= 0.1f;

        }
        if (Input.GetAxis("VJ") < 0)
        {
            ejeY.value += 2;
            ShootPosition.y -= 0.05f;
        }

        if (Input.GetAxis("VJ") > 0)
        {
            ejeY.value -= 2;
            ShootPosition.y += 0.05f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = spawn;
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ejeX.value = 0;
            ejeY.value = 0;
            ShootPosition = Vector3.zero;
            Limites.position = LimitesStartPosition;
        }

        if (Input.GetButtonDown("XJ"))
        {
            Limites.position += ShootPosition;

            transform.GetComponent<Rigidbody>().AddForce((Limites.position - transform.position) * Impulso, ForceMode.Impulse);

            //#region Arriba...
            //if (ejeX.value > 80 && ejeY.value < -80)
            //{
            //    transform.GetComponent<Rigidbody>().AddForce((arribaDerecha.position - transform.position) * Impulso,ForceMode.Impulse);
            //}

            //if (ejeX.value <= -80 && ejeY.value <= -80)
            //{
            //    transform.GetComponent<Rigidbody>().AddForce((arribaIzquierda.position - transform.position) * Impulso, ForceMode.Impulse);
            //}

            //if (ejeX.value == 0 && ejeY.value < -80)
            //{
            //    transform.GetComponent<Rigidbody>().AddForce((arribaMedio.position - transform.position) * Impulso, ForceMode.Impulse);
            //}
            //#endregion

            //#region Medio...

            //if ((ejeX.value < 20 && ejeX.value > -20) && (ejeY.value < 20 && ejeY.value > -20))
            //{
            //    transform.GetComponent<Rigidbody>().AddForce((MedioMedio.position - transform.position) * Impulso, ForceMode.Impulse);
            //}

            //if ((ejeX.value > 20) && (ejeY.value < 20 && ejeY.value > -20))
            //{
            //    transform.GetComponent<Rigidbody>().AddForce((MedioDerecha.position - transform.position) * Impulso, ForceMode.Impulse);
            //}

            //if ((ejeX.value < -20) && (ejeY.value < 20 && ejeY.value > -20))
            //{
            //    transform.GetComponent<Rigidbody>().AddForce((MedioIzquierda.position - transform.position) * Impulso, ForceMode.Impulse);
            //}

            //#endregion


            //#region Abajo...
            //if (ejeX.value > 80 && ejeY.value > 20)
            //{
            //    transform.GetComponent<Rigidbody>().AddForce((AbajoDerecha.position - transform.position) * Impulso, ForceMode.Impulse);
            //}

            //if (ejeX.value < -80 && ejeY.value > 20)
            //{
            //    transform.GetComponent<Rigidbody>().AddForce((AbajoIzquierda.position - transform.position) * Impulso, ForceMode.Impulse);
            //}

            //if (ejeX.value == 0 && ejeY.value > 20)
            //{
            //    transform.GetComponent<Rigidbody>().AddForce((AbajoMedio.position - transform.position) * Impulso, ForceMode.Impulse);
            //}
            //#endregion
        }
    }
}
