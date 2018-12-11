using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class EditSnap : MonoBehaviour
{
  

    [SerializeField] [Range(0f, 20f)] float gridsize = 10f;
    TextMesh textmesh;
    void Update()
    {
        Vector3 snappos;
        snappos.x = Mathf.RoundToInt(transform.position.x / gridsize) * 10f;
        snappos.z = Mathf.RoundToInt(transform.position.z / gridsize) * 10f;

        transform.position = new Vector3(snappos.x, 0f, snappos.z);

        textmesh = GetComponentInChildren<TextMesh>();
        string label= "(" + snappos.x/10 + "," + snappos.z/10 + ")";
        textmesh.text = label;
        gameObject.name = label;
    }
}
