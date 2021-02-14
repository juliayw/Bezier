using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class BezierManager : MonoBehaviour
{
    //public Transform[] controlPoints;  // 所有的点
   // private int currentPoint;   //

    public List<BezierExample> beziers;
    public GameObject bezierPrefab;
    public GameObject bezierContinuePrefab;
    public GameObject bezierEndPrefab;

    public void AddNewBezier()
    {

        if (beziers.Count == 0) {

            beziers.Add(Instantiate(bezierPrefab).GetComponent<BezierExample>());//BezierExample is a monbehaviour, need to attached to a gameobject, so public bezierPrefab
          
        }

        else
        {
            BezierContinue newBC = Instantiate(bezierContinuePrefab).GetComponent<BezierContinue>();
          
            beziers.Add(newBC);

            BezierExample previousOne = beziers[beziers.Count - 2]; //the 2nd item at index 1, previous one 0;
            newBC.previous = previousOne;
        }    
    }



    public void closeLoop() {
        bezierEnd newBE = Instantiate(bezierEndPrefab).GetComponent<bezierEnd>();
          
         beziers.Add(newBE);
        BezierExample previousOne = beziers[beziers.Count - 2];
        
        newBE.previous = previousOne;
        newBE.previousC = beziers[0];


        // int i = beziers.Count-1;

        // beziers[i].endPoint = beziers[0].startPoint;

        // Vector3 oppositeOfEndTangent = (bc.previous.endPoint - bc.previous.endTangent).normalized;//direction

        //Vector3 oppositeOfStartTangent = (beziers[0].startPoint - beziers[0].startTangent).normalized; //the opposite direction
        // beziers[i].endTangent = Handles.PositionHandle(beziers[0].startPoint + oppositeOfStartTangent * endHandleMagnitude, Quaternion.identity);

    }
    

   
}

#if UNITY_EDITOR
[CustomEditor(typeof(BezierManager))]
public class BezierManagerEditor : Editor
{
    public void OnSceneGUI()
    {
        
        BezierManager bm = target as BezierManager;

        for (int i = 0; i < bm.beziers.Count; i++)
        {
            Handles.DrawBezier(bm.beziers[i].startPoint, bm.beziers[i].endPoint, bm.beziers[i].startTangent, bm.beziers[i].endTangent, Color.yellow, null, 5f);

                bm.beziers[i].startPoint = Handles.PositionHandle(bm.beziers[i].startPoint, Quaternion.identity);
               
                bm.beziers[i].endPoint = Handles.PositionHandle(bm.beziers[i].endPoint, Quaternion.identity);
                bm.beziers[i].startTangent = Handles.PositionHandle(bm.beziers[i].startTangent, Quaternion.identity);
                bm.beziers[i].endTangent = Handles.PositionHandle(bm.beziers[i].endTangent, Quaternion.identity);
           
            
        }    //show all the beziers at once
       





    }
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BezierManager bm = target as BezierManager;

        if (GUILayout.Button("Add A New Bezier"))  
        {
            bm.AddNewBezier();
       
        }




      if (GUILayout.Button("Close Loop"))   // click this button, execute all of the code that's in here
        {
        bm.closeLoop(); // close the loop



     }
}

   
}
#endif
