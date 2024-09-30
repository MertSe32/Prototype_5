using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;//Textlere erişebilmek için
using UnityEngine.SceneManagement;//Sahneyi tekrar yüklemekle ilgili şeyler.(Sahne Yöneticisi)
using UnityEngine.UI;//button a erişmek için kullandık

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public bool isGameActive;
    private int score;
    private float spawnRate = 1;

    void Start()
    {
        
    }
        

    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int addToScore)
    {
        score += addToScore;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
}
