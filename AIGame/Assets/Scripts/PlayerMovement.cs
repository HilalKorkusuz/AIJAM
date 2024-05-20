using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public AudioClip AudioClip;
    // Hareket H�z�
    public float speed = 5f;

    // Z�plama Y�ksekli�i
    public float jumpHeight = 8f;

    // Karakter Kinemati�i
    private Rigidbody2D rb;

    // Z�plama Durumu
    private bool isGrounded;

    //[SerializeField] float speedtimer;

    //[SerializeField] float speedLifeTime = 5f;

    // Start fonksiyonu
    void Start()
    {
        // Karakterin Rigidbody2D bile�enini al
        rb = GetComponent<Rigidbody2D>();

    }

    // Update fonksiyonu
    void Update()
    {

        // Hareket y�n�n� hesapla
        float horizontalInput = Input.GetAxis("Horizontal");

        // X ekseninde h�z� belirle
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Z�plama
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            isGrounded = false;
        }
    }

    // OnCollisionEnter2D fonksiyonu
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Zemine temas etti�inde isGrounded'u true olarak ayarla
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Speeder"))
        {
            collision.gameObject.SetActive(false);
            speed = 15f;
        }
        if(collision.CompareTag(("Slower")))
        {
            collision.gameObject.SetActive(false);
            speed = 3f;
        }
    }
}