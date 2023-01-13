using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text[] pricesText;
    [SerializeField] int[] prices;
    [SerializeField] TMP_Text coffeePrice;

    [SerializeField] GameObject setting;

    void Start() => FirstUpdate();
    void Update() => UpdatePrices();

    void UpdatePrices()
    {
        for (int i = 0; i < pricesText.Length; i++)
        {
            prices[i] = PlayerPrefs.GetInt("prices" + i);
            pricesText[i].text = "$" + prices[i];
        }
        coffeePrice.text = "$" + PlayerPrefs.GetInt("coffeeprice");
    } 

    public void BuyZero()
    {
        int balance = PlayerPrefs.GetInt("cash") - PlayerPrefs.GetInt("prices0");

        if (PlayerPrefs.GetInt("prices0") > PlayerPrefs.GetInt("cash")) Debug.Log("no money"); //Para az.

        else
        {
            PlayerPrefs.SetInt("cash", balance);
            PlayerPrefs.SetInt("prices0", PlayerPrefs.GetInt("prices0") + PlayerPrefs.GetInt("prices0"));

            PlayerPrefs.SetInt("coffeeprice", PlayerPrefs.GetInt("coffeeprice") + 1);
        }
    }

    public void BuyOne()
    {
        int balance = PlayerPrefs.GetInt("cash") - PlayerPrefs.GetInt("prices1");

        if (PlayerPrefs.GetInt("prices1") > PlayerPrefs.GetInt("cash")) Debug.Log("no money");

        else
        {
            PlayerPrefs.SetInt("cash", balance);
            PlayerPrefs.SetInt("prices1", PlayerPrefs.GetInt("prices1") + PlayerPrefs.GetInt("prices1"));

            PlayerPrefs.SetFloat("casierspeed", PlayerPrefs.GetFloat("casierspeed") + .01f);
        }
    }

    public void BuyzTwo()
    {
        int balance = PlayerPrefs.GetInt("cash") - PlayerPrefs.GetInt("prices2");

        if (PlayerPrefs.GetInt("prices2") > PlayerPrefs.GetInt("cash")) Debug.Log("para az");

        else
        {
            PlayerPrefs.SetInt("cash", balance);
            PlayerPrefs.SetInt("prices2", PlayerPrefs.GetInt("prices2") + PlayerPrefs.GetInt("prices2"));

            PlayerPrefs.SetFloat("speed", PlayerPrefs.GetFloat("speed") + .05f); 
        }
    }

    static void FirstUpdate()
    {
        if (PlayerPrefs.GetInt("coffeeprice") == 0) PlayerPrefs.SetInt("coffeeprice", 1);
        if (PlayerPrefs.GetInt("prices0") == 0) PlayerPrefs.SetInt("prices0", 1);
        if (PlayerPrefs.GetInt("prices1") == 0) PlayerPrefs.SetInt("prices1", 10);
        if (PlayerPrefs.GetInt("prices2") == 0) PlayerPrefs.SetInt("prices2", 20);

        if (PlayerPrefs.GetFloat("casierspeed") == 0) PlayerPrefs.SetFloat("casierspeed", .05f);
        if (PlayerPrefs.GetFloat("speed") == 0) PlayerPrefs.SetFloat("speed", 2);
    }

    public void SettingsCavas() => setting.SetActive(true);
}
