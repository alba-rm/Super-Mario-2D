using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundSensor : MonoBehaviour
{
    //examen
    private PlayerControler controller;

    public bool isGrounded;

    SFXManager sfxManager;

    SoundManager soundManager;

    GameManager gameManager;


    void Awake()
    {
        //examen
        controller = GetComponentInParent<PlayerControler>();

        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
            //examen
            controller.anim.SetBool("IsJumping", false);
        }
        else if (other.gameObject.layer == 6)
        {
            Debug.Log("Goomba muerto");

            sfxManager.GoombaDeath();

            Enemy goomba = other.gameObject.GetComponent<Enemy>();
            goomba.Die();
        }
        
        else if (other.gameObject.layer == 9)
        {
            Debug.Log("Moneda conseguida");

            Coin coin = other.gameObject.GetComponent<Coin>();
            coin.Get();
        }
       
        else if (other.gameObject.layer == 10)
        {
            Debug.Log("Has ganado");

            Flag flag = other.gameObject.GetComponent<Flag>();
            flag.Win();
        }
     
        if(other.gameObject.tag == "DeadZone")
        {
            Debug.Log("Estoy muerto");

            soundManager.StopBGM();
            sfxManager.MarioDeath(); 
            //SceneManager.LoadScene(2);
            gameManager.GameOver();

        }
    }
    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
            //examen
            controller.anim.SetBool("IsJumping", false);
        }
        
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = false;
            //examen
            controller.anim.SetBool("IsJumping", true);
        }
        
    }
    
}
