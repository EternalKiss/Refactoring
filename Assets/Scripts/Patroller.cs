using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Transform _allPlacespoint;
    [SerializeField] private float _speed;

    private Transform[] _places;
    private int _placeIndex;

    private void Awake()
    {
        _places = new Transform[_allPlacespoint.childCount];

        for (int i = 0; i < _allPlacespoint.childCount; i++)
        {
            _places[i] = _allPlacespoint.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _places[_placeIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            TakerNextPlaceLogic();
        }
    }

    private void TakerNextPlaceLogic()
    {
        _placeIndex++;

        if (_placeIndex == _places.Length)
        {
            _placeIndex = 0;
        }

        transform.forward = _places[_placeIndex].transform.position - transform.position;
    }
}
