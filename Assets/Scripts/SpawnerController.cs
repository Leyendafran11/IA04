using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject robot;
    public int ancho;
    public int largo;
    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(5.0f);

        while (true)
        {
            int x = Random.Range(0,ancho+1);
            int z = Random.Range(0,largo+1);

            this.transform.position = new Vector3(x,this.transform.position.y,z);

            if (Physics.Raycast(this.transform.position, this.transform.up * -1, 4))
            {
                robot.transform.position = this.transform.position; 
                break;
            }

            yield return new WaitForEndOfFrame();
        }

        /*while (true)
        {
            Vector3 direccion = this.transform.position - robot.transform.position;
            robot.transform.position = robot.transform.position + direccion.normalized * 10 * Time.deltaTime;

			yield return new WaitForEndOfFrame();

			if (robot.transform.position.y < 10)
			{
				break;
			}
		}*/

       
    }

    
}
