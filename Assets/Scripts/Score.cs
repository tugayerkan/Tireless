using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    void Update()
    {
        if (GameManager.gameState==GameState.Playing)
        {
            scoreText.text = player.position.z.ToString("0");
        }
        
    }
}
