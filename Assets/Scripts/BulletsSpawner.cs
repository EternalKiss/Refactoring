using System.Collections;
using UnityEngine;

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
        var waitShooting = new WaitForSeconds(_timeWaitShooting);

        while (enabled)
        {
            Vector3 bulletDirection = (_objectToShoot.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_prefab, transform.position + bulletDirection, Quaternion.identity);

            newBullet.Initialization(bulletDirection, _bulletSpeed);

            yield return waitShooting;
        }
    }
}
