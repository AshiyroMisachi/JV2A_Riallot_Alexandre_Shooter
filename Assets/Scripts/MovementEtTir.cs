using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEtTir : MonoBehaviour
{
    public GameObject bullet;
    public Transform parent;
    public Transform limitL;
    public Transform limitR;

    public int score;
    public float speed;
    public float baseSpeed;
    public float tirRate;
    public float baseTirRate;
    public float timer;
    public float timerBonusSpeed;
    public float timerBonusTirRate;

    public bool canShoot = true;
    public PlayerTypeShoot typeShoot;

    // Start is called before the first frame update
    void Start()
    {
        baseSpeed = speed;
        baseTirRate = tirRate;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Timer();
    }

    public void Movement()
    {
        //Movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed;
        }
        //Shoot
        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            canShoot = false;
            Invoke("HableShoot", tirRate);
            if (typeShoot == PlayerTypeShoot.Basic)
            {
                //Single Bullet
                Instantiate(bullet, parent.position, parent.rotation);
            }
            else if (typeShoot == PlayerTypeShoot.Double)
            {
                //Double Bullet center
                Instantiate(bullet, parent.position + new Vector3(-0.2f,0f,0f), parent.rotation);
                Instantiate(bullet, parent.position + new Vector3(0.2f, 0f, 0f), parent.rotation);
            }
            else
            {
                //Four Bullet
                Instantiate(bullet, parent.position + new Vector3(-0.2f, 0f, 0f), parent.rotation);
                Instantiate(bullet, parent.position + new Vector3(0.2f, 0f, 0f), parent.rotation);

                Instantiate(bullet, parent.position + new Vector3(-0.5f, 0f, 0f), parent.rotation);
                Instantiate(bullet, parent.position + new Vector3(0.5f, 0f, 0f), parent.rotation);
            }
        }
        //Check Upgrade TypeShoot
        if (score >= 60)
        {
            typeShoot = PlayerTypeShoot.Spread;
        }
        else if (score >= 30)
        {
            typeShoot = PlayerTypeShoot.Double;
        }

        //Limit of the Map
        if (transform.position.x < limitL.position.x)
        {
            transform.position = new Vector3(limitR.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitR.position.x)
        {
            transform.position = new Vector3(limitL.position.x, transform.position.y, transform.position.z);
        }
    }
    public void HableShoot()
    {
        canShoot = true;
    }
    public void Timer()
    {
        timer += Time.deltaTime;
        if (timer >= timerBonusTirRate)
        {
            //Reset Base Tir Rate
            tirRate = baseTirRate;
        }
        if (timer >= timerBonusSpeed)
        {
            //Reset Base Speed
            speed = baseSpeed;
        }
    }
}