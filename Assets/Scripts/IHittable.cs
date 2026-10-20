using UnityEngine;

public interface IHittable   //should not have logic
{
    void OnPaintballHit(Color paintballColor, Vector3 hitPoint);
}
