using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectSnow : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int health;
    public Text heartText;
    [SerializeField] Image healthBar;
    [SerializeField] GameObject handGun;
    public bool isGun;

    [SerializeField] int bulletCount = 15;
    [SerializeField] Transform shootingPoint;
    [SerializeField] GameObject bulletPrefab;

    bool isPressing;
    [SerializeField] float fireRate = 10f;
    float shootTimer;
    private void Awake()
    {
        CreatePool();
    }
    private void Start()
    {
        maxHealth = 100;
        health = maxHealth;
        heartText.text = health.ToString("");
        isGun = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Snowflake"))
        {
            collision.gameObject.SetActive(false);
            health = health + 20;
            heartText.text = health.ToString("");
        }
        if (collision.gameObject.CompareTag("Tea"))
        {
            health = health - 10;
            heartText.text = health.ToString("");
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Icecream"))
        {
            health = health + 10;
            heartText.text = health.ToString("");
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Gun"))
        {
            collision.gameObject.SetActive(false);
            handGun.SetActive(true);
            isGun=true;
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(3); //kazanma
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Engel"))
        {
            health = health - 50;
            heartText.text = health.ToString("");
        }
        if (collision.collider.CompareTag("Down"))
        {
            SceneManager.LoadScene(2); //kaybetme
        }
    }
    public void Update()
    {

        if(health <= 0)
        {
            SceneManager.LoadScene(2);//kaybetme
        }
        else
        {
            healthBar.fillAmount = (float)health / maxHealth;
            if(isGun)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    isPressing = true;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    isPressing = false;
                }
                shootTimer -= Time.deltaTime;
                if (shootTimer < 0 && isPressing)
                {
                    Shoot();
                }
            }
        }
    }
    public void CreatePool()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject _currentBullet = Instantiate(bulletPrefab);
            _currentBullet.GetComponent<Bullet>().parentObject = shootingPoint;
            _currentBullet.transform.SetParent(shootingPoint);
            _currentBullet.SetActive(false);
        }
    }
    public void Shoot()
    {
        shootTimer = 1f / fireRate;
        GameObject _currentBulelt = shootingPoint.transform.GetChild(0).gameObject;

        _currentBulelt.transform.position = shootingPoint.position;
        _currentBulelt.transform.rotation = shootingPoint.rotation;
        _currentBulelt.transform.SetParent(null);
        //_currentBulelt.transform.localScale = Vector2.one * 0.2f;
        _currentBulelt.SetActive(true);
    }
}