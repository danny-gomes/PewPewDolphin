using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoGolfinhoLiberado : MonoBehaviour
{
    public float velocidadeGolfinhoLiberadoZ = 0.10f;
    public float velocidadeGolfinhoLiberadoX = 0.03f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(velocidadeGolfinhoLiberadoX, velocidadeGolfinhoLiberadoZ * -1, 0));
    }
}
