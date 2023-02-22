using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contador : MonoBehaviour
{
    public static contador instancia;
    public int puntuacion = 0;

    void Start()
    {
        if (instancia== null)
        {
            instancia = this;
        }
    }
}
