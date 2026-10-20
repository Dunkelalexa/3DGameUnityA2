using UnityEngine;

public class ChasingTarget : Target                                             //Inheritance
{
    [Header("Chase")]
    [Tooltip("How fast chases the player")]
    [SerializeField] private float chaseSpeed = 2f;

    [Header("Attack")]
    [Tooltip("How much damage does to the player")]
    [SerializeField] private int damage = 10;

    private Transform _player;

    protected override void Awake()
    {
        base.Awake();

        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    protected override void Move()                                              //Polymorphism, inherits the move from parent but adds on its own movement
    {
        Vector3 targetPosition = _player.position;
        targetPosition.y =  transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, chaseSpeed* Time.deltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        IDamageable damageable = collision.collider.GetComponent<IDamageable>();        //Interface
        if (damageable != null) 
        {
            damageable.TakeDamage(damage);
        }
    }
}
