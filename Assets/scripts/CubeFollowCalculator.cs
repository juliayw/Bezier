using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeFollowCalculator : MonoBehaviour
{
    public VectorCalculator calcWithValues;
    [Range(0f, 1f)] public float t;

    void Update()
    {
        transform.position = Vector3.Lerp(calcWithValues.A, calcWithValues.B, t);
    }
}
