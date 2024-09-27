using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GolfinhoController : MonoBehaviour
{

    public static float velocidade;
    public static float velocidadeDescida;
    public GameObject tiroDestruir;
    public GameObject tiroLiberarCamarada;
    public static bool disparar;
    private float temporizadorAtqEspecial = 0;
    public int tempoRecargaSpecial = 30;
    private bool specialReady = true;

    // Start is called before the first frame update
    void Start()
    {
        velocidade = 0.05f;
        velocidadeDescida = 0.03f;
        ComportamentoTiro.velocidadeTiro = 0.05f;
        disparar = true;
        SpawnInimigos si = GameObject.Find("SpawnInimigos").GetComponent<SpawnInimigos>();
        SpawnInimigos.spawnRate = 1.3f;
        ComportamentoInimigo.velocidadeInimigo = 0.04f;
        ComportamentoInimigo.score = 0;
    }

    // Update is called once per frame
    void Update()
    {

        float currentXposition = this.transform.position.x;
        float currentYposition = this.transform.position.y;
        float currentZposition = this.transform.position.z;
        TextMeshProUGUI special = GameObject.Find("SpecialText").GetComponent<TextMeshProUGUI>();
        temporizadorAtqEspecial += Time.deltaTime;

        if(temporizadorAtqEspecial > tempoRecargaSpecial)
        {
            special.text = "MultiLiberateShot: Active (Space)";
            specialReady = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(new Vector3(0, velocidade, 0));
        }
        else
        {
            this.transform.Translate(new Vector3(0, velocidadeDescida * -1, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(new Vector3(velocidade * -1, 0, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(new Vector3(velocidade, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && disparar)
        {
            GameObject tiroDestruirCriado = Instantiate(tiroDestruir, new Vector3(currentXposition, currentYposition, currentZposition), Quaternion.identity);
            tiroDestruirCriado.transform.rotation = Quaternion.Euler(90, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && disparar)
        {
            GameObject tiroLiberarCriado = Instantiate(tiroLiberarCamarada, new Vector3(currentXposition, currentYposition, currentZposition), Quaternion.identity);
            tiroLiberarCriado.transform.rotation = Quaternion.Euler(90, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && specialReady)
        {
            special.text = "MultiLiberateShot: Not Ready (Space)";
            for(int i = 0; i < 30; i++)
            {
                GameObject tiroLiberarCriado = Instantiate(tiroLiberarCamarada, new Vector3(Random.Range(-10,10), Random.Range(0, 10), Random.Range(0, 2)), Quaternion.identity);
                tiroLiberarCriado.transform.rotation = Quaternion.Euler(90, 0, 0);
            }

            specialReady = false;
            temporizadorAtqEspecial = 0;
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

        velocidade = 0;
        velocidadeDescida = 0;
        ComportamentoTiro.velocidadeTiro = 0;
        disparar = false;

        SpawnInimigos.spawnRate = 999;
        ComportamentoInimigo.velocidadeInimigo = 0;
    }

    public static void win()
    {
        GameObject button = GameObject.Find("MainMenuButton");
        DeathScreenScript.setMainMenuButton();
        TextMeshProUGUI gameOver = GameObject.Find("GameOverText").GetComponent<TextMeshProUGUI>();
        gameOver.text = "YOU SAVED YOUR DOLPHIN WIFE";

        velocidade = 0;
        velocidadeDescida = 0;

        SpawnInimigos.spawnRate = 999;
        ComportamentoInimigo.velocidadeInimigo = 0;
    }
}
