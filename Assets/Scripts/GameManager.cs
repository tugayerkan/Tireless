using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameState gameState = GameState.StandBy;
    public float restartDelay = 1f;
    public GUIManager guiManager;
    public PlayerMovement playerMovement;
    public LevelDesigner levelDesigner;


    

    private void Awake()
    {
        gameState = GameState.StandBy;
        levelDesigner.Init();
    }

    public void EndGame()
    {
        gameState = GameState.Over;
        Debug.Log("Game Over");
        guiManager.EndGame();
          

    }

    public void StartGame()
    {
        playerMovement.ResetPlayer();
        levelDesigner.ResetLevel();
              

    }
}