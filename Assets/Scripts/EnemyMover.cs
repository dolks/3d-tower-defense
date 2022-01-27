using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    // Start is called before the first frame update
    void Start()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(MoveAlongPath());
    }

    void FindPath()
    {
        path.Clear();

        GameObject pathObject = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in pathObject.transform)
        {
            path.Add(child.GetComponent<Waypoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator MoveAlongPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPos = transform.position,
                endPos = waypoint.transform.position;
            float travelPercent = 0;
            transform.LookAt(endPos);
            while (travelPercent < 1)
            {
                travelPercent += Time.deltaTime;
                transform.position = Vector3.Lerp(
                    startPos,
                    endPos,
                    travelPercent
                );
                yield return new WaitForEndOfFrame();
            }
        }
        Destroy(gameObject);
    }

}
