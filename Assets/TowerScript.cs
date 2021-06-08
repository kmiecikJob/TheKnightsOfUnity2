using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    private Transform towerPosition;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject bulletPrefab;
    private int counter, maxBullets;
    private SpriteRenderer rendererMat;
    [SerializeField] private Color deactivateColor;
    void Start()
    {
        counter = 0;
        maxBullets = 12;
        towerPosition = transform;
        InvokeRepeating("RandomTowerRotation", 0, 0.5f);
        rendererMat = GetComponent<SpriteRenderer>();
    }

    private void RandomTowerRotation()
    {
        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(15, 45));
        towerPosition.rotation = randomRotation;
        Shoot();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        ++counter;
        if(counter >= maxBullets)
        {
            CancelInvoke("RandomTowerRotation");
            rendererMat.color = deactivateColor;
        }
    }
}
