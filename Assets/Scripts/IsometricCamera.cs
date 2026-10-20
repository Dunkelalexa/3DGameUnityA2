using UnityEngine;

public class IsometricCamera : MonoBehaviour     //encapsulation
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(-10f, 10f, -10f);

    private void LateUpdate()                  //runs afters thte player moved in that frame
    {
        transform.position = target.position + offset;
    }
}
