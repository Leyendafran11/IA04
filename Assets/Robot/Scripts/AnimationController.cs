
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    private Animator anim;
	private float velocidad;

	private Vector3 pos_0;
	private Vector3 pos_1;
	
	// Use this for initialization
	void Start () 
	{
		pos_0 = this.transform.position;
		velocidad = 0;
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate() 
	{		
		pos_1 = this.transform.position;
		velocidad = Vector3.Distance (pos_0, pos_1);
		velocidad = velocidad / Time.fixedDeltaTime;
        pos_0 = pos_1;

		anim.SetFloat("Speed", velocidad);
		Debug.Log(velocidad);
    }
}
