using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;

    private Rigidbody _rb;
    private Camera _camera;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        _rb.mass = 1f;
        _rb.interpolation = RigidbodyInterpolation.Interpolate;

        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 forward = _camera.transform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = _camera.transform.right;
        right.y = 0f;
        right.Normalize();

        Vector3 move = (forward * vertical + right * horizontal).normalized;
        Vector3 targetVelocity = move * moveSpeed;

        targetVelocity.y = _rb.linearVelocity.y;
        _rb.linearVelocity = targetVelocity;

        if (move != Vector3.zero) 
        {
            transform.rotation = Quaternion.LookRotation(move);
        }

    }


}
