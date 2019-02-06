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
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] bool isRunning = true;
    Waypoint searchcentre;
    List<Waypoint> path = new List<Waypoint>();
    // Start is called before the first frame update

    void Start()
    {
      // GetPath();
    }

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            Calculatepath();
        }
        return path;
    }

    private void Calculatepath()
    {
        LoadBlocks();
        ColorStartandEnd();
        //ExploreNeighbours();
        BFS();
        CreatePath();
    }

    private void BFS()
    {
        queue.Enqueue(start);
        while(queue.Count>0)
        {
            searchcentre = queue.Dequeue();
            //  print("searching from: " + searchcentre);
            haltifendfound();
            ExploreNeighbours(searchcentre);
            searchcentre.isExplored = true;
        }
        print("Finished pathfinding");
    }

    private void CreatePath()
    {
        setaspath(end);
        Waypoint previous = end.exploredfrom;
        while (previous != start)
        {
            previous = previous.exploredfrom;
            //path.Add(previous);
            setaspath(previous);
            //previous.isplaceable = false;
            
        }

        //path.Add(start);
        //start.isplaceable = false;
        setaspath(start);
        path.Reverse();
    }

    private void setaspath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isplaceable = false;
    }

    private void haltifendfound()//Waypoint searchcentre)
    {
        if(searchcentre==end)
        {
           // print("searching from end hence stopping");
            isRunning = false;
        }
    }

    private void ExploreNeighbours(Waypoint from)
    {
        if (!isRunning)
            return;
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explore = (from.GetGridPos() + direction);
            if (grid.ContainsKey(explore))
            {
                {
                    queuenewneighbour(explore);
                }
            }
        }
    }
    private void queuenewneighbour(Vector2Int explore)
    {
        Waypoint neighbour = grid[explore];
        if (neighbour.isExplored || queue.Contains(neighbour))
        { }
        else
        {
           // neighbour.Settopcolour(Color.blue);
            queue.Enqueue(neighbour);
            print("Queuing" + neighbour);
            neighbour.exploredfrom = searchcentre;
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

