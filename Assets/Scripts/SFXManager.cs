using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip goombaDeath;

    public AudioClip marioDeath;
   
    public AudioClip getCoin;

    public AudioClip flagWin;

    private AudioSource source;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        source = GetComponent<AudioSource>();
    }

    public void GoombaDeath()
    {
        source.PlayOneShot(goombaDeath);
    }

    public void MarioDeath()
    {
        source.PlayOneShot(marioDeath);
    }

    public void GetCoin()
    {
        source.PlayOneShot(getCoin);
    }

    public void FlagWin()
    {
        source.PlayOneShot(flagWin);
    }

}
