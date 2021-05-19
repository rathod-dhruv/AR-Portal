using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;


public class PlaceOnPlane : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits;

    public GameObject model;
    
    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>(); 
        hits = new List<ARRaycastHit>();
        model.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 0)
            return;
        
        Touch touch = Input.GetTouch(0);

        if(raycastManager.Raycast(touch.position,hits,TrackableType.Planes))
        {
            Pose pose = hits[0].pose;
            if(!model.activeInHierarchy)
            {
                model.SetActive(true);
                model.transform.position = pose.position;
                model.transform.rotation = pose.rotation;
            }
            else
            {
                model.transform.position = pose.position;
                model.transform.rotation = pose.rotation;
            }
        }
        


    }
}
