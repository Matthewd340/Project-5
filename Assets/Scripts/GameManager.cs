using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 2;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    public TextMeshProUGUI difficultyText;


    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        difficultyText.text = "Difficulty: Beginner";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score > 30)
        {
            spawnRate = 1;
            difficultyText.text = "Difficulty: Standard";
        }

                if (score > 50)
        {
            spawnRate =  0.5f;
            difficultyText.text = "Difficulty: Proud";
        }

            if (score > 100)
        {
            spawnRate =  0.3f;
            difficultyText.text = "Difficulty: Critical!";
        }
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

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
