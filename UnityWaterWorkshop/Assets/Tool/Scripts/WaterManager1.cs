﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Require the object to have these things
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WaterManager1 : MonoBehaviour
{
    private MeshFilter meshFilter;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    private void Update()
    {
        Vector3[] vertices = meshFilter.mesh.vertices;
        for (int i = 0; i < vertices.Length; ++i)
        {
            vertices[i].y = WaveManager1.instance.GetWaveHeight(transform.position.x + vertices[i].x, 0f);
        }

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateNormals();
    }
}
