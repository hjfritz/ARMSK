using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{
    [SerializeField] private Transform _arCamera;
    [SerializeField] private GameObject UI;
    
    public GameObject gameObjectToInstantiate;

    private GameObject spawnedObject;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;
    private Vector3 bodyDirection;
    private bool touchable = true;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
        spawnedObject = gameObjectToInstantiate;
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.y > -1800)
            {
                touchPosition = Input.GetTouch(0).position;
                return true;
            }
        }

        touchPosition = default;
        return false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            if (touchable)
            {
                var hitPose = hits[0].pose;

                spawnedObject.transform.position = hitPose.position;
            
                spawnedObject.transform.LookAt(new Vector3(_arCamera.position.x, spawnedObject.transform.position.y, _arCamera.position.z));
            }
        }
    }
}
