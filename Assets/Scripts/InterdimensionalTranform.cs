using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class InterdimensionalTranform : MonoBehaviour
{
    // Start is called before the first frame update
    public Material[] materials;
    public AudioSource audio;

    void Start()
    {
        audio=GetComponent<AudioSource>();
        Debug.Log("in the start of interdimensional transform");
        foreach (var mat in materials)
           {
               mat.SetInt("_StencilTest",(int)CompareFunction.Equal);
           }
        
    }
    void OnTriggerStay(Collider other)
    {
           
           Debug.Log("the camera name is"+other.name);
        if(other.name!="AR Camera")
        {
            Debug.Log("Other camera");
        return;
        }
        if(transform.position.z>other.transform.position.z)
        {
            audio.Play();
            Debug.Log("outside of other world");
           foreach (var mat in materials)
           {
               mat.SetInt("_StencilTest",(int)CompareFunction.Equal);
           }
           

        }
        else
        {
            Debug.Log("inside of other world");
            foreach (var mat in materials)
           {
               mat.SetInt("_StencilTest",(int)CompareFunction.NotEqual);
           }
        }

    }
    void Destroy()
    {
          foreach (var mat in materials)
           {
               mat.SetInt("_StencilTest",(int)CompareFunction.NotEqual);
           }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
