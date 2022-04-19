using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    //Waypoint waypoint;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        //waypoint = GetComponentInParent<Waypoint>();
        UpdateLabel();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            UpdateLabel();
        }
        ToggleLabels();
        UpdateColors();
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void UpdateColors()
    {
        if (!gridManager) { return; }
        Node node = gridManager.GetNode(coordinates);
        if (node == null) { return; }
        if (!node.isSearchable)
        {
            label.color = Color.gray;
        }
        else if (node.isPath)
        {
            label.color = new Color(1, 0.5f, 0);
        }
        else if (node.isExplored)
        {
            label.color = Color.yellow;
        }
        else
        {
            label.color = Color.white;
        }
    }


    private void UpdateLabel()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x) / Mathf.RoundToInt(UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z) / Mathf.RoundToInt(UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + "," + coordinates.y;
        transform.parent.name = label.text;
    }
}
