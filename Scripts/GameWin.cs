using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameWin : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetKeyDown("r")) SceneManager.LoadScene("Desafio");
    }
}
