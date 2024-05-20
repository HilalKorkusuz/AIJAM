using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] float speed;
    public Transform parentObject;

    float timer;
    [SerializeField] float bulletLifeTime = 5f;

    public int damage;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        timer = bulletLifeTime;
        ZamanSayaci zamanSayaci = GameObject.Find("Snowman").GetComponent<ZamanSayaci>();
        zamanSayaci.MinusTime();
    }

    void DestroyBullet()
    {
        gameObject.SetActive(false);
        transform.parent = parentObject;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag("Player"))
        {

            DestroyBullet();
            if (collision.transform.TryGetComponent<EnemyHealth>(out EnemyHealth _enemy))
            {
                _enemy.GetDamage(damage);
            }
        }
    }
    private void Update()
    {
        rb.velocity = transform.right * speed;

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            DestroyBullet();
        }
    }
}
