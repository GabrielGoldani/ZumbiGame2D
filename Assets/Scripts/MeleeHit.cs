using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHit : MonoBehaviour
{    
    public AudioClip SomDeMorte;
    private bool Jogador;
    private ControlaArma scriptControlaArma;
    

    private void Awake() {
        Jogador = GameObject.FindWithTag("Jogador").GetComponent<Animator>().GetBool("HitMelee");
        scriptControlaArma = GetComponent<ControlaArma>();
        
    }


    void OnTriggerEnter(Collider objetoDeColisao)
    {       

           
            Quaternion rotacaoOposta = Quaternion.LookRotation(-transform.forward);
            switch(objetoDeColisao.tag)
            {
                case "Inimigo":
                ControlaInimigo inimigo = objetoDeColisao.GetComponent<ControlaInimigo>();
                    inimigo.TomarDano(1);
                    inimigo.ParticulaSangue(transform.position, rotacaoOposta);
                break;
                case "ChefeDeFase":
                ControlaChefe chefe = objetoDeColisao.GetComponent<ControlaChefe>();
                    chefe.TomarDano(1);
                    chefe.ParticulaSangue(transform.position, rotacaoOposta);
                break;
            }
    }   
}