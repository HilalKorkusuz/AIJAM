using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    // Start is called before the first frame update
    public void Startt()
    {
        SceneManager.LoadScene(1); //ba�lama
    }

    public void Exitt()
    {
        Debug.Log("��kt�n");
        Application.Quit();
    }

    public void Credit()
    {
        SceneManager.LoadScene(4); //ba�lama
    }

    public void Restartt()
    {
        SceneManager.LoadScene(1); //yediden basla
    }
    public void Menuu()
    {
        SceneManager.LoadScene(0); //ana men�
    }
}
