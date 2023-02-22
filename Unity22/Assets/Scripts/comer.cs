using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comer : MonoBehaviour
{
    public bool bueno;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (bueno)
            {
                contador.instancia.Puntuar(1);
            }
            else
            {
                contador.instancia.LoseHP();
                contador.instancia.Puntuar(-1);
            }
            gameObject.SetActive(false);

        }
    }
}