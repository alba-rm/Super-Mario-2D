using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    public bool canShoot;
    public float powerUpDuration = 5;
    public float powerUpTimer = 0;

    public void GameOver()
    {
        isGameOver = true;
//Llamar funcion de forma manual
        //Invoke("LoadScene", 0.5f);

        StartCoroutine("LoadScene");


    }
    void Update()
    {
        ShootPowerUp();
    }

    /*void LoadScene()
    {
        SceneManager.LoadScene(2);
    }*/ 

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(2);
    }
    void ShootPowerUp ()
    {
        if(canShoot)
        {
            if(powerUpTimer <= powerUpDuration)
            {
                powerUpTimer += Time.deltaTime;
            }
            else
            {
                canShoot = false;
                powerUpTimer = 0;
            }
        }
    }
}
