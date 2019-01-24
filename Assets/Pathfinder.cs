using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint start, end;
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    Dictionary <Vector2Int, Waypoint> grid=new Dictionary<Vector2Int, Waypoint>();
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartandEnd();
        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        foreach(Vector2Int direction in  directions)
        {
           Vector2Int explore= (start.GetGridPos() + direction);
            grid[explore].Settopcolour(Color.blue);
        }
    }

    private void ColorStartandEnd()
    {
        start.Settopcolour(Color.magenta);
        end.Settopcolour(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
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
              //  waypoint.Settopcolour(Color.magenta);
            }
            print(grid.Count);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
