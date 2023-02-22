using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class contador : MonoBehaviour
{
    public static contador instancia;
    public int puntuacion = 0;
    public int vida = 5;
    [SerializeField] TMP_Text textCounter;
    [SerializeField] TMP_Text vidaCounter;
    [SerializeField] TMP_Text gameOverText;

    void Start()
    {
        if (instancia== null)
        {
            instancia = this;
        }
        vidaCounter.text = "Vida" + vida.ToString();
        textCounter.text = "Puntos" + puntuacion.ToString();
        gameOverText.gameObject.SetActive(false);
    }

    public void Puntuar(int punto)
    {
        puntuacion += punto;
        textCounter.text = "Puntos" + puntuacion.ToString();
    }

    public void LoseHP()
    {
        vida--;
        vidaCounter.text = "Vida" + vida.ToString();
        if (vida <=0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        Time.timeScale= 0;
    }
}
