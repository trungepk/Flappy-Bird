using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    public static GameControl instance;
    [SerializeField] GameObject gameOverText;
    [SerializeField] Text scoreText;
    public bool gameOver;

    private int score;

	void Awake () {
        if (instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
	}

    private void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Die()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
	
    public void Score()
    {
        if (gameOver) { return; }
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
