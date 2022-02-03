using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] Tower tower;

    public bool IsPlaceable{ get { return isPlaceable; } }

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool placed = tower.Place(tower, transform.position);
            isPlaceable = !placed;
        }
    }
}
