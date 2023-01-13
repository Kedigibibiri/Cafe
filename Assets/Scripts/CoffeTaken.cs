using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeTaken : MonoBehaviour
{
    public bool coffeTaken = false;
    [SerializeField] GameObject coffee;

    void OnTriggerEnter(Collider other)
    {
        coffeTaken = false;
    }
    private void Update()
    {
        if (coffeTaken) coffee.SetActive(true);
        else coffee.SetActive(false);
    }
}
