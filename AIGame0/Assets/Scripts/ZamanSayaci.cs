using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZamanSayaci : MonoBehaviour
{
    public float totalTime = 120f;
    public float kalanZaman;

    public Text kalanZamanText;

    public bool stopped = false;
    [SerializeField] Image timeBar;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KumSaati"))
        {
            collision.gameObject.SetActive(false);
            AddTime();
        }
    }
    void Start()
    {
        kalanZaman = totalTime;
        kalanZamanText.text = kalanZaman.ToString("00.00");
        stopped = false;
    }
    void Update()
    {
        if (!stopped)
        {
            kalanZaman -= Time.deltaTime;
            int saniyeler = (int)(kalanZaman % 60f);
            int dakikalar = (int)(kalanZaman / 60f);
            timeBar.fillAmount = (float)kalanZaman / totalTime;

            if (saniyeler == 60)
            {
                saniyeler = 0;
                dakikalar++;
            }

            kalanZamanText.text = dakikalar.ToString("00") + "." + saniyeler.ToString("00");

        }
        if (kalanZaman <= 0)
        {
            SceneManager.LoadScene(2);//kaybetme
        }
    }
    public void MinusTime()
    {
        kalanZaman -= 10f;
    }
    public void AddTime()
    {
        kalanZaman += 10f;
    }
}
