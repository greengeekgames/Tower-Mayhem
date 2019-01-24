using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary <Vector2Int, waypoint> grid=new Dictionary<Vector2Int,waypoint>();
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();

    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {            
            bool isOverlap = grid.ContainsKey(waypoint.GetGridPos());
            if(isOverlap)
            {
                Debug.LogWarning("Skipping overlapping block" + waypoint);

            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
            print(grid.Count);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
