using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] GameObject _laserPrefab;
    [SerializeField] GameObject _tripleShotPrefab;
    [SerializeField] float _laserOffSet = 1f;
    [SerializeField] float _fireRate = 0.5f;

    [SerializeField] int _lives = 3;
    [SerializeField] int _currentLives = 0;
    [SerializeField] float _tripleShotActiveTime = 5f;

    float _upperBounds = 0f;
    float _lowerBounds = -3.8f;
    float _leftBounds = -11.3f;
    float _rightBounds = 11.3f;

    float _canFire = -1f;
    bool _isTripleShotEnabled = false;

    public static Player Instance;


    void Awake()
    {
        Instance = this;
        _currentLives = _lives;
    }

    void Start()
    {
        transform.position = Vector3.zero;
    }

    void Update()
    {
        MovePlayer();
        CheckVerticalBoundaries();
        CheckHorizontalBoundaries();
        FireLaser();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    void CheckVerticalBoundaries()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, _lowerBounds, _upperBounds), transform.position.z);
    }

    void CheckHorizontalBoundaries()
    {
        if (transform.position.x >= _rightBounds)
        {
            transform.position = new Vector3(_leftBounds, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < _leftBounds)
        {
            transform.position = new Vector3(_rightBounds, transform.position.y, transform.position.z);
        }
    }

    void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Vector3 laserPosition = transform.position + new Vector3(0, _laserOffSet, 0);
            
            if (_isTripleShotEnabled)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, laserPosition, Quaternion.identity);
            }

        }
    }

    public void DamagePlayer()
    {
        _currentLives--;
        if (_currentLives < 1)
        {
            SpawnManager.Instance.StopSpawning();
            Destroy(this.gameObject);
        }
        Debug.Log($"Player lives: {_currentLives}");
    }

    public void ActivateTripleShot()
    {
        _isTripleShotEnabled = true;
        StartCoroutine(DeactivateTripleShot());
    }

    IEnumerator DeactivateTripleShot()
    {
        yield return new WaitForSeconds(_tripleShotActiveTime);
        _isTripleShotEnabled = false;
    }
}
