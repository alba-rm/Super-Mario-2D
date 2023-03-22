using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    public void GameOver()
    {
        isGameOver = true;
//Llamar funcion de forma manual
        //Invoke("LoadScene", 0.5f);

        StartCoroutine("LoadScene");


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
}
