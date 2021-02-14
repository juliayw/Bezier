using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class bezierEnd : BezierContinue { 

    public BezierExample previousC;  
    public float endHandleMagnitude;
}

#if UNITY_EDITOR
[CustomEditor(typeof(bezierEnd))]
public class BezierEndEditor : Editor
{
    public void OnSceneGUI()
    {
        bezierEnd be = target as bezierEnd;

        Vector3 oppositeOfStartTangent = (be.previousC.startPoint - be.previousC.startTangent).normalized;
        Vector3 oppositeOfEndTangent = (be.previous.endPoint - be.previous.endTangent).normalized;//direction
        

        be.startPoint = Handles.PositionHandle(be.previous.endPoint, Quaternion.identity);
        be.endPoint = Handles.PositionHandle(be.previousC.startPoint, Quaternion.identity);
        be.startTangent = Handles.PositionHandle(be.previous.endPoint + oppositeOfEndTangent * be.startHandleMagnitude, Quaternion.identity);
       // be.endTangent = Handles.PositionHandle(be.endTangent, Quaternion.identity);
        be.endTangent = Handles.PositionHandle(be.previousC.startPoint + oppositeOfStartTangent* be.endHandleMagnitude, Quaternion.identity);

        Handles.DrawBezier(be.startPoint, be.endPoint, be.startTangent, be.endTangent, Color.yellow, null, 5f);
    }
}
#endif

