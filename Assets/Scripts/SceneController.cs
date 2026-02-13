using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject enemy;
    private Vector3 spawnPoint = new Vector3(0, 0, 5);
    private int enemySpawn = 4;
    private GameObject[] enemies;

    void Start()
    {
      enemies =  new GameObject[enemySpawn];
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null)
            {
                GameObject newEnemy = Instantiate(enemyPrefab) as GameObject;
                newEnemy.transform.position = spawnPoint;
                float angle = Random.Range(0, 360);
                newEnemy.transform.Rotate(0, angle, 0);
                enemies[i] = newEnemy;
            }

        }

    }
}
