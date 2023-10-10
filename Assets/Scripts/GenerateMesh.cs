using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMesh : MonoBehaviour
{
    public MeshFilter meshFilter;

    Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
 
        mesh = new Mesh();
        mesh.vertices = new Vector3[24]{
            new Vector3(0,0,0),
            new Vector3(0,1,0),
            new Vector3(1,0,0),
            new Vector3(1,1,0),

            new Vector3(0,1,0),
            new Vector3(0,1,1),
            new Vector3(1,1,0),
            new Vector3(1,1,1),

            new Vector3(0,0,1),
            new Vector3(0,1,1),
            new Vector3(1,0,1),
            new Vector3(1,1,1),

            new Vector3(0,0,0),
            new Vector3(0,0,1),
            new Vector3(1,0,0),
            new Vector3(1,0,1),

            new Vector3(0,0,1),
            new Vector3(0,1,1),
            new Vector3(0,0,0),
            new Vector3(0,1,0),

            new Vector3(1,0,0),
            new Vector3(1,1,0),
            new Vector3(1,0,1),
            new Vector3(1,1,1),
        };
        mesh.triangles = new int[36]
        {
            0,1,2,
            1,3,2,

            4,5,6,
            5,7,6,

            8,10,9,
            9,10,11,

            12,14,13,
            13,14,15,

            16,17,18,
            17,19,18,

            20,21,22,
            21,23,22
        };

        mesh.uv = new Vector2[24]
        {
            //new Vector2(0,0.5f),
            //new Vector2(0,1f),
            //new Vector2((float)1/3,0.5f),
            //new Vector2((float)1/3,1f),
            //new Vector2((float)2/3,0),
            //new Vector2((float)2/3,0.5f),
            //new Vector2(1,0),
            //new Vector2(1,0.5f),
            new Vector2(0, 0.5f),
            new Vector2(0, 1),
            new Vector2((float)1/3, 0.5f),
            new Vector2((float)1/3, 1f),
            new Vector2((float)1/3, 0.5f),
            new Vector2((float)1/3, 1f),
            new Vector2((float)2/3, 0.5f),
            new Vector2((float)2/3, 1f),
            new Vector2((float)2/3, 0.5f),
            new Vector2((float)2/3, 1f),
            new Vector2(1, 0.5f),
            new Vector2(1, 1f),
            new Vector2(0, 0f),
            new Vector2(0, 0.5f),
            new Vector2((float)1/3, 0f),
            new Vector2((float)1/3, 0.5f),
            new Vector2((float)1/3, 0f),
            new Vector2((float)1/3, 0.5f),
            new Vector2((float)2/3, 0f),
            new Vector2((float)2/3, 0.5f),
            new Vector2((float)2/3, 0f),
            new Vector2((float)2/3, 0.5f),
            new Vector2(1, 0f),
            new Vector2(1, 0.5f),
        };

        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
