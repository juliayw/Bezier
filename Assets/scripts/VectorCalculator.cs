using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class VectorCalculator : MonoBehaviour
{
    public Vector3 A;
    public Vector3 B;

    public Vector3 origin;
    public Vector3 direction;

    void Update()
    {
        Debug.DrawLine(A, B, Color.red);

        origin = A;
        direction = (B - A).normalized; //describ this direction as unit vector
    }
}
