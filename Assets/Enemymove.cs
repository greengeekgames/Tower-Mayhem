﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemymove : MonoBehaviour
{
    // Start is called before the first frame update

   //[SerializeField] List<Waypoint> path;
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

        IEnumerator FollowPath(List <Waypoint> path)
        {
            print("Starting patrol");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("visiting:" + waypoint);
            yield return new WaitForSeconds(1f);
        }
            print("ending patrol");
        }
    


// Update is called once per frame
//void Update()
//{

//}
}
