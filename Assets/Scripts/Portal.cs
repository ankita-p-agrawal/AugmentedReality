using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class Portal : MonoBehaviour
{
    public Material[] materials;
    private AudioSource audio;
    private bool au;
    void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
         audio=GetComponent<AudioSource>();
        foreach(var mat in materials)
            {
                Debug.Log(mat.GetInt("stest"));
                mat.SetInt("stest",(int)CompareFunction.Equal);
            }
            Debug.Log("outside the world and set to equal");
    }
void OnDestroy()
    {
          foreach (var mat in materials)
           {
               mat.SetInt("stest",(int)CompareFunction.NotEqual);
           }
    }
    // Update is called once per frame
    void Update()
    {

if(au==true)
audio.Play();

  
        
    }
    private void OnTriggerStay(Collider collider)
    {
        Debug.Log("Camera position"+collider.transform.position.z);
        Debug.Log("Transform position"+transform.position.z+" "+transform.name);
        if(collider.tag!="MainCamera")
        return;
        if(transform.position.z>collider.transform.position.z)
        {
          
           
            foreach(var mat in materials)
            {
                mat.SetInt("stest",(int)CompareFunction.Equal);
            }
        }
        else 
        {
            Debug.Log("inside");
            au=true;
            foreach(var mat in materials)
            {
                mat.SetInt("stest",(int)CompareFunction.NotEqual);
            }
        }
    }
}
