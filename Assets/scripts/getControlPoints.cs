using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class getControlPoints : MonoBehaviour
{

       public static List<Vector3> controlPoints = new List<Vector3>();
       //public static Vector3[] controlPoints;
       void Start()
       {
           
           Vector3 p0 = gameObject.GetComponent<BezierExample>().startPoint;    
           Debug.Log("p0" + p0);
           controlPoints.Add(p0);

           //controlPoints.Add(p0);

           Vector3 p1 = gameObject.GetComponent<BezierExample>().endPoint;
           controlPoints.Add(p1);

        //controlPoints.Add(p1);
        // controlPoints[1].transform.position = p1;
        Vector3 p2 = gameObject.GetComponent<BezierExample>().startTangent;
           controlPoints.Add(p2);

        // controlPoints[2].transform.position = p2;
        // controlPoints.Add(p2);
        Vector3 p3 = gameObject.GetComponent<BezierExample>().endTangent;
           controlPoints.Add(p3);

        // controlPoints[3].transform.position = p3;
        //controlPoints.Add(p3);

    }

    // Update is called once per frame
    void Update()
       {


       }



}
