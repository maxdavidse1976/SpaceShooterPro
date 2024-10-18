using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    [SerializeField] float _destroyPosition = 8f;

    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        CheckIfNeedsToBeDestroyed();
    }

    void CheckIfNeedsToBeDestroyed()
    {
        if (transform.position.y > _destroyPosition)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
