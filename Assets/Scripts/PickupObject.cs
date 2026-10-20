using UnityEngine;

public abstract class PickupObject : MonoBehaviour
{
    [Header("Pickup")]
    [Tooltip("how fast it spins")]
    [SerializeField] private float spinSpeed = 90f;

    [Tooltip("Seconds before it disappears")]
    [SerializeField] private float lifeTime = 10f;

    protected virtual void Start ()
    {
        Destroy(gameObject, lifeTime);
    }
    protected virtual void Update ()
    {
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        OnPickedUp(other.gameObject);
        Destroy(gameObject);
    }

    protected abstract void OnPickedUp(GameObject player);

}
