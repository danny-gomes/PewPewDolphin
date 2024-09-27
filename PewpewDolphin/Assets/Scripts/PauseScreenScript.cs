using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseScreenScript : MonoBehaviour
{

    public GameObject pauseMenu;
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        ComportamentoInimigo.velocidadeInimigo = 0;
        GolfinhoController.velocidade = 0;
        GolfinhoController.velocidadeDescida = 0;
        GolfinhoController.disparar = false;
        ComportamentoTiro.velocidadeTiro = 0;
        SpawnInimigos.spawnRate = 999;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        ComportamentoInimigo.velocidadeInimigo = 0.07f;
        GolfinhoController.velocidade = 0.05f;
        GolfinhoController.velocidadeDescida = 0.03f;
        GolfinhoController.disparar = true;
        ComportamentoTiro.velocidadeTiro = 0.05f;
        SpawnInimigos.spawnRate = 1.3f;
        isPaused = false;
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
