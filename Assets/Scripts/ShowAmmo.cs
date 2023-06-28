using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAmmo : MonoBehaviour
{   
    public GameObject Jogador;
    public Text TextAmmo;
    // Start is called before the first frame update
    private void Awake() {
        Jogador = GameObject.FindWithTag("Jogador");
        TextAmmo = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        TextAmmo.text = Jogador.GetComponent<ControlaArma>().Ammo.ToString() + "/17";


    }
}
