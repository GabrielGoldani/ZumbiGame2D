using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour, IMatavel, ICuravel
{

    private Vector3 direcao;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    public ControlaInterface scriptControlaInterface;
    public AudioClip SomDeDano;
    private MovimentoJogador meuMovimentoJogador;
    private AnimacaoPersonagem animacaoJogador;
    public Status statusJogador;
    public float velocity = 5;
    //private bool isPressed = false;
    public float dValue = 10;

    private void Start()
    {
        meuMovimentoJogador = GetComponent<MovimentoJogador>();
        animacaoJogador = GetComponent<AnimacaoPersonagem>();
        statusJogador = GetComponent<Status>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        scriptControlaInterface.AtualizarStaminaJogador();
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        if(eixoX != 0 && eixoZ !=0){
            velocity = 4;
        } else {
            velocity = 5;
        }

        
            if(Input.GetKey(KeyCode.LeftShift)){
                //isPressed = true;
                DecreaseEnergy();
                
                    if(statusJogador.Stamina > 0){
                    if(eixoX != 0 && eixoZ !=0){ 
                          velocity = 6f;
                    } 
                    else {
                        velocity = 7.5f;
                    }
                }
            } 
            else if (statusJogador.Stamina != statusJogador.StaminaInicial)
               Invoke("IncreaseEnergy", 1.5f); 
        
                
        
            
        
        

        animacaoJogador.Movimentar(direcao.magnitude);
        //meuMovimentoJogador.Movimentar(direcao, statusJogador.Velocidade); 
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao * velocity * Time.deltaTime));

        meuMovimentoJogador.RotacaoJogador(MascaraChao);

        
    }

    public void HitDecreaseEnergy(){
        if(statusJogador.Stamina >= 0)
            statusJogador.Stamina -= 4;
    }
    void DecreaseEnergy(){
        if(statusJogador.Stamina >= 0)
            statusJogador.Stamina -= dValue * Time.deltaTime;
    }
    void IncreaseEnergy(){
        if(statusJogador.Stamina < statusJogador.StaminaInicial)
        statusJogador.Stamina += dValue * Time.deltaTime;
    }


    public void TomarDano (int dano)
    {
        statusJogador.Vida -= dano;
        scriptControlaInterface.AtualizarSliderVidaJogador();
        ControlaAudio.instancia.PlayOneShot(SomDeDano);
        if(statusJogador.Vida <= 0)
        {
            Morrer();
        }        
    }

    public void Morrer ()
    {
        scriptControlaInterface.GameOver();
    }

    public void CurarVida (int quantidadeDeCura)
    {
        statusJogador.Vida += quantidadeDeCura;
        if(statusJogador.Vida > statusJogador.VidaInicial)
        {
            statusJogador.Vida = statusJogador.VidaInicial;
        }
        scriptControlaInterface.AtualizarSliderVidaJogador();
    }

}
