using UnityEngine;

public class PointPickup : PickupObject
{
    [Header("Points")]
    [SerializeField] private int points = 5;

    protected override void OnPickedUp(GameObject player)
    {
        GameManager.Instance.IncreaseScoreAndUpdateUI(points);

    }
}
