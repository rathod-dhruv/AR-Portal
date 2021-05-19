using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class PlaceOnPlane : MonoBehaviour
{
    private ARSessionOrigin sessionOrigin;
    private List<ARRaycastHit> hits;

    public GameObject model;
    // Start is called before the first frame update
    void Start()
    {
        sessionOrigin = GetComponent<ARSessionOrigin>(); 
        hits = new List<ARRaycastHit>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
