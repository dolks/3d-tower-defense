using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Tile> path = new List<Tile>();
    Enemy enemy;
    // Start is called before the first frame update
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        if (path.Count > 0) { StartCoroutine(MoveAlongPath()); }
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject pathObject = GameObject.FindGameObjectWithTag("Path");
        if (pathObject == null) { return; }
        foreach (Transform child in pathObject.transform)
        {
            path.Add(child.GetComponent<Tile>());
        }
    }

    void ReturnToStart()
    {
        if (path.Count == 0) { return; }
        transform.position = path[0].transform.position;
    }

    IEnumerator MoveAlongPath()
    {
        foreach (Tile Tile in path)
        {
            Vector3 startPos = transform.position,
                endPos = Tile.transform.position;
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
        enemy.StealGold();
        gameObject.SetActive(false);
    }

}
