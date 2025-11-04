using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void Initialization(Vector3 direction, float bulletSpeed)
    {
        transform.up = direction;
        GetComponent<Rigidbody>().linearVelocity = direction * bulletSpeed;
    }
}
