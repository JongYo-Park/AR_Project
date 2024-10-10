using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObject : MonoBehaviour
{
    [SerializeField] GameObject cameraPrefab;
    [SerializeField] GameObject laptopPrefab;
    [SerializeField] ARRaycastManager arRaycastManager;
    [SerializeField] GameObject spawnedObject;

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved && spawnedObject != null)
            {
                RotateObject(touch.deltaPosition);
            }
        }
    }

    public void PlaceCamera()
    {
        PlacePrefab(cameraPrefab);
    }

    public void PlaceLaptop()
    {
        PlacePrefab(laptopPrefab);
    }

    private void PlacePrefab(GameObject prefab)
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawnedObject != null)
            {
                Destroy(spawnedObject);
            }

            spawnedObject = Instantiate(prefab, hitPose.position, hitPose.rotation);
        }
    }
    
    private void RotateObject(Vector2 deltaPosition)
    {
        float rotationSpeed = 0.1f;
        float rotationX = deltaPosition.y * rotationSpeed;
        float rotationY = -deltaPosition.x * rotationSpeed;

        spawnedObject.transform.Rotate(rotationX, rotationY, 0);
    }
}

