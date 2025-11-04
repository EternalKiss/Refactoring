using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void Initialization(Vector3 direction, float speed)
    {
        transform.up = direction;
        GetComponent<Rigidbody>().linearVelocity = direction * speed;
    }
}
