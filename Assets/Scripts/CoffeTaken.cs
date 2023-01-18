using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeTaken : MonoBehaviour
{
    public bool coffeTaken = false;
    [SerializeField] GameObject coffee;

    [SerializeField] GameObject[] character;

    void OnTriggerEnter(Collider other)
    {
        coffeTaken = false;

        if (other.gameObject.name == "4")
        {
            int random = Random.Range(0, character.Length);
            for (int i = 0; i < character.Length; i++) character[i].SetActive(false);
            character[random].SetActive(true);
        }
        
    }
    private void Update()
    {
        if (coffeTaken) coffee.SetActive(true);
        else coffee.SetActive(false);
    }
}
