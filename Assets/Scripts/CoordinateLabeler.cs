using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        UpdateLabel();
    }

    // Update is called once per frame
    void Update()
    {
       if (!Application.isPlaying)
        {
            UpdateLabel();
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