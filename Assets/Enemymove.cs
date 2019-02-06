using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemymove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float movementperiod = .5f;
    [SerializeField] ParticleSystem goalparticle;
    //[SerializeField] List<Waypoint> path;
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("visiting:" + waypoint);
            yield return new WaitForSeconds(movementperiod);
        }
        //print("ending patrol");
        SelfDestruct();
    }


    private void SelfDestruct()
    {
        var vfx = Instantiate(goalparticle, transform.position, Quaternion.identity);
        vfx.Play();
        float destroydelay = vfx.main.duration;
        Destroy(vfx.gameObject, destroydelay);
        Destroy(gameObject);
    }

}