using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour {

    public GameObject Bala;
    public GameObject CanoDaArma;
    public AudioClip SomDoTiro;
    public int Ammo = 17;
    public int InicialAmmo;
    public bool reloading;
    public int realoadMax = 3;
    private Animator animator;
    public float TimeReload = 5;
    private float inicialTimeReload;
    public bool Mirando = false;
    private WeaponSwitcher scriptWeaponSwitch;
    public bool HitMelee = false;
    public GameObject HitBox;
    public float tempoEntreAtaques = 0.1f;
    public float LastHit;
    private ControlaJogador jogador;
    private Status statusjogaodor;

    private void Awake() {
        jogador = GetComponent<ControlaJogador>();
        statusjogaodor = GetComponent<Status>();
    }
    

	// Use this for initialization
	void Start () {
        LastHit = -tempoEntreAtaques;
		InicialAmmo = Ammo;
        reloading = false;
        animator = GetComponent<Animator>();
        inicialTimeReload = TimeReload;
        scriptWeaponSwitch = GetComponent<WeaponSwitcher>();
        
	}
	
	// Update is called once per frame
	void Update () {

        if (scriptWeaponSwitch.InKnife == false && scriptWeaponSwitch.InPistol == true && scriptWeaponSwitch.InSMG == false){
            if(Input.GetAxis("Fire2") != 0){
                animator.SetBool("Mirando", true);
                Mirando = true;
                if(reloading == false){
                    if(Ammo > 0){
                        if(Input.GetButtonDown("Fire1"))
                        {   
                            Instantiate(Bala, CanoDaArma.transform.position, CanoDaArma.transform.rotation);
                            Ammo--;
                            ControlaAudio.instancia.PlayOneShot(SomDoTiro);
                        }
                    } //sound falta de ammo
                }
            
            } else {
                animator.SetBool("Mirando", false);
                Mirando = false;
            }
        }

        if (scriptWeaponSwitch.InKnife == false ){
            if(Input.GetKeyDown(KeyCode.R) && realoadMax > 0){
                //if(realoadMax > 0){
                    animator.SetBool("Reloading", true);
                    StartCoroutine(Reloading());
                    reloading = true;
                //}
            }
        }

        if(scriptWeaponSwitch.InSMG == true && Input.GetAxis("Fire2") != 0){
            StartCoroutine(AtirarSMG());
        }

        if (scriptWeaponSwitch.InKnife == true){
            //if(Input.GetAxis("Fire2") != 0){ // mirando
               // animator.SetBool("MirandoMelee", true);
                if(Input.GetAxis("Fire1") != 0 && statusjogaodor.Stamina >= 4f && Time.time > LastHit + tempoEntreAtaques){ // batendo
                    LastHit = Time.time;
                    jogador.HitDecreaseEnergy();
                    animator.SetTrigger("HitMelee");
                    StartCoroutine(AtivarHitBox(HitBox, 1.2f));
                    animator.SetTrigger("HitMelee2");


                }  
                
               
            //} else{
                //animator.SetBool("MirandoMelee", false);
           // }
        }          


	}

    IEnumerator AtirarSMG(){
        yield return new WaitForSeconds(0.1f);
        while(Input.GetAxis("Fire1") != 0 && Ammo > 0){
            yield return new WaitForSeconds(1f);
            Instantiate(Bala, CanoDaArma.transform.position, CanoDaArma.transform.rotation);
            Ammo--;
            ControlaAudio.instancia.PlayOneShot(SomDoTiro);
            yield return null;
        }
    }

    IEnumerator AtivarHitBox(GameObject objeto, float tempo)
    {   
        yield return new WaitForSeconds(0.4f);
        // Ativa o GameObject
        objeto.SetActive(true);
        GetComponent<MovimentoJogador>().enabled = false;

        // Espera pelo tempo desejado
        yield return new WaitForSeconds(tempo);

        // Desativa o GameObject
        objeto.SetActive(false);
        GetComponent<MovimentoJogador>().enabled = true;
    }
    public void PegarCaixaDeMunicao(int QtdDeReload){
        realoadMax+=QtdDeReload;

    }

    IEnumerator Reloading(){
        yield return new WaitForSeconds(3.5f);
        animator.SetBool("Reloading", false);
        Ammo=+InicialAmmo;
        realoadMax--;
        reloading = false;   
        
    }
}
