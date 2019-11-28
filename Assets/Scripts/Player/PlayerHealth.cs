using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int healthValue = 100;
    private Slider _healthSlider;
    private GameObject _uiHolder;
    // Start is called before the first frame update
    void Start()
    {
        _healthSlider = GameObject.Find("HealthBar").GetComponent<Slider>();
        _healthSlider.value = healthValue;
        _uiHolder = GameObject.Find("UI Holder");
    }

    public void Damage(int damageAmount)
    {
        healthValue -= damageAmount;
        if(healthValue < 0)
        {
            healthValue = 0;
        }

        _healthSlider.value = healthValue;

        if(healthValue == 0)
        {
            _uiHolder.SetActive(false);
            GameplayController.instance.GameOver();
        }
    }
}
