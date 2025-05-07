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
    public int lives = 5;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    public bool isPaused = false;
    public GameObject pauseMenu;
    public AudioSource musicSource;

    // Start is called before the first frame update
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        lives -= difficulty;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "Lives: " + lives;

        if (lives < 0)
        {
            lives = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isPaused == false)
        {
            isPaused = true;
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && isPaused == true)
        {
            isPaused = false;
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
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
