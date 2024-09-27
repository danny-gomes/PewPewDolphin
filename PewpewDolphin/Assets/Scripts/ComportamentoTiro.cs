using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoTiro : MonoBehaviour
{

    public static float velocidadeTiro = 0.05f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, 0, velocidadeTiro);

        if (this.transform.position.z > 70)
        {
            Destroy(this.gameObject);
        }
    }
}
