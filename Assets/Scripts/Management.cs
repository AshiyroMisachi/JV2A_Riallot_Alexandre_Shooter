using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Management : MonoBehaviour
{
    public int numberEnnemy;
    public int directionEnnemy = 1;
    public bool motherShipAlive;
    public int countWave;
    public TextMeshProUGUI uiWave;

    public GameObject motherShip;
    public GameObject invader;
    public GameObject invaderShoot;

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
        
        //Bug fix
        if (numberEnnemy <= 0)
        {
            numberEnnemy = 0;
        }

        //Respawn Wave
        if (!motherShipAlive && numberEnnemy == 0)
        {
            motherShipAlive = true;
            countWave++;
            uiWave.text = "Wave: " + countWave;
            Invoke("callSpawnLine", 2f);
        }
        
    }

    public void callSpawnLine()
    {
        //Spawn MotherShip
        GameObject newMotherShip = Instantiate(motherShip, new Vector3(0f, 4f, 0f), transform.rotation);
        newMotherShip.GetComponent<Ennemy>().health += countWave * 10;

        //Spawn other Invader
        spawnLine(new Vector3(-5f, 0f, 0f), 10f, 8f);
        spawnLine(new Vector3(-6.5f, 1.25f, 0f), 13f, 10f);
        spawnLine(new Vector3(-8f, 2.4f, 0f), 16f, 12f);
    }
    public void spawnLine(Vector3 pos, float distancePos, float numberSpawn)
    {
        for (int i = 0; i < numberSpawn; i++)
        {
            int random = Random.Range(0, 3);
            GameObject ennemy;
            if (random == 0)
            {
                //Spawn InvaderShoot
                ennemy = Instantiate(invaderShoot, pos, Quaternion.identity);
            }
            else
            {
                //Spawn Invader
                ennemy = Instantiate(invader, pos, Quaternion.identity);
            }
            pos += new Vector3((distancePos / numberSpawn), 0f, 0f);
            ennemy.GetComponent<Ennemy>().health += countWave * 2;
        }
    }
}
