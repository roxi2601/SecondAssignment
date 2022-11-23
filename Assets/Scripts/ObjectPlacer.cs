using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private ARRaycastManager ARRaycastManager;
    [SerializeField]
    private GameObject objectToPlace;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount <= 0) return;
        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began) return;
        if (!ARRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon)) return;
        var hitpose = hits[0].pose;
        Instantiate(objectToPlace, hitpose.position, hitpose.rotation);
    }
}
