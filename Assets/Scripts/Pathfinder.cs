using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager)
        {
            grid = gridManager.Grid;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ExploreNeighbors();
    }

    void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();
        foreach(Vector2Int direction in directions)
        {
            if (grid.ContainsKey(currentSearchNode.coordinates + direction))
            {
                neighbors.Add(grid[currentSearchNode.coordinates + direction]);

                grid[currentSearchNode.coordinates + direction].isExplored = true;
                grid[currentSearchNode.coordinates].isPath = true;
            }
        }
    }
}
