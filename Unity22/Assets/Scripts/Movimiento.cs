using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
   
{
    public Rigidbody2D rb;

    [SerializeField] float velocidad = 100f;

    [SerializeField] float startingY;

    [SerializeField] float minX;
    [SerializeField] float maxX;
    // Start is called before the first frame update
    private void Start()
    {
        startingY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float direccion = Input.GetAxisRaw("Horizontal");
        direccion *= velocidad * Time.deltaTime;
        Vector2 myPos = new Vector2(transform.position.x, startingY);
        rb.MovePosition(myPos + new Vector2(direccion, 0f)); 

        if (transform.position.x < minX)
        {
            transform.position = new Vector2(maxX, startingY);
        }

        if (transform.position.x > maxX)
        {
            transform.position = new Vector2(minX, startingY);
        }

    }
}
