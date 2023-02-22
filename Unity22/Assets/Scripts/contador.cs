using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class contador : MonoBehaviour
{
    public static contador instancia;
    public int puntuacion = 0;
    public int vida = 5;
    [SerializeField] TMP_Text textCounter;
    [SerializeField] TMP_Text vidaCounter;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] GameObject restartButton;

    void Start()
    {
        if (instancia== null)
        {
            instancia = this;
        }
        vidaCounter.text = "Vida" + vida.ToString();
        textCounter.text = "Puntos" + puntuacion.ToString();
        gameOverText.gameObject.SetActive(false);
        restartButton.SetActive(false);
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
        if (puntuacion < 0)
        {
            gameOverText.text = "Por dios, que malo eres... Puntuación conseguida: " + puntuacion.ToString();
        }
        else if (puntuacion < 5)
        {
            gameOverText.text = "Mediocre pero podria ser peor... Puntuación conseguida: " + puntuacion.ToString();
        }
        else if (puntuacion < 20)
        {
            gameOverText.text = "Not bad! Puntuación conseguida: " + puntuacion.ToString();
        }
        else
        {
            gameOverText.text = "Puto amo! Puntuación conseguida: " + puntuacion.ToString();
        }
        restartButton.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        Time.timeScale= 0;
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        gameOverText.gameObject.SetActive(false);
        puntuacion= 0;
        vida = 5;
        SceneManager.LoadScene(0);
    }
}
