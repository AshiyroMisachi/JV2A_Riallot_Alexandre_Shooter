using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;
    public int damage;
    public bool createByEnnemy;

    public MovementAndShoot player;

    public GameObject bonusSpeed;
    public GameObject bonusTirRate;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MovementAndShoot>();

        if (createByEnnemy)
        {
            monRigidBody.velocity = Vector3.down * speed;
        }
        else
        {
            monRigidBody.velocity = Vector3.up * speed;
        }
    }

    void Update()
    {
        if (transform.position.y < -7 || transform.position.y > 7)
        {
            Destroy(gameObject);
        }
    }

    //Collision on Ennemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ennemy ennemy = collision.gameObject.GetComponent<Ennemy>();
        if (ennemy != null)
        {
            //Clear Object
            Destroy(gameObject);

            //Lose Hp Ennemy
            ennemy.health -= damage;
            if (ennemy.health <= 0)
            {
                Destroy(collision.gameObject);
                if (ennemy.type == EnnemiesType.Mother_Ship)
                {
                    ennemy.management.motherShipAlive = false;
                }
                ennemy.management.numberEnnemy -= 1;
                //Player Score
                player.score += ennemy.giveScore;
                player.uiScore.text = "Score: " + player.score;

                //Bonus Drop
                int getBonus = Random.Range(0, 4);
                if (getBonus == 0)
                {
                    //Speed Bonus
                    Instantiate(bonusSpeed, collision.transform.position, Quaternion.Euler(0, 0, 90));
                }
                else if (getBonus == 1)
                {
                    //Tir Rate Bonus
                    Instantiate(bonusTirRate, collision.transform.position, Quaternion.Euler(0, 0, 90));
                }
            }
        }
    }

    //Colision on Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovementAndShoot isPlayer = collision.gameObject.GetComponent<MovementAndShoot>();
        if (isPlayer != null && createByEnnemy)
        {
            //Clear Object
            Destroy(gameObject);

            //Lose Hp Player
            player.health -= damage;
            player.uiHealth.text = "Health: " + player.health;
            if (player.health <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}