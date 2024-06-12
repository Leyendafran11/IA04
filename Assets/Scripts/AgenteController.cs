using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgenteController : MonoBehaviour
{
	private NavMeshAgent agente;
    void Start()
    {
		agente = GetComponent<NavMeshAgent>();

	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit rayo;

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out rayo))
			{
				agente.destination = rayo.point;
			}
		}
	}


}
