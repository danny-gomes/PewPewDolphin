using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanoInimigosPassaram : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        TextMeshProUGUI scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();

        ComportamentoInimigo.score = ComportamentoInimigo.score - 8;

        scoreText.text = "Score: " + ComportamentoInimigo.score;
    }
}
