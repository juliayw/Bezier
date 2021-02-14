using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SphereMoveInDirection : MonoBehaviour
{
    public VectorCalculator reference;
    public float magnitude;

    void Update()
    {
        transform.position = reference.origin + reference.direction * magnitude;
    }
}
