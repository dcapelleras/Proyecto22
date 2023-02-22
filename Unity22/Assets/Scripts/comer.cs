using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comer : MonoBehaviour
{
    public int vidaAumentada;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (vidaAumentada > 0)
            {
                contador.instancia.Puntuar(vidaAumentada);
            }
            else
            {
                contador.instancia.LoseHP();
                contador.instancia.Puntuar(vidaAumentada);
            }
            gameObject.SetActive(false);

        }
    }
}