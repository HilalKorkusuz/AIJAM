using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;

    [SerializeField] Image enemyHealthBar;

    private void Start()
    {
        enemyHealthBar.fillAmount = (float)health / maxHealth;
    }
    public void GetDamage(int _damage)
    {
        health -= _damage;
        enemyHealthBar.fillAmount = (float)health / maxHealth;
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    
}
