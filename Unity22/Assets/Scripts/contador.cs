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
    [SerializeField] GameObject playerObj;

    [SerializeField] List<GameObject> backgrounds = new List<GameObject>();

    void Start()
    {
        if (instancia== null)
        {
            instancia = this;
        }
        playerObj.SetActive(true);
        vidaCounter.text = "Vida" + vida.ToString();
        textCounter.text = "Puntos" + puntuacion.ToString();
        gameOverText.gameObject.SetActive(false);
        restartButton.SetActive(false);
        backgrounds[0].SetActive(true);
        backgrounds[1].SetActive(false);
        backgrounds[2].SetActive(false);
    }

    public void Puntuar(int punto)
    {
        puntuacion += punto;
        textCounter.text = "Puntos" + puntuacion.ToString();
        if (puntuacion <= 10)
        {
            MusicManager.instance.ChangeMusic(0);
            backgrounds[0].SetActive(true);
            backgrounds[1].SetActive(false);
            backgrounds[2].SetActive(false);
        }
        else if (puntuacion <= 20)
        {
            MusicManager.instance.ChangeMusic(1);
            backgrounds[0].SetActive(false);
            backgrounds[1].SetActive(true);
            backgrounds[2].SetActive(false);
        }
        else
        {
            MusicManager.instance.ChangeMusic(2);
            backgrounds[0].SetActive(false);
            backgrounds[1].SetActive(false);
            backgrounds[2].SetActive(true);
        }
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
            gameOverText.text = "Por dios, que malo eres... Quizá la proxima llegas a 0... Puntuación conseguida: " + puntuacion.ToString();
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
        playerObj.SetActive(false);
        //activar gif
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
