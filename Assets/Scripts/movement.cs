using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{

    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private InputAction tap;

    private bool isMoving;
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    private void OnEnable()
    {
        tap.Enable();
    }

    private void OnDisable()
    {
        tap.Disable();
    }

    void Update()
    {
        if (tap.IsPressed())
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed*Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        }
    }
}
