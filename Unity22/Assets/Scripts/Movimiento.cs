using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
   
{
    public Rigidbody2D rb;

    Animator anim;

    [SerializeField] float velocidad = 100f;

    [SerializeField] float startingY;

    [SerializeField] float minX;
    [SerializeField] float maxX;
    // Start is called before the first frame update
    private void Start()
    {
        startingY = transform.position.y;
        anim = GetComponent<Animator>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bueno"))
        {
            anim.SetTrigger("Eat");
            MusicManager.instance.PlaySound(0);
        }
        else if (collision.CompareTag("Malo"))
        {
            anim.SetTrigger("Hit");
            MusicManager.instance.PlaySound(1);
        }
        else if (collision.CompareTag("Malisimo"))
        {
            anim.SetTrigger("Hit");
            MusicManager.instance.PlaySound(2);
        }
    }
}
