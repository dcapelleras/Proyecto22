using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
   
{
    public Rigidbody2D rb;

    float velocidad = 15f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        float direccion = Input.GetAxisRaw("Horizontal");
        direccion *= velocidad *= Time.deltaTime;
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        rb.MovePosition(myPos + new Vector2(direccion, myPos.y)); 

    }
}
