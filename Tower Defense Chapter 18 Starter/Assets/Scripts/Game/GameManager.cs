
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //1
    public static GameManager Instance;
    //2
    public int gold;
    //3
    public int waveNumber;
    //4
    public int escapedEnemies;
    //5
    public int maxAllowedEscapedEnemies = 5;
    //6
    public bool enemySpawningOver;
    //7
    public AudioClip gameWinSound;
    public AudioClip gameLoseSound;
    //8
    public bool gameOver;

    //1
    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        //2
        if (!gameOver && enemySpawningOver)
        {
            
            //3
            if (EnemyManager.Instance.Enemies.Count == 0)
            {
                OnGameWin();
            }
        }

        
        //4
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitToTitleScreen();
        }
    }

    //5
    private void OnGameWin()
    {
        AudioSource.PlayClipAtPoint(gameWinSound, Camera.main.transform.position);
        gameOver = true;
        UIManager.Instance.ShowWinScreen();
    }
    //6
    public void QuitToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    //1
    public void OnEnemyEscape()
    {
        escapedEnemies++;
        UIManager.Instance.ShowDamage();

        if (escapedEnemies == maxAllowedEscapedEnemies)
        {
           
            OnGameLose();
        }
    }

    //2
    private void OnGameLose()
    {
        gameOver = true;

        AudioSource.PlayClipAtPoint(gameLoseSound, Camera.main.transform.position);
        EnemyManager.Instance.DestroyAllEnemies();
        WaveManager.Instance.StopSpawning();

        UIManager.Instance.ShowLoseScreen();
    }

    //3
    public void RetryLevel()
    {
        SceneManager.LoadScene("Game");
    }
}
