using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle2D : MonoBehaviour
{
    // Lab 1 Step 1
    public Vector2 position, velocity, acceleration;
    public float rotation, angularVelocity, angularAcceleration;
    public bool positionUpdateEuler, positionUpdateKinematic;
    public bool rotationUpdateEuler, rotationUpdateKinematic ;

    // Lab 2 Step 1
    public float startingMass = 1.0f;
    public float mass;
    private float massInv;
    public void SetMass(float newMass)
    {
        // If newMass > 0 then newMass, else 0.0f
        // mass = newMass > 0.0f ? newMass : 0.0f;
        mass = Mathf.Max(0.0f, newMass);
        massInv = mass > 0.0f ? 1.0f / mass : 0.0f;
    }

    // Lab 2 Step 2
    Vector2 force;
    public void AddForce(Vector2 newForce)
    {
        // D'Alembert
        force += newForce;
    }

    void UpdateAcceleration()
    {
        // Newton 2
        acceleration = force * massInv;
        force.Set(0.0f, 0.0f);
    }

    public float GetMass()
    {
        return mass;
    }

    // Lab 1 Step 2
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
        // x(t+dt) = x(t) + v(t)dt + (a(t)dt^2)/2
        position += velocity * dt + (acceleration * dt * dt) / 2;
        velocity += acceleration * dt;
    }

    void updateRotationEulerExplicit(float dt)
    {
        rotation += angularVelocity * dt;
        angularVelocity += angularAcceleration * dt;
    }

    void updateRotationKinematic(float dt)
    {
        rotation += angularVelocity * dt + (angularAcceleration * dt * dt) / 2;
        angularVelocity += angularAcceleration * dt;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ResetUnit()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        angularAcceleration = 0;
        //angularVelocity = 0;
        acceleration = new Vector2(0, 0);
        position = new Vector2(0, 0);
        //velocity = new Vector2(0, 0);
        rotation = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Lab 1 Step 3
        if (positionUpdateEuler)
        {
            updatePositionEulerExplicit(Time.fixedDeltaTime);
            transform.position = position;
        }
        else if(positionUpdateKinematic)
        {
            updatePositionKinematic(Time.fixedDeltaTime);
            transform.position = position;
        }

        else if (rotationUpdateEuler)
        {
            updateRotationEulerExplicit(Time.fixedDeltaTime);
            transform.rotation = Quaternion.Euler(0, 0, rotation);
        }
        else if(rotationUpdateKinematic)
        {
            updateRotationKinematic(Time.fixedDeltaTime);
            transform.rotation = Quaternion.Euler(0,0,rotation);
        }

        // Lab 2 Step 4
        UpdateAcceleration();
        // f_gravity: f = m * g; (g = -9.8)
        //Vector2 f_gravity = mass * new Vector2(0.0f, -9.8f);
        //AddForce(f_gravity);
        AddForce(ForceGenerator.GenerateForce_Gravity(mass, -9.8f, Vector2.up));
        // Lab 1 Step 4
        //acceleration.x = -Mathf.Sin(Time.time);
        //angularVelocity += 2;
    }
}
