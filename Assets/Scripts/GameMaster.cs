using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    [SerializeField]
    private int maxLives = 3;

    [SerializeField]
    private int setHighScore = 0;

    private static int _remainingLives = 3;
    public static int RemainingLives
    {
        get
        {
            return _remainingLives;
        }
    }

    private static int _highscore = 0;
    public static int HighScore
    {
        get
        {
            return _highscore;
        }
    }

    public Transform spawnPoint;
    public Transform playerPrefab;
    public int spawnDelay = 2;
    public Transform spawnPrefab;

    [SerializeField]
    private GameObject gameOverUI;

    [SerializeField]
    private GameObject youWinUI;

    void Awake()
    {
        if(gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("gm").GetComponent<GameMaster>();
        }
    }
    
    void Start()
    {
        _remainingLives = maxLives;
        _highscore = setHighScore;
    }

    public void EndGame()
    {
        gameOverUI.SetActive(true);
    }

    public static void WinGame()
    {
        gm._WinGame();
    }

    public void _WinGame()
    {
        youWinUI.SetActive(true);
    }

    public IEnumerator RespawnPlayer() {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Transform clone = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);
        Destroy(clone.gameObject, 3f);
    }

    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        _remainingLives -= 1;
        if (_remainingLives <= 0)
        {
            gm.EndGame();
        }
        else
        {
            gm.StartCoroutine(gm.RespawnPlayer());
        }
    }

    public static void KillEnemy(Enemy enemy)
    {
        gm._KillEnemy(enemy);
        _highscore += 10;
    }

    public void _KillEnemy(Enemy _enemy)
    {
        Transform _clone = (Transform)Instantiate(_enemy.deathParticles, _enemy.transform.position, Quaternion.identity);
        Destroy(_clone.gameObject, 5f);
        Destroy(_enemy.gameObject);
    }
}
