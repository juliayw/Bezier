using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class BezierContinue : BezierExample
{
    public BezierExample previous;
    public float startHandleMagnitude;
}

#if UNITY_EDITOR
[CustomEditor(typeof(BezierContinue))]
public class BezierContinueEditor : Editor
{
    public void OnSceneGUI()
    {
        BezierContinue bc = target as BezierContinue;

        Vector3 oppositeOfEndTangent = (bc.previous.endPoint - bc.previous.endTangent).normalized;//direction


        bc.startPoint = Handles.PositionHandle(bc.previous.endPoint, Quaternion.identity);
        bc.endPoint = Handles.PositionHandle(bc.endPoint, Quaternion.identity);
        bc.startTangent = Handles.PositionHandle(bc.previous.endPoint + oppositeOfEndTangent * bc.startHandleMagnitude, Quaternion.identity);
        bc.endTangent = Handles.PositionHandle(bc.endTangent, Quaternion.identity);

        Handles.DrawBezier(bc.startPoint, bc.endPoint, bc.startTangent, bc.endTangent, Color.yellow, null, 5f);
    }
}
#endif
