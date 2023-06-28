using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMaxReload : MonoBehaviour
{   
    public GameObject Jogador;
    public Text TextReload;
    // Start is called before the first frame update
    private void Awake() {
        Jogador = GameObject.FindWithTag("Jogador");
        
        TextReload = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TextReload.text = Jogador.GetComponent<ControlaArma>().realoadMax.ToString();

    }
}
