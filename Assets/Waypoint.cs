﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color color;
    public bool isExplored = false;
    public Waypoint exploredfrom;
    Vector2Int gridpos;
    const int gridsize = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int GetGridSize()
    {
        return gridsize;
    }
    // Update is called once per frame

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x/gridsize),
             Mathf.RoundToInt(transform.position.z/gridsize)  
                     );
    }

    public void Settopcolour(Color color)
    {
        MeshRenderer topmr = transform.Find("Top").GetComponent<MeshRenderer>();
        topmr.material.color = color;

    }

    void Update()
    {
        
    }
}
