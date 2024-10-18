using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float _speed = 3.5f;
    [SerializeField] float _bottomBounds = -5.5f;

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
            Player.Instance.ActivateTripleShot();
            DestroyPowerup();
        }
    }

    void DestroyPowerup()
    {
        Destroy(gameObject);
    }
}
