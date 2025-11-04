using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
       _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialization(Vector3 direction, float bulletSpeed)
    {
        transform.up = direction;
        _rigidbody.linearVelocity = direction * bulletSpeed;
    }
}
