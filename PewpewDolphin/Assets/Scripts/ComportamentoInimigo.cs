using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComportamentoInimigo : MonoBehaviour
{
    static public float velocidadeInimigo = 0.07f;
    public GameObject golfinhoLiberado;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, 0, velocidadeInimigo * -1);

        if (this.transform.position.z < -5)
        {
            Destroy(this.gameObject);
        }

        if(score < 0)
        {
            GolfinhoController.gameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        TextMeshProUGUI scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();

        float currentXposition = this.transform.position.x;
        float currentYposition = this.transform.position.y;
        float currentZposition = this.transform.position.z;

        if (other.gameObject.tag == "heroi")
        {
            GolfinhoController.gameOver();
        }

        if (other.gameObject.tag == "tiroDestruir")
        {
            Destroy(other.gameObject);
            if (this.gameObject.tag == "golfinhoInimigo")
            {
                score = score - 8;
                scoreText.text = "Score: " + score;
                Destroy(this.gameObject);
            }
            else if(other.gameObject.tag == "golfinhoRosa")
            {
                GolfinhoController.gameOver();
            }
            else
            {
                Destroy(this.gameObject);
                score = score + 8;
                scoreText.text = "Score: " + score;
            }

            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "tiroLiberar")
        {
            Destroy(other.gameObject);

            if (this.gameObject.tag == "golfinhoInimigo")
            {
                GameObject golfinhoLiberadoCriado = Instantiate(golfinhoLiberado, new Vector3(currentXposition, currentYposition, currentZposition), Quaternion.identity);
                golfinhoLiberadoCriado.transform.rotation = Quaternion.Euler(0, 180, 0);
                Destroy(this.gameObject);
                score = score + 8;  
                scoreText.text = "Score: " + score;
            } else if(this.gameObject.tag == "golfinhoRosa")
            {
                GolfinhoController.win();
            }
        }
    }
}
