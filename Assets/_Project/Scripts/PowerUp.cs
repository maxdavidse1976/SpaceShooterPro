using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float _speed = 3.5f;
    [SerializeField] float _bottomBounds = -5.5f;
    // 0 = Triple Shot
    // 1 = Speed
    // 2 = Shields
    [SerializeField] int _powerupId;

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < _bottomBounds)
        {
            DestroyPowerup();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (_powerupId)
            {
                case 0:
                    Player.Instance.ActivateTripleShot();
                    break;
                case 1:
                    Player.Instance.ActivateSpeed();
                    break;
                case 2:
                    Player.Instance.ActivateShields();
                    break;
                default:
                    Debug.Log("Default Powerup");
                    break;
            }
            DestroyPowerup();
        }
    }

    void DestroyPowerup()
    {
        Destroy(gameObject);
    }
}
