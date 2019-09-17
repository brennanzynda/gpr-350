using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceGenerator
{
    // Lab 2 Step 3
    public static Vector2 GenerateForce_Gravity(float particleMass, float gravitationalConstant, Vector2 worldUp)
    {
        // f_gravity: f = mg
        Vector2 f_gravity = particleMass * gravitationalConstant * worldUp;
        return f_gravity;
    }
    
    public static Vector2 GenerateForce_normal(Vector2 f_gravity, Vector2 surfaceNormal_unit)
    {
        // f_normal = proj(f_gravity, surfaceNormal_unit)
        Vector2 f_normal = Vector3.Project(new Vector3(f_gravity.x, f_gravity.y, 0), new Vector3(surfaceNormal_unit.x, surfaceNormal_unit.y, 0));
        return f_normal;
    }
    
    public static Vector2 GenerateForce_sliding(Vector2 f_gravity, Vector2 f_normal)
    {
        // f_sliding = f_gravity + f_normal
        Vector2 f_sliding = f_gravity + f_normal;
        return f_sliding;
    }
    
    Vector2 GenerateForce_friction_static(Vector2 f_normal, Vector2 f_opposing, float frictionCoefficient_static)
    {
        // f_friction_s = -f_opposing if less than max, else -coeff*f_normal (max amount is coeff*|f_normal|)
        float max = f_normal.magnitude * frictionCoefficient_static;
        Vector2 f_friction_s = new Vector2(0,0);
        if (f_opposing.magnitude < max)
        {
            f_friction_s = -f_opposing;
        }
        else
        {
            f_friction_s = -frictionCoefficient_static * f_normal;
        }
        return f_friction_s;
    }
    
    Vector2 GenerateForce_friction_kinetic(Vector2 f_normal, Vector2 particleVelocity, float frictionCoefficient_kinetic)
    {
        // f_friction_k = -coeff*|f_normal| * unit(vel)
        Vector2 f_friction_k = -frictionCoefficient_kinetic * f_normal.magnitude * particleVelocity;
        return f_friction_k;
    }

    Vector2 GenerateForce_drag(Vector2 particleVelocity, Vector2 fluidVelocity, float fluidDensity, float objectArea_crossSection, float objectDragCoefficient)
    {
        // f_drag = (p * u^2 * area * coeff)/2
        float drag = particleVelocity.magnitude * fluidVelocity.magnitude * fluidVelocity.magnitude * objectArea_crossSection * objectDragCoefficient * .5f;
        Vector2 f_drag = drag * particleVelocity.normalized;
        return f_drag;
    }
    Vector2 GenerateForce_spring(Vector2 particlePosition, Vector2 anchorPosition, float springRestingLength, float springStiffnessCoefficient)
    {
        // f_spring = -coeff*(spring length - spring resting length)
        Vector2 springLength = (particlePosition - anchorPosition);
        Vector2 f_spring = -springStiffnessCoefficient * (springLength.magnitude - springRestingLength) * springLength;
        return f_spring;
    }
}
