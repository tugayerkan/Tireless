using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GUIManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject tapToPlayPanel;
    
    
   
    
    public void PlayGame()
    {
        tapToPlayPanel.SetActive(false);
        gameManager.StartGame();
        
    }

    public void EndGame()
    {
        tapToPlayPanel.SetActive(true);
        


    }
   
}