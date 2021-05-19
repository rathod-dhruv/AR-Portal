
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class PortalTransport : MonoBehaviour
{

    public Material[] materials;
    public Transform device;
    bool wasInFrontOfPortal;
    bool inARWorld;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("In Start");
       SetMaterials(false);
    }

    void SetMaterials(bool fullrender)
    {
        Debug.Log("In Set Materials");
        var stencilTest  = fullrender ? CompareFunction.NotEqual : CompareFunction.Equal;
        
        foreach ( var mat in materials)
        {
            mat.SetInt("_StencilTest", (int)stencilTest);
        }
    }

    bool GetIsInFront()
    {
        Vector3 pos = transform.InverseTransformPoint(device.position);
        bool res=  pos.z >= 0 ? true : false;
        Debug.Log("In GetIsInFront : "+res);
        return res;
    }

    void OnTriggerEnter(Collider other)
    {   
        Debug.Log("In Trigger Enter");
        if(other.transform != device)
            return;
         Debug.Log("In Trigger Enter 2nd Stage");
        wasInFrontOfPortal = GetIsInFront();
        
        
    }

    //using Trigger method because we are using Box Collider Open Unity we have set Box Collider isTrigger true of MainCamera
    void OnTriggerStay(Collider other) {

         Debug.Log("In Trigger Stay 1");
        if(other.transform != device )
            return;

        Debug.Log("In Trigger Stay 2nd Stage");
        bool isInFront = GetIsInFront();
       if((wasInFrontOfPortal && !isInFront) || (!wasInFrontOfPortal && isInFront) )
       {
           inARWorld = !inARWorld;
           SetMaterials(inARWorld);
       }
       wasInFrontOfPortal = isInFront;
        
        
    }

    void OnDestroy()
    {
        Debug.Log("In Destory");
        SetMaterials(true);      
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }





    

// void Start()
//     {
//         foreach ( var mat in materials)
//         {
//             mat.SetInt("_StencilTest", (int)CompareFunction.Equal);
//         }
//     }

//     //using Trigger method because we are using Box Collider Open Unity we have set Box Collider isTrigger true of MainCamera
//     void OnTriggerStay(Collider other) {
//         if(other.name != "Main Camera")
//             return;

//         //Outside the AR World
//         if(transform.position.z >  other.transform.position.z)
//         {
//             foreach ( var mat in materials)
//             {
//                 mat.SetInt("_StencilTest", (int)CompareFunction.Equal);
//             }
//         }

//         //Inside the AR World
//         else
//         {
//             foreach ( var mat in materials)
//             {
//                 mat.SetInt("_StencilTest", (int)CompareFunction.NotEqual);
//             }
//         }
        
        
//     }

//     void OnDestroy()
//     {
//         foreach ( var mat in materials)
//         {
//             mat.SetInt("_StencilTest", (int)CompareFunction.NotEqual);
//         }        
//     }

    
//     // Update is called once per frame
//     void Update()
//     {
        
//     }
}




