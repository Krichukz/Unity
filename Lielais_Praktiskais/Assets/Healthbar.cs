using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{
    public Image CurrentHp;
    public Text RatioText;
    private float hitpoints = 150;
    private float maxHitpoints = 150;
    public DeathMenu deathMenu;



    private void Start()
    {
        UpdateHealthbar();
    }
    private void UpdateHealthbar()
    {
        float ratio = hitpoints / maxHitpoints;
        CurrentHp.rectTransform.localScale = new Vector3(ratio, 1, 1);
        RatioText.text = (100 * ratio).ToString("0" ) + '%' ;
    }
    private void TakeDamage(float damage)
    {
        hitpoints -= damage;
        if (hitpoints <0)
        {
            Application.LoadLevel("death");
            hitpoints = 0;
            Debug.Log(" dead!");
          
        }

        UpdateHealthbar();
    }

    private void HealDamage(float heal)
    {
        hitpoints += heal;
        if (hitpoints > maxHitpoints)
        {
            hitpoints = maxHitpoints;
            Debug.Log(" Healing");
        }
        UpdateHealthbar();
    }




}
