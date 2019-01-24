using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]

public class EditSnap : MonoBehaviour
{
    
    Vector3 snappos;
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        Snaptopos();
        updatelabel();
    }

    private void updatelabel()
    {
        int gridsize = waypoint.GetGridSize();
        TextMesh textmesh = GetComponentInChildren<TextMesh>();
        string label = "(" + waypoint.GetGridPos().x/ gridsize *10+ "," + waypoint.GetGridPos().y/ gridsize*10 + ")";
        textmesh.text = label;
        gameObject.name = label;
    }

    private void Snaptopos()
    {

        int gridsize = waypoint.GetGridSize();
       // snappos.x = Mathf.RoundToInt(transform.position.x / gridsize) * 10f;
       // snappos.z = Mathf.RoundToInt(transform.position.z / gridsize) * 10f;

        transform.position = new Vector3(waypoint.GetGridPos().x*10, 0f, waypoint.GetGridPos().y*10);
        
    }
}
