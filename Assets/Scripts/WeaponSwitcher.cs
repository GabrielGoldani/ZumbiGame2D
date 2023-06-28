using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject[] weapons;
    private ControlaArma Jogador;
    public bool InKnife = false;
    public bool InPistol = false;
    public bool InSMG = false;
    private Animator Animator;
    private int lastWeapon;
    
    private int currentWeaponIndex = 0;
    
    private void Awake() {
        Jogador = GameObject.FindWithTag("Jogador").GetComponent<ControlaArma>();
        Animator = GameObject.FindWithTag("Jogador").GetComponent<Animator>();
    }
    void Start()
    {   
        lastWeapon = 0;
        SwitchWeapon();
    }

    void Update()
    {   
        if( currentWeaponIndex == 0){
            InKnife = true;
        } else
            InKnife = false;

        if( currentWeaponIndex == 1){
            InPistol = true;
        } else
            InPistol = false;

        if( currentWeaponIndex == 2){
            InSMG = true;
        } else
            InSMG = false;



        if (Input.GetKeyDown(KeyCode.Alpha1) && Jogador.Mirando == false && Jogador.reloading == false)
        {       
            if(lastWeapon != 0 ){
                    Animator.SetTrigger("EquipMelee");
                    Invoke("TransitEquipIdle",1f);
            }
                currentWeaponIndex = 0;
                Invoke("SwitchWeapon",1.15f);
                lastWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && Jogador.Mirando == false && Jogador.reloading == false)
        {
             if(lastWeapon != 1 ){
                    Animator.SetTrigger("EquipMelee");
                    Invoke("TransitEquipIdle",1f);
            }
                currentWeaponIndex = 1;
                Invoke("SwitchWeapon",1.15f);
                lastWeapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && Jogador.Mirando == false && Jogador.reloading == false)
        {
            if(lastWeapon != 2 ){
                    Animator.SetTrigger("EquipMelee");
                    Invoke("TransitEquipIdle",1f);
            }
                currentWeaponIndex = 2; 
                Invoke("SwitchWeapon",1.15f);
                lastWeapon = 2;
        }
    }
    
    void SwitchWeapon()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == currentWeaponIndex);
        }
    }

    void TransitEquipIdle(){
        Animator.SetTrigger("TransitEquipIdle");
    }
}
