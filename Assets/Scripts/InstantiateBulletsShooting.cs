using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] Bullet _prefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] float _timeWaitShooting;

    private Transform _objectToShoot;

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        while (enabled)
        {
            Vector3 vector3direction = (_objectToShoot.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_prefab, transform.position + vector3direction, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = vector3direction;
            newBullet.GetComponent<Rigidbody>().linearVelocity = vector3direction * _bulletSpeed;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}
