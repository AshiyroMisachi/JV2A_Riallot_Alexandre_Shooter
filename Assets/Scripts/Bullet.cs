using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;

    public MovementEtTir player;

    public GameObject bonusSpeed;
    public GameObject bonusTirRate;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MovementEtTir>();
        monRigidBody.velocity = Vector3.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Clear Object
        Destroy(collision.gameObject);
        Destroy(gameObject);

        //Player Score
        player.score += 1;
        Debug.Log(player.score);

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
