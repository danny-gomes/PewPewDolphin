using System;
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
    public float probabilidadeSpawnGolfinhoRosa = 10; // probabilidade em 200, a 1 probabilidade = 0.5% de um golfinho ser rosa
    private static bool flagRosa = true;

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
            float randX = UnityEngine.Random.Range(limXinfSpawn, limXsupSpawn);
            float randY = UnityEngine.Random.Range(limYinfSpawn, limYsupSpawn);
            float randZ = UnityEngine.Random.Range(limZinfSpawn, limZsupSpawn);

            if (UnityEngine.Random.Range(0, 2) == 1)
            {
                GameObject nave = Instantiate(naveInimiga, new Vector3(randX, randY, randZ), Quaternion.identity);
                nave.transform.rotation = Quaternion.Euler(0, -90, 0);

            }
            else
            {

                if (UnityEngine.Random.Range(0, 1000) < probabilidadeSpawnGolfinhoRosa && flagRosa)
                {
                    GameObject golfinho = Instantiate(oAmorDaMinhaVida, new Vector3(randX, randY, randZ), Quaternion.identity);
                    golfinho.transform.rotation = Quaternion.Euler(0, 180, 0);
                    flagRosa = false;
                }
                else
                {
                    GameObject golfinho = Instantiate(golfinhoInimigo, new Vector3(randX, randY, randZ), Quaternion.identity);
                    golfinho.transform.rotation = Quaternion.Euler(0, 180, 0);
                }

            }

            temporizador = 0;
        }

        if(ComportamentoInimigo.score > 400)
        {
            spawnRate = 0.5f;
        } else if(ComportamentoInimigo.score > 250)
        {
            spawnRate = 0.8f;
        } else if(ComportamentoInimigo.score > 100)
        {
            spawnRate = 1.1f;
        }
    }
}
