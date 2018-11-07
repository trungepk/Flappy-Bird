using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
    public static GameControl instance;
    [SerializeField] GameObject gameOverText;
    private bool gameOver;

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
	
}
