using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GolfinhoController : MonoBehaviour
{

    public float velocidade = 0.02f;
    public GameObject tiroDestruir;
    public GameObject tiroLiberarCamarada;

    // Start is called before the first frame update
    void Start()
    {
        velocidade = 0.05f;

        SpawnInimigos si = GameObject.Find("SpawnInimigos").GetComponent<SpawnInimigos>();
        si.spawnRate = 2;
        ComportamentoInimigo.velocidadeInimigo = 0;
    }

    // Update is called once per frame
    void Update()
    {

        float currentXposition = this.transform.position.x;
        float currentYposition = this.transform.position.y;
        float currentZposition = this.transform.position.z;

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(new Vector3(0, velocidade, 0));
        }
        else
        {
            this.transform.Translate(new Vector3(0, velocidade * -1, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(new Vector3(velocidade * -1, 0, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(new Vector3(velocidade, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject tiroDestruirCriado = Instantiate(tiroDestruir, new Vector3(currentXposition, currentYposition, currentZposition), Quaternion.identity);
            tiroDestruirCriado.transform.rotation = Quaternion.Euler(90, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject tiroLiberarCriado = Instantiate(tiroLiberarCamarada, new Vector3(currentXposition, currentYposition, currentZposition), Quaternion.identity);
            tiroLiberarCriado.transform.rotation = Quaternion.Euler(90, 0, 0);
        }

        if (this.transform.position.y < -20)
        {
            gameOver();
        }
    }

    public static void gameOver()
    {
        GameObject button = GameObject.Find("MainMenuButton");
        DeathScreenScript.setMainMenuButton();
        TextMeshProUGUI gameOver = GameObject.Find("GameOverText").GetComponent<TextMeshProUGUI>();
        gameOver.text = "DOLPHINE OVER";

        GolfinhoController gc = GameObject.Find("Golfinho").GetComponent<GolfinhoController>();
        gc.velocidade = 0;

        SpawnInimigos si = GameObject.Find("SpawnInimigos").GetComponent<SpawnInimigos>();
        si.spawnRate = 999;
        ComportamentoInimigo.velocidadeInimigo = 0;
    }

    public static void win()
    {
        GameObject button = GameObject.Find("MainMenuButton");
        DeathScreenScript.setMainMenuButton();
        TextMeshProUGUI gameOver = GameObject.Find("GameOverText").GetComponent<TextMeshProUGUI>();
        gameOver.text = "YOU SAVED YOUR DOLPHIN WIFE";

        GolfinhoController gc = GameObject.Find("Golfinho").GetComponent<GolfinhoController>();
        gc.velocidade = 0;

        SpawnInimigos si = GameObject.Find("SpawnInimigos").GetComponent<SpawnInimigos>();
        si.spawnRate = 999;
        ComportamentoInimigo.velocidadeInimigo = 0;
    }
}
