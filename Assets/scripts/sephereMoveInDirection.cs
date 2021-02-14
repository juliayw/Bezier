using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class sephereMoveInDirection : MonoBehaviour
{
    public VectorCalculator reference;
    public float magnitude; // the length of this vector, square root of (x*x+y*y+z*z)


    void Update()
    {
        transform.position = reference.origin + reference.direction * magnitude;
    }
}
