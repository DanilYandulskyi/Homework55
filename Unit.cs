using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Unit : MonoBehaviour
{
    [SerializeField] private Resource _resource;
    [SerializeField] private Vector3 _initialPosition;
    [SerializeField] private Vector2 _moveDirection;

    private Movement _movement;
    private bool _isResourceCollected = false;

    private void Start()
    {
        _movement = GetComponent<Movement>();
        _initialPosition = transform.position;
    }

    private void Update()
    {
        if (_resource != null)
        {
            _movement.Move(_moveDirection);
        }

        if (_isResourceCollected & Vector2.Distance(transform.position, _initialPosition) < 0.2)
        {
            Map.CollectResource(_resource);
            _movement.Stop();

        }
    }

    public void SetResourse(Resource resource)
    {
        _resource = resource;
        _moveDirection = _resource.transform.position - transform.position;
    }

    public void ChangeMoveDirection()
    {
        _moveDirection = _initialPosition - transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Resource resource))
        {
            _isResourceCollected = true;
            ChangeMoveDirection();
            resource.gameObject.SetActive(false);
        }
    }
}
