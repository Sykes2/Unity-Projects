using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1f;
    private int score;
    public TextMeshProUGUI scoreText;
    public bool isGameActive;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnTarget(){
       while(isGameActive){
           yield return new WaitForSeconds(spawnRate);
           int index = Random.Range(0, targets.Count);
           Instantiate(targets[index]);
       }
    }

    public void GameOver(){
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
