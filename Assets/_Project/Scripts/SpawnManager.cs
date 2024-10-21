using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject[] _powerUps;
    [SerializeField] GameObject _enemyContainer;
    
    [SerializeField] float _minTimeToSpawn = 3.0f;
    [SerializeField] float _maxTimeToSpawn = 6.0f;
    
    [SerializeField] float _minTimeToSpawnPowerup = 7.5f;
    [SerializeField] float _maxTimeToSpawnPowerup = 14.5f;

    [SerializeField] float _minSpawnPositionX = -10.5f;
    [SerializeField] float _maxSpawnPositionX = 10.5f;
    
    [SerializeField] float _topBounds = 7.5f;


    bool _allowSpawning = true;

    public static SpawnManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnRandomPowerup());
    }

    IEnumerator SpawnEnemy()
    {
        while (_allowSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(_minSpawnPositionX, _maxSpawnPositionX), _topBounds, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(Random.Range(_minTimeToSpawn, _maxTimeToSpawn));
        }
    }

    IEnumerator SpawnRandomPowerup()
    {
        while (_allowSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(_minSpawnPositionX, _maxSpawnPositionX), _topBounds, 0);
            yield return new WaitForSeconds(Random.Range(_minTimeToSpawnPowerup, _maxTimeToSpawnPowerup));
            Instantiate(_powerUps[Random.Range(0, _powerUps.Length)], posToSpawn, Quaternion.identity);
        }
    }

    public void StopSpawning()
    {
        _allowSpawning = false;
    }
}
