using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _minXPoint;
    [SerializeField] private Transform _maxXPoint;

    private float _speedForward;
    private float _speedStrafe;
    private Vector3 movmentDirection;
    private Vector3 strafeDirection;
    private bool pause = true;

    public void SetPause(bool value)
    {
        pause = value;
    }

    void Start()
    {
        _speedForward = 10;
        _speedStrafe = 30;
    }


    void Update()
    {
        if (!pause)
        {
            movmentDirection = Vector3.forward;
            transform.Translate(movmentDirection * _speedForward * Time.deltaTime);
            AndroidControlStrafeDirection();
            WindowsControlStrafeDirection();
            transform.Translate(strafeDirection * _speedStrafe * Time.deltaTime);

            if (transform.position.x > _maxXPoint.position.x)
            {
                Vector3 newPosition = transform.position;
                newPosition.x = _maxXPoint.position.x;
                transform.position = newPosition;
            }
            if (transform.position.x < _minXPoint.position.x)
            {
                Vector3 newPosition = transform.position;
                newPosition.x = _minXPoint.position.x;
                transform.position = newPosition;
            }
        }
    }

    private void AndroidControlStrafeDirection()
    {
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = _camera.ScreenPointToRay(touch.position);

            if (Physics.Raycast(ray))
            {
                strafeDirection = ray.direction;
                strafeDirection.y = 0;
                strafeDirection.z = 0;
            }
        }
        else if (Input.touchCount == 0)
        {
            strafeDirection = Vector3.zero;
        }
#endif
    }
    private void WindowsControlStrafeDirection()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray))
            {
                strafeDirection = ray.direction;
                strafeDirection.y = 0;
                strafeDirection.z = 0;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            strafeDirection = Vector3.zero;
        }
#endif
    }
}
