using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] Boost;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void  resetGame()
    {

        for (int i = 0; i < Boost.Length; i++)
        {
            Boost[i].SetActive(true);
        }
    }
}
