using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public float speed;
    public Rigidbody2D body;
    public MovementAndShoot player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MovementAndShoot>();
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector3.down * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovementAndShoot isPlayer = collision.GetComponent<MovementAndShoot>();
        if (isPlayer != null)
        {
            if (tag == "Bonus_Speed")
            {
                //Gain Speed bonus
                if (player.timerBonusSpeed < player.timer)
                {
                    player.speed *= 2;
                }
                player.timerBonusSpeed = player.timer + 5f;
            }
            else if (tag == "Bonus_TirRate")
            {
                //Gain Tir rate bonus
                if (player.timerBonusTirRate < player.timer)
                {
                    player.tirRate /= 2;
                }
                player.timerBonusTirRate = player.timer + 5f;
            }
            Destroy(gameObject);
        }
    }
}
