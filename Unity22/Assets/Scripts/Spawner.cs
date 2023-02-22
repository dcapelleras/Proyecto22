using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //SerializeField significa que se puede modificar desde editor de unity
    [SerializeField] float yPos;
    [SerializeField] float maxXPos;
    [SerializeField] float minXPos;

    //GameObject se refiere a los objetos de unity, puede ser cualquier cosa incluso un vacio, [] se refire a un array, un grupo donde se puede acceder por indice
    [SerializeField] List<GameObject> objetos = new List<GameObject>();

    [SerializeField] float tiempoEntreSpawn = 1f;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() //para spawnear bolas. IEnumerator es una corutina, para que se repita cada tiempo que pones el el yield return, NUNCA invocar en update
    {
        while (true)
        {
            float randomInt = 0; //numero aleatorio
            randomInt = Random.Range(minXPos, maxXPos); //aleatorio entre minimo y maximo

            Vector2 spawnPosition = new Vector2(randomInt, yPos);

            int randomObj = Random.Range(0, 2);

            Instantiate(objetos[randomObj], spawnPosition, Quaternion.identity);

            tiempoEntreSpawn -= 0.2f;
            tiempoEntreSpawn = Mathf.Clamp(tiempoEntreSpawn, 0.4f, 2f);

            yield return new WaitForSeconds(tiempoEntreSpawn);
        }
    }
}
