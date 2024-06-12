using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class LaberintoCrecimiento : MonoBehaviour
{
    public GameObject pieza;
    public int totalPiezas;
	public GameObject agente;

    private bool hayHueco;
    private GameObject piezaActual;

	private NavMeshSurface nms;
	

    void Start()
    {
		nms = GetComponent<NavMeshSurface>();	

        hayHueco = true;
        piezaActual = null;
        StartCoroutine(Generar(0, 0));

		Invoke("bake", 10.0f);
    }

	private void bake()
	{
		nms.BuildNavMesh();
		Instantiate(agente, new Vector3(0,2,0),Quaternion.identity);

	}

    IEnumerator Generar(float x,float z)
    {
       yield return new WaitForEndOfFrame();

        if (totalPiezas > 0)
        {
            if (hayHueco == true)
            {
                piezaActual = Instantiate(pieza, new Vector3(x,0,z), Quaternion.identity);
				piezaActual.name = "pieza" + totalPiezas;
                totalPiezas--;
            }

			float newX = 0;
            float newZ = 0;

            RaycastHit hit;


			int sentidoCrecimiento = Random.Range(0, 4);

            switch (sentidoCrecimiento)
            {
                case 0: // Norte
                    if (Physics.Raycast(piezaActual.transform.position, piezaActual.transform.forward, out hit, 3)){
                        hayHueco = false;
                        piezaActual = hit.transform.gameObject;
                    } else {
						hayHueco = true;
                    }
					newX = piezaActual.transform.position.x;
					newZ = piezaActual.transform.position.z + 5;
					break;
                case 1: // Sur
					if (Physics.Raycast(piezaActual.transform.position, piezaActual.transform.forward*-1, out hit, 3))
					{
						hayHueco = false;
						piezaActual = hit.transform.gameObject;
					}
					else
					{
						hayHueco = true;
					}
					newX = piezaActual.transform.position.x;
					newZ = piezaActual.transform.position.z - 5;
					break;
                case 2: // Este
					if (Physics.Raycast(piezaActual.transform.position, piezaActual.transform.right, out hit, 3))
					{
						hayHueco = false;
						piezaActual = hit.transform.gameObject;
					}
					else
					{
						hayHueco = true;
					}
					newX = piezaActual.transform.position.x + 5;
					newZ = piezaActual.transform.position.z;
					break;
                 case 3: // Oeste
					if (Physics.Raycast(piezaActual.transform.position, piezaActual.transform.right*-1, out hit, 3))
					{
						hayHueco = false;
						piezaActual = hit.transform.gameObject;
					}
					else
					{
						hayHueco = true;
					}
					newX = piezaActual.transform.position.x - 5;
					newZ = piezaActual.transform.position.z;
					break;
            }


			
			
			StartCoroutine(Generar(newX, newZ));
		}

        
	}
}
