using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager1 : MonoBehaviour
{
    public static WaveManager1 instance;

    public float amplitude = 0.5f;
    public float length = 2f;
    public float speed = 4f;
    private float offset = 0f;
    // Check if no other wave manager exists
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this) 
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;
    }

    public float GetWaveHeight(float _x, float height)
    {
        return (amplitude * Mathf.Sin(_x / length + offset)) + height;
    }
}
