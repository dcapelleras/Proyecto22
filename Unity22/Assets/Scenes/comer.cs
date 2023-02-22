using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comer : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    public bool bueno;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.down * moveSpeed;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            if (bueno)
            {
                contador.instancia.puntuacion++;
            }
            else
            {
                contador.instancia.puntuacion--;
            }
            Destroy(this.gameObject);

        }
    }
}