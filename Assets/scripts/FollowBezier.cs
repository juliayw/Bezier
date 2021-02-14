using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBezier : MonoBehaviour
{
    //[SerializeField] private GameObject ControlPoints;

    // [SerializeField] public Transform[] beziers;

    //[SerializeField]
    [SerializeField] public List<Vector3> beziers = new List<Vector3>();

    private int CurrentBezier;
    private float t;
    private Vector3 objectPosition;
    public float Objectspeed;
    private bool coroutineAllowed; //not to run one more coroutine while one is running
    private bool AddListAllowed;
    //public GameObject ControlPointsPrefab;
    //public GameObject bezierExample;


    public void Start()
    {
        CurrentBezier = 0;
        t = 0;
        Objectspeed = 1f;
        coroutineAllowed = true;
        AddListAllowed = true;
        // Instantiate(ControlPointsPrefab, bezierExample. , Quaternion.identity));
        

    }

    public void Update()
    {
        if (AddListAllowed) {
            AddListAllowed = false;
            beziers = getControlPoints.controlPoints;
            print("list to list");
        }
        if (coroutineAllowed) {
            
            StartCoroutine(followTheCurve(CurrentBezier));
   
        }
     

    }
        //private IEnumerator AddToList() {
    
        // yield return new WaitForSeconds(2);
        // beziers.AddRange(getControlPoints.controlPoints);
      
        
   // }


        private IEnumerator followTheCurve(int BezierNumber) {

        coroutineAllowed = false;
        /*Vector3 p0 = beziers[BezierNumber].GetChild(0).position;
        Vector3 p1 = beziers[BezierNumber].GetChild(1).position;
        Vector3 p2 = beziers[BezierNumber].GetChild(2).position;
        Vector3 p3 = beziers[BezierNumber].GetChild(3).position;*/

        Debug.Log(beziers.Count);
        Vector3 p0 = beziers[0];
        Vector3 p1 = beziers[1];
        Vector3 p2 = beziers[2];
        Vector3 p3 = beziers[3];
        
        while (t < 1) {
            t += Time.deltaTime * Objectspeed;

            objectPosition = Mathf.Pow(1 - t, 3) * p0 + 3
                                * Mathf.Pow(1 - t, 2) * t * p1 + 3
                                * (1 - t) * Mathf.Pow(t, 2) * p2
                                + Mathf.Pow(t, 3) * p3; //the explicit form of the curve

            transform.position = objectPosition; // give the calculated position to the object

            yield return new WaitForEndOfFrame();
        }

        t = 0f; //next coroutine will start from p0 start point

        CurrentBezier += 1; // go along next curve
       // if (CurrentBezier > beziers.Length - 1)
          if (CurrentBezier > beziers.Count - 1)
            CurrentBezier = 0;

        coroutineAllowed = true;
    }
}