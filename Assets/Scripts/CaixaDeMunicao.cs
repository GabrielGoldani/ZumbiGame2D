using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaDeMunicao : MonoBehaviour
{   
    private int qtdDeReload = 2;
    private int tempoDeDestruicao = 5; 

    private void Start() {
        Destroy(gameObject, tempoDeDestruicao);
    }
    
    private void OnTriggerEnter(Collider objetoDeColisao) {
        if(objetoDeColisao.tag == "Jogador"){

            objetoDeColisao.GetComponent<ControlaArma>().PegarCaixaDeMunicao(qtdDeReload);
            Destroy(gameObject);
        }
    }
}
