using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewtonRotation : MonoBehaviour
{
    [SerializeField] private Transform newtonBase;
    private bool isDragged = true;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (isDragged)
        {
            Vector3 lookAtPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            newtonBase.LookAt(lookAtPosition);
            
        }
 
    }
}
