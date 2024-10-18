using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed = 4f;
    [SerializeField] float _bottomBounds = -5.5f;
    [SerializeField] float _topBounds = 7.5f;
    [SerializeField] float _minSpawnPositionX = -10.5f;
    [SerializeField] float _maxSpawnPositionX = 10.5f;

    void Start()
    {
        transform.position = new Vector3(Random.Range(_minSpawnPositionX, _maxSpawnPositionX), _topBounds, 0);
    }

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < _bottomBounds)
        {
            RespawnEnemy();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.Instance.DamagePlayer();
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    void RespawnEnemy()
    {
        transform.position = new Vector3(Random.Range(_minSpawnPositionX, _maxSpawnPositionX), _topBounds, 0);
    }
}
