using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreenScript : MonoBehaviour
{
    static GameObject button;
    public GameObject deathScreen;


    void Start()
    {
        button = GameObject.Find("MainMenuButton");
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void setMainMenuButton()
    {
        button.SetActive(true);
    }

    public void quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
