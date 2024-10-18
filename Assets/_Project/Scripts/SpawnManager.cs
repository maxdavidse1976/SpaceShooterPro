using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _tripleShotPowerUpPrefab;
    [SerializeField] GameObject _speedUpPowerUpPrefab;
    [SerializeField] GameObject _shieldsPowerUpPrefab;
    [SerializeField] GameObject _enemyContainer;
    
    [SerializeField] float _minTimeToSpawn = 3.0f;
    [SerializeField] float _maxTimeToSpawn = 6.0f;
    
    [SerializeField] float _minTimeToSpawnTripleShot = 7.5f;
    [SerializeField] float _maxTimeToSpawnTripleShot = 14.5f;

    [SerializeField] float _minTimeToSpawnSpeedUp = 7.5f;
    [SerializeField] float _maxTimeToSpawnSpeedUp = 14.5f;

    [SerializeField] float _minTimeToSpawnShields = 7.5f;
    [SerializeField] float _maxTimeToSpawnShields = 14.5f;

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
        StartCoroutine(SpawnTripleShotPowerUp());
        StartCoroutine(SpawnSpeedUpPowerUp());
        StartCoroutine(SpawnShieldsPowerUp());
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

    IEnumerator SpawnTripleShotPowerUp()
    {
        while (_allowSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(_minSpawnPositionX, _maxSpawnPositionX), _topBounds, 0);
            yield return new WaitForSeconds(Random.Range(_minTimeToSpawnTripleShot, _maxTimeToSpawnTripleShot));
            Instantiate(_tripleShotPowerUpPrefab, posToSpawn, Quaternion.identity);
        }
    }

    IEnumerator SpawnSpeedUpPowerUp()
    {
        while (_allowSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(_minSpawnPositionX, _maxSpawnPositionX), _topBounds, 0);
            yield return new WaitForSeconds(Random.Range(_minTimeToSpawnSpeedUp, _maxTimeToSpawnSpeedUp));
            Instantiate(_speedUpPowerUpPrefab, posToSpawn, Quaternion.identity);
        }
    }

    IEnumerator SpawnShieldsPowerUp()
    {
        while (_allowSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(_minSpawnPositionX, _maxSpawnPositionX), _topBounds, 0);
            yield return new WaitForSeconds(Random.Range(_minTimeToSpawnShields, _maxTimeToSpawnShields));
            Instantiate(_shieldsPowerUpPrefab, posToSpawn, Quaternion.identity);
        }
    }

    public void StopSpawning()
    {
        _allowSpawning = false;
    }
}
