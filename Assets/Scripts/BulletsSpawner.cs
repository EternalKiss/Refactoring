using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletsSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _objectToShoot;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _timeWaitShooting;

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        while (enabled)
        {
            Vector3 bulletDirection = (_objectToShoot.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_prefab, transform.position + bulletDirection, Quaternion.identity);

            newBullet.GetComponent<Bullet>().Initialization(bulletDirection, _bulletSpeed);

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}
