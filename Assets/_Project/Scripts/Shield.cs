using UnityEngine;

public class Shield : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Player.Instance.DestroyShield();
            Destroy(this.gameObject);
        }
    }
}
