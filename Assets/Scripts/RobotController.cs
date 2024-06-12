using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    private int m;
    private int r;
    private Rigidbody rb;
    private Vector3 posInicial;
    private int vidaInicial;
    private int movInicial;

    public int vMovimiento;
    public int vRotacion;
    public int vida;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posInicial = this.transform.position;
        vidaInicial = vida;
        movInicial = vMovimiento;
    }

    // Update is called once per frame
    void Update()
    {
        m = 0;
        r = 0;

        if (Input.GetKey(KeyCode.A))
        {
            r = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            r = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            m = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            m = -1;
        }
    }

    private void FixedUpdate()
    {
        Quaternion rotacion = Quaternion.Euler(this.transform.up * r * vRotacion * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * rotacion);

        rb.MovePosition(rb.position + this.transform.forward * m * vMovimiento * Time.fixedDeltaTime);
    }


    public void quitarVida()
    {

		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;

		vida--;
        vMovimiento--;

        if (vida == 0)
        {
           this.transform.position = posInicial;
           vida = vidaInicial;
            vMovimiento = movInicial;

        }

    }



}
