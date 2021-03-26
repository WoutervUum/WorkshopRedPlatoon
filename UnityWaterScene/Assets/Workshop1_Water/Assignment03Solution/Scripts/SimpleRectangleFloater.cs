using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRectangleFloater : MonoBehaviour
{
    public Rigidbody rigidBody;
    public Transform[] pressurePoints;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;
    void FixedUpdate()
    {
        foreach (Transform PressurePoint in pressurePoints)
        {
            rigidBody.AddForceAtPosition(Physics.gravity / pressurePoints.Length, PressurePoint.transform.position, ForceMode.Acceleration);
            float waveHeight = WaveManager.instance.GetWaveHeight(PressurePoint.transform.position.x);
            if (PressurePoint.transform.position.y < waveHeight)
            {
                float displacementMultiplier = Mathf.Clamp01((waveHeight - PressurePoint.transform.position.y) / depthBeforeSubmerged) * displacementAmount;
                rigidBody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), PressurePoint.transform.position, ForceMode.Acceleration);
                rigidBody.AddForce(displacementMultiplier * -rigidBody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
                rigidBody.AddTorque(displacementMultiplier * -rigidBody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
        }
    }
}
