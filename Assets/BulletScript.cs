using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject towerPrefab;
    
    private void Start()
    {
        Vector3 shootingForce = new Vector3(Random.Range(1, 4), 0, 0);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(shootingForce, ForceMode2D.Impulse);
        rb.velocity = new Vector2(-4, 0);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Tower"))
        {
            Destroy(collision.collider.gameObject);
        }
        Destroy(gameObject);
    }
}
