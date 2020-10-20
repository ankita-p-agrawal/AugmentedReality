using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
public class planecontroller : MonoBehaviour
{
    ARPlaneManager arplane;
    public Text ButtonText;
    private void Awake()
    {
        arplane=GetComponent<ARPlaneManager>();
        ButtonText.text="Scan a plane to place the ARPortal and enter into the world of Mahabharata";

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         toggleplanedetection();
        
    }
    public void toggleplanedetection()
    {
        arplane.enabled=!arplane.enabled;
        if(arplane.enabled)
        {
            SetAllPlanesActiveOrDeactive(true);
            GetComponent<PortalPlacer>().enabled=true;
        }
        else
        {
             SetAllPlanesActiveOrDeactive(false);
             GetComponent<PortalPlacer>().enabled=false;
            
        }
    }
    void SetAllPlanesActiveOrDeactive(bool value)
    {
        foreach (var plane in arplane.trackables)
        {
plane.gameObject.SetActive(value);
        }
        
    }
    
}
