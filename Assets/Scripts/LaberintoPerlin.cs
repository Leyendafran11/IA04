using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaberintoPerlin : MonoBehaviour
{
    public GameObject pieza;
    public int ancho;
    public int largo;
    public float escala;
    public int alturaMax;

    // Start is called before the first frame update
    void Start()
    {
        float semilla = Random.Range(0.0f, 100.0f);

        for(int i =0;i<ancho;i++)
        {
            for(int j = 0;j<largo; j++)
            {
                float coorX = semilla + (i / escala);
                float coorZ = semilla + (j / escala);

                int y = (int) (Mathf.PerlinNoise(coorX, coorZ) * alturaMax);

                if(y<30)
                {
                    Instantiate(pieza, new Vector3(i*5, 0, j*5), Quaternion.identity);
                }
            }
        }
    }
}
