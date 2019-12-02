using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    public Transform spawnPoint;
    public Transform playerPrefab;
    public int spawnDelay = 2;
    public Transform spawnPrefab;

    void Start()
    {
        if(gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("gm").GetComponent<GameMaster>();
        }
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
        gm.StartCoroutine(gm.RespawnPlayer());
    }

    public static void KillEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}
