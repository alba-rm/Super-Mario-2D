using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    BoxCollider2D boxCollider;

    SFXManager sfxManager;

    SoundManager soundManager;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }

    public void Win()
    {
        
        boxCollider.enabled = false;
        soundManager.StopBGM();
        sfxManager.FlagWin();
    }

}
