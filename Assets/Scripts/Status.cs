using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int VidaInicial = 100;
    [HideInInspector]
    public int Vida;
    public float Velocidade = 10;
    public float Stamina;
    public float StaminaInicial = 10;

    void Awake ()
    {   
        Stamina = StaminaInicial;
        Vida = VidaInicial;
        
    }

}
