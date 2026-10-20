using UnityEngine;

public class HealthPickup : PickupObject
{
    [Header("Heal")]
    [SerializeField] private int healAmount = 20;

    protected override void OnPickedUp(GameObject player)
    {
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health != null) 
        {
            health.Heal(healAmount);
        }
    }
}
