using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigos : MonoBehaviour
{
    public GameObject naveInimiga;
    public GameObject golfinhoInimigo;
    public GameObject oAmorDaMinhaVida;
    public float temporizador = 0;
    public static float spawnRate;
    public float probabilidadeSpawnGolfinhoRosa = 10;

    public float limXsupSpawn = 10f;
    public float limXinfSpawn = -10f;
    public float limYsupSpawn = 10f;
    public float limYinfSpawn = 2;
    public float limZsupSpawn = 10f;
    public float limZinfSpawn = -10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        temporizador += Time.deltaTime;

        if (temporizador > spawnRate)
        {
            float randX = Random.Range(limXinfSpawn, limXsupSpawn);
            float randY = Random.Range(limYinfSpawn, limYsupSpawn);
            float randZ = Random.Range(limZinfSpawn, limZsupSpawn);

            if (Random.Range(0, 2) == 1)
            {
                GameObject nave = Instantiate(naveInimiga, new Vector3(randX, randY, randZ), Quaternion.identity);
                nave.transform.rotation = Quaternion.Euler(0, -90, 0);

            }
            else
            {

                if(Random.Range(0,100) < probabilidadeSpawnGolfinhoRosa)
                {

                } else
                {
                    GameObject golfinho = Instantiate(golfinhoInimigo, new Vector3(randX, randY, randZ), Quaternion.identity);
                    golfinho.transform.rotation = Quaternion.Euler(0, 180, 0);
                }

            }

            temporizador = 0;
        }
    }
}
