using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public float speed;
    public int health;
    public int giveScore;
    public bool canShoot;
    public float tirRate;
    public EnnemiesType type;

    public Rigidbody2D body;
    public GameObject bullet;

    public Management management;
    // Start is called before the first frame update
    void Start()
    {
        management = FindObjectOfType<Management>();
        body = GetComponent<Rigidbody2D>();

        management.numberEnnemy += 1;
        if (type == EnnemiesType.Mother_Ship)
        {
            management.motherShipAlive = true;
            Invoke("HableShoot", 2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement();

        //Shoot
        if (canShoot)
        {
            canShoot = false;
            Invoke("HableShoot", tirRate);

            if (type == EnnemiesType.Invader_Shoot)
            {
                GameObject createBullet = Instantiate(bullet, transform.position, transform.rotation);
                createBullet.GetComponent<Bullet>().createByEnnemy = true;
            }

            else if (type == EnnemiesType.Mother_Ship)
            {
                Vector3 spawnPos = transform.position + new Vector3(-1.5f, 0f, 0f);
                for (int i = 0; i < 4; i++)
                {
                    GameObject createBullet = Instantiate(bullet, spawnPos, transform.rotation);
                    createBullet.GetComponent<Bullet>().createByEnnemy = true;
                    spawnPos += new Vector3(1f, 0f, 0f);
                    if (i == 3)
                    {
                        spawnPos = transform.position + new Vector3(-2f, 0f, 0f);
                    }
                }
            }
        }

        //Clear if Mother Ship die
        if (!management.motherShipAlive)
        {
            Destroy(gameObject);
            management.numberEnnemy -= 1;
        }
    }

    public void movement()
    {
        //Movement of ennemies
        body.velocity = (Vector3.right * speed) * management.directionEnnemy;
    }

    public void HableShoot()
    {
        canShoot = true;
    }
}
