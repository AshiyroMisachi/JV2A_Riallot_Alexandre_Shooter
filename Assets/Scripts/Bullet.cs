using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;

    public GameObject bonusSpeed;
    public GameObject bonusTirRate;
    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
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
