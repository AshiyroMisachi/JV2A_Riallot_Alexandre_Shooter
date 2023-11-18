using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : MonoBehaviour
{
    public int numberEnnemy;
    public int directionEnnemy = 1;

    public float timer;
    public float changeDirectionEnnemy;
    // Start is called before the first frame update
    void Start()
    {
        changeDirectionEnnemy = timer + 5f;
    }

    // Update is called once per frame
    void Update()
    {
        //Timer
        timer += Time.deltaTime;


        //Change Direction Ennemy
        if (timer > changeDirectionEnnemy)
        {
            changeDirectionEnnemy = timer + 10f;
            directionEnnemy *= -1;
        }
    }
}
