using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;
public class PortalPlacer : MonoBehaviour
{
    ARRaycastManager arraycast;
    List<ARRaycastHit> hits=new List<ARRaycastHit>();
    public GameObject portalprefab;
    private GameObject spawnedportal;
    void Awake()
    {
        arraycast=GetComponent<ARRaycastManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {
            Touch touch=Input.GetTouch(0);
            if(arraycast.Raycast(touch.position,hits,UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
            {
                  Pose pose=hits[0].pose;
if(spawnedportal==null)
{
    spawnedportal=Instantiate(portalprefab,pose.position,Quaternion.Euler(0,0,0));
    var rotationofportal=spawnedportal.transform.rotation.eulerAngles;
    spawnedportal.transform.eulerAngles=new Vector3(rotationofportal.x,Camera.main.transform.rotation.eulerAngles.y,rotationofportal.z);
}

else
{
    spawnedportal.transform.position=pose.position;
    var rotationofportal=spawnedportal.transform.rotation.eulerAngles;
    spawnedportal.transform.eulerAngles=new Vector3(rotationofportal.x,Camera.main.transform.rotation.eulerAngles.y,rotationofportal.z);
}

            }

        }
        
    }
}
