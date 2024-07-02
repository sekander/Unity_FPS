using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemiesAlive = 0;
    public int round = 0;

    public GameObject[] spawnPoints;

    public GameObject enemyPrefab;

    public Text roundNumber;
    public Text roundsSurvived;
    public GameObject endScreen;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesAlive == 0){
            round++;
            NextWave(round);
            roundNumber.text = "ROUND: " + round.ToString();
        }
        
    }

    public void NextWave(int round)
    {
        for(int i = 0; i < round; i++){
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            enemySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();
            enemiesAlive++;
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        endScreen.SetActive(true);
        roundsSurvived.text = round.ToString();

    }

    public void Restart()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }
    
    public void MainMenu()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }


}
