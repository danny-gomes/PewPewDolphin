using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanoInimigosPassaram : MonoBehaviour
{
    static private int countInimigosPassaram = 0;

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
        if (other.gameObject.tag == "naveInimiga" || other.gameObject.tag == "golfinhoInimigo")
        {
            countInimigosPassaram++;
        }
        Debug.Log(countInimigosPassaram);
        if (countInimigosPassaram > 5)
        {
            GolfinhoController.gameOver();
        }
    }
}
