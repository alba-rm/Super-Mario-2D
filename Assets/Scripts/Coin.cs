using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Animator anim;
    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {}
    public void Get()
    { 
    
        anim.SetBool("IsGet", true);
        boxCollider.enabled = false;
        Destroy(this.gameObject, 0.5f);
    }
}
