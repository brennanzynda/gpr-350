using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle2D : MonoBehaviour
{
    // Step 1
    public Vector2 position, velocity, acceleration;
    public float rotation, angularVelocity, angularAcceleration;

    // Step 2
    void updatePositionEulerExplicit(float dt)
    {
        // x(t+dt) = x(t) + v(t)dt
        // Euler's method:
        // F(t+dt) = F(t) + f(t)dt
        //                + (dF/dt)dt
        position += velocity * dt;

        // v(t+dt) = v(t) + a(t)dt
        velocity += acceleration * dt;
    }

    void updatePositionKinematic(float dt)
    {
    }

    void updateRotationEulerExplicit(float dt)
    {
    }

    void updateRotationKinematic(float dt)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Step 3
        updatePositionEulerExplicit(Time.fixedDeltaTime);
        transform.position = position;

        // Step 4
        acceleration.x = -Mathf.Sin(Time.time);
    }
}
