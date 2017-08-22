using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements

[ExecuteInEditMode]
public class Math : MonoBehaviour {

    public Slider ejeX;
    public Slider ejeY;
    public float sensitivityY = 0.01f;
    public float sensitivityX = 0.04f;

    public Vector3 spawnPosition;

    public float Impulso;

    public bool Shoot;
    public bool Restart;

    public Vector3 ShootPosition;
    public Vector3 ShootDirectionSpawnPosition;
    public Transform ShootDirection;

    private IEnumerator coroutine;

    public Text text;

    // Use this for initialization
    void Start () {

        spawnPosition = transform.position;
        ShootPosition = new Vector3(0, 0, 0);
        ShootDirectionSpawnPosition = ShootDirection.position;
        Shoot = false;
        Restart = false;
    }

    float count = 0f;

	// Update is called once per frame
	void Update () {

        var crono = Time.time;

        ShootPosition = Vector3.zero;

        if (Input.GetAxisRaw("HJ") == 1)
        {
            ejeX.value += 2;
            ShootPosition.x += sensitivityX;
            if (ShootPosition.x > 0)
                ShootDirection.position += ShootPosition;
            else
                ShootDirection.position -= ShootPosition;
        }

        if (Input.GetAxisRaw("HJ") == -1)
        {
            ejeX.value -= 2;
            ShootPosition.x -= sensitivityX;
            if(ShootPosition.x > 0)
                ShootDirection.position -= ShootPosition;
            else
                ShootDirection.position += ShootPosition;
        }
               

        if (Input.GetAxisRaw("VJ") == -1)
        {
            ejeY.value += 2;
            ShootPosition.y -= sensitivityY;
            if (ShootPosition.y > 0)
                ShootDirection.position -= ShootPosition;
            else
                ShootDirection.position += ShootPosition;
        }

        if (Input.GetAxisRaw("VJ") ==  1)
        {
            ejeY.value -= 2;
            ShootPosition.y += sensitivityY;
            if (ShootPosition.y > 0)
                ShootDirection.position += ShootPosition;
            else
                ShootDirection.position -= ShootPosition;
        }

        Debug.DrawRay(transform.position, ShootDirection.position - transform.position, Color.black);

        

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = spawnPosition;
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ejeX.value = 0;
            ejeY.value = 0;
            ShootPosition = Vector3.zero;
            ShootDirection.position = ShootDirectionSpawnPosition;
            Shoot = false;
            Restart = true;
        }

        if (Input.GetButtonDown("XJ") && !Shoot)
        {
            text.text = "Disparo!!!"; 
            Debug.Log("Entro!");
            Shoot = true;
            StartCoroutine(WaitAndShoot(0.3f));
                 
        }
    }

    private IEnumerator WaitAndShoot(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            StopAllCoroutines();
            //transform.GetComponent<Rigidbody>().AddForce((ShootDirection.position - transform.position) * Impulso, ForceMode.Impulse);
            Debug.Log("Impulso!");
            //transform.GetComponent<Rigidbody>().AddForce(ShootDirection.position, ForceMode.Impulse);
            ShootDirection.position.Normalize();
            transform.GetComponent<Rigidbody>().AddForce(ShootDirection.position, ForceMode.Impulse);
        }
    }
}
