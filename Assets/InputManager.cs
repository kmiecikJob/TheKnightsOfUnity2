using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private Camera cam;
    [SerializeField] private float force = 10;
    private Rigidbody2D rb;
    private GameObject target;

    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            target = hit.collider.gameObject;
            rb = target.GetComponent<Rigidbody2D>();
        }

        if (Input.GetMouseButton(0))
        {
            if(target != null)
            {
                Vector2 direction = (Input.mousePosition - target.transform.position).normalized;
                rb.AddForce(direction * force);
            }
            

        }

        if (Input.GetMouseButtonUp(0))
        {
            rb = null;
            target = null;
        }
    }
}
