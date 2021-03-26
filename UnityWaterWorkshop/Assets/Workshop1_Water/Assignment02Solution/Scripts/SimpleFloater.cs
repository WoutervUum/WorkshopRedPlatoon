using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFloater : MonoBehaviour
{
    public Rigidbody rigidBody;

    //How high should the object float over the water
    public float depthBeforeSubmerged = 0f;
    //Increase/Decrease how fast the object should float upwards
    public float displacementAmount = 3f;

    void FixedUpdate()
    {
        //Get WaveHeight of object
        float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
        if (transform.position.y < waveHeight)
        {
            float displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
            rigidBody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
        }
    }
}
