using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject iguanaPrefab;
    [SerializeField] private Transform iguanaPawnPt;
    [SerializeField] private UIManager uiManager;
    private GameObject enemy;
    private Vector3 spawnPoint = new Vector3(0, 0, 5);
    private int enemySpawn = 4;
    private int iguanaSpawn = 5;
    private GameObject[] enemies;
    private GameObject[] iguanas;

    private int score = 0;
    void Start()
    {
        enemies =  new GameObject[enemySpawn];
        iguanas = new GameObject[iguanaSpawn];
        fillIguana();
        uiManager.UpdateScore(score);
    }
    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
    }

    void fillIguana()
    {
        for (int i = 0; i < iguanas.Length; i++)
        {
            if (iguanas[i] == null)
            {
                GameObject newIguana = Instantiate(iguanaPrefab) as GameObject;
                newIguana.transform.position = iguanaPawnPt.position;
                float angle = Random.Range(0, 360);
                newIguana.transform.Rotate(0, angle, 0);
                iguanas[i] = newIguana;
            }

        }
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
    private void OnEnemyDead()
    {
        score++;
        uiManager.UpdateScore(score);
    }
}
