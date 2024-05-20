using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] int bulletCount;
    [SerializeField] Transform shootingPoint;
    [SerializeField] GameObject bulletPrefab;
    bool isPressing;
    [SerializeField] float fireRate;
    float shootTime;
    [SerializeField] float damage;
   // bool isGunn;
    [SerializeField] GameObject go;

    private void Awake()
    {
        CreatePool();
    }
    void CreatePool()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject _currentBullet = Instantiate(bulletPrefab);
            _currentBullet.GetComponent<Bullet>().parentObject = shootingPoint;
            _currentBullet.transform.SetParent(shootingPoint);
            _currentBullet.SetActive(false);
        }
    }
    void Update()
    {

    }
}
