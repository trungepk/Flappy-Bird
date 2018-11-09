using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {
    [SerializeField] GameObject columnPrefab;
    [SerializeField] int columnPoolSize = 5;
    [SerializeField] float spawnRate = 4f;
    [SerializeField] float columnMin = -1f;
    [SerializeField] float columnMax = 4f;

    private GameObject[] columns;
    private int currentColumn;
    private Vector2 objectPoolPosition = new Vector2(20, 20);
    private float timeSinceLastSpawn;
    private float spawnXPosition = 10f;


	void Start () {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
	}

    void Update() {
        timeSinceLastSpawn += Time.deltaTime;
        if (!GameControl.instance.gameOver && timeSinceLastSpawn > spawnRate)
        {
            timeSinceLastSpawn = 0f;
            var spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
	}
}
