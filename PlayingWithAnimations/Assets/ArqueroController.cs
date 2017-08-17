using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArqueroController : MonoBehaviour {

    public float GetFloatCollider;

    private bool Izquierda = false;
    private bool Derecha = false;
    private bool Arriba = false;
    private bool Medio = false;
    public Transform StartPosition;

    Animator anim;
    private AnimatorStateInfo currentBaseState;
    static int abajoDerechaState = Animator.StringToHash("Base Layer.AbajoDerecha");
    static int abajoIzquierdaState = Animator.StringToHash("Base Layer.AbajoIzquierda");
    static int ArribaDerechaState = Animator.StringToHash("Base Layer.ArribaDerecha");
    static int ArribaIzquierdaState = Animator.StringToHash("Base Layer.ArribaIzquierda");
    static int IdleState = Animator.StringToHash("Base Layer.Idle");

    CapsuleCollider col;

    public Text text;

       
    public bool bot;

    // Use this for initialization
    void Start () {
        anim = transform.GetComponent<Animator>();
        col = transform.GetComponent<CapsuleCollider>();
        bot = true;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        var crono = Time.time;
        text.text = System.Math.Ceiling(crono).ToString();



        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);


        GetFloatCollider = anim.GetFloat("RotateCollider");

        if (currentBaseState.fullPathHash == abajoDerechaState || currentBaseState.fullPathHash == abajoIzquierdaState)
        {
            if (GetFloatCollider < 0)
            {
                col.direction = 0;
                col.center = new Vector3(0, 0.25f, 0);
            }
            else
            {
                col.direction = 1;
                col.center = new Vector3(0, 1f, 0);
            }
        }

        if (currentBaseState.fullPathHash == ArribaDerechaState || currentBaseState.fullPathHash == ArribaIzquierdaState)
        {
            if (GetFloatCollider < 0)
            {
                col.direction = 0;
                col.center = new Vector3(0, 1f, 0);

                if (Arriba && Input.GetKey(KeyCode.V))
                {
                    if (Derecha)
                    {
                        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.left + Vector3.up * 25f, ForceMode.Impulse);
                    }
                    else
                    {
                        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.right + Vector3.up * 25f, ForceMode.Impulse);
                    }
                }

            }
            else
            {
                col.direction = 1;
                col.center = new Vector3(0, 1f, 0);
            }
        }

        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        //if (text.text == "5")
        //{
        //    h = Random.Range(-1, 1);
        //    v = Random.Range(-1, 1);
        //}
        

        anim.SetFloat("Direccion", h);


        if (h < 0)
        {
            Izquierda = true;
            Derecha = !Izquierda;
        }

        if (h > 0)
        {
            Derecha = true;
            Izquierda = !Derecha;

        }

        if(v > 0)
        {
            Arriba = true;
            Medio = false;
        }

        if (v < 0)
        {
            Medio = false;
            Arriba = false;
        }

        if(v == 0)
        {
            Medio = true;
        }




        if (Input.GetKeyDown(KeyCode.W))
        {          

            if (Izquierda)
                anim.SetTrigger("Izquierda");
            if (Derecha)
                anim.SetTrigger("Derecha");

            if (!Arriba && !Medio)
            {
                anim.SetTrigger("Abajo");
            }
            else
            {
                anim.SetTrigger("Arriba");
            }            
        }



        if (Input.GetKey(KeyCode.V))
        {

            if (!Arriba && !Medio)
            {
                if (Derecha)
                {
                    gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.left * 100f, ForceMode.Impulse);
                }
                else
                {
                    gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.right * 100f, ForceMode.Impulse);
                }
            }
            else if (Arriba)
            {
                //if (Derecha)
                //{
                //    gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.left+Vector3.up * 25f, ForceMode.Impulse);
                //}
                //else
                //{
                //    gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.right + Vector3.up * 25f, ForceMode.Impulse);
                //}
            }
            else
            {
                if (Derecha)
                {
                    gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.left * 100f, ForceMode.Impulse);
                }
                else
                {
                    gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.right * 100f, ForceMode.Impulse);
                }
            }  
            
            
        }

        
    }

    void Update()
    {

    }
}
