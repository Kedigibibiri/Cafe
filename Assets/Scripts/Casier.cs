using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Casier : MonoBehaviour
{
    [Header("Customer")]
    [SerializeField] bool filler = false;
    [SerializeField] bool customerHere = true;
    [SerializeField] float casierSpeed;

    [Header("Coffee")]
    [SerializeField] Slider coffee;

    [Header("Money")]
    [SerializeField] TMP_Text cash;
    [SerializeField] GameObject money;
    [SerializeField] Transform moneyPlace;
    bool moneytaken = false;

    void Update()
    {
        cash.text = "$" + PlayerPrefs.GetInt("cash");
        casierSpeed = PlayerPrefs.GetFloat("casierspeed");
    }

    void OnTriggerStay(Collider other)
    {
        if (coffee.value < 1)
        {
            StartCoroutine(CoffeeFiller());
        }
        if (coffee.value == 1)
        {
            StopCoroutine(CoffeeFiller());
            StartCoroutine(TakeCoffee(other.gameObject));
        }
    }

    void OnTriggerEnter(Collider other) => filler = false; 

    void OnTriggerExit(Collider other)
    {
        filler = false;
        coffee.value = 0;
        customerHere = true;
        moneytaken = false;
    }

    IEnumerator CoffeeFiller()
    {
        if (customerHere)
        {
            customerHere = false;
            yield return new WaitForSeconds(.9f);
            filler = true;
        }
        if (filler)
        {
            filler = false;
            coffee.value += casierSpeed;
            yield return new WaitForSeconds(.5f);
            filler = true;
        }
    }

    IEnumerator TakeCoffee(GameObject other)
    {
        if (!moneytaken)
        {
            moneytaken = true;
            Instantiate(money, moneyPlace.position, Quaternion.identity, moneyPlace);
            yield return new WaitForSeconds(.3f);
            PlayerPrefs.SetInt("cash", PlayerPrefs.GetInt("cash") + PlayerPrefs.GetInt("coffeeprice"));

            Transform hand = other.gameObject.transform.GetChild(0);
            hand.gameObject.SetActive(true);
            yield return new WaitForSeconds(.3f);
            other.GetComponent<CoffeTaken>().coffeTaken = true;
        }
    }
}
