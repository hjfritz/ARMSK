using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnableManager : MonoBehaviour
{
    [SerializeField] private ARRaycastManager m_RaycastManager;

    private List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    [SerializeField] private GameObject spawnablePrefab;

    private Camera arCam;
    private GameObject spawnedGameObject;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnedGameObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        RaycastHit hit;
        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);
        
        if(m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && spawnedGameObject == null)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Spawnable")
                    {
                        spawnedGameObject = hit.collider.gameObject;
                    }
                    else
                    {
                        SpawnPrefab(m_Hits[0].pose.position);
                    }
                }
            }
        }
    }

    private void SpawnPrefab(Vector3 spawnPosition)
    {
        spawnedGameObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
    }
}
