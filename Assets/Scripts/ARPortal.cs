using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine;
[RequireComponent(typeof(ARRaycastManager))]
public class ARPortal : MonoBehaviour
{
    public GameObject gameobjectToInstantiate;
    private GameObject spawnedObject;
    private ARRaycastManager arraycast;
    private Vector2 touchPosition;
    static List<ARRaycastHit> hits=new List<ARRaycastHit>();
    private ARPlaneManager arPlaneManager;
    void Awake()
    {
        arraycast=GetComponent<ARRaycastManager>();
        arPlaneManager=GetComponent<ARPlaneManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        return;
        if(arraycast.Raycast(touchPosition,hits,TrackableType.PlaneWithinPolygon))
        {
var hitPose=hits[0].pose;
if(spawnedObject==null)
{
    spawnedObject=Instantiate(gameobjectToInstantiate,hitPose.position,Quaternion.identity);
   Debug.Log("spannew"+spawnedObject.transform.position.x+" "+spawnedObject.transform.position.y+" "+spawnedObject.transform.position.z);
   Debug.Log("spannew"+Camera.main.transform.position.x+" " +Camera.main.transform.position.y+" "+Camera.main.transform.position.z);
    foreach(ARPlane plane in arPlaneManager.trackables){
      plane.gameObject.SetActive(false);
  //plane.SetTrackablesActive(false);
    }
     arPlaneManager.enabled=false;
}
        }
    }
    
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount>0)
        {
            touchPosition=Input.GetTouch(0).position;
            return true;
        }
        touchPosition=default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        

        }
    
}
