using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BezierVis : MonoBehaviour
{
    public Transform Marker0;
    public Transform Marker1;
    public Transform Marker2;

    [Range(0.0f, 1.0f)] public float t;

    public Vector3 A;
    public Vector3 B;
    public Vector3 C;
    public Vector3 D;

    void Update()
    {
        Marker0.position = Vector3.Lerp(A, B, t);
        Marker1.position = Vector3.Lerp(C, D, t);
        Marker2.position = Vector3.Lerp(Marker0.position, Marker1.position,t);
    }
}
