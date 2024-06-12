using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaController : MonoBehaviour
{
	private GameObject suelo;
	private GameObject paredNorte;
	private GameObject paredSur;
	private GameObject paredEste;
	private GameObject paredOeste;
	private GameObject techo;
	void Start()
    {
		suelo = this.transform.GetChild(0).gameObject;
		paredNorte = this.transform.GetChild(3).gameObject;
		paredSur = this.transform.GetChild(4).gameObject;
		paredEste = this.transform.GetChild(2).gameObject;
		paredOeste = this.transform.GetChild(1).gameObject;
		techo = this.transform.GetChild(5).gameObject;

		Invoke("quitarParedes", 5.0f);
    }

	private void quitarParedes()
	{
		//Norte
		if (Physics.Raycast(suelo.transform.position, suelo.transform.forward, 3)) {
			Destroy(paredNorte);
		}

		//Sur
		if (Physics.Raycast(suelo.transform.position, suelo.transform.forward * -1, 3))
		{
			Destroy(paredSur);
		}

		//Este
		if (Physics.Raycast(suelo.transform.position, suelo.transform.right, 3))
		{
			Destroy(paredEste);
		}

		//Oeste
		if (Physics.Raycast(suelo.transform.position, suelo.transform.right * -1, 3))
		{
			Destroy(paredOeste);
		}

		int numAleatorio = Random.Range(0, 2);

		if (numAleatorio == 0)
		{
			Destroy(techo);
		}


	}


}
