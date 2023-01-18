using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Console : MonoBehaviour
{
    [SerializeField] KeyCode cash = KeyCode.P;
    [SerializeField] KeyCode clear = KeyCode.O;

    void Update()
    {
        if (Input.GetKeyUp(cash)) PlayerPrefs.SetInt("cash", PlayerPrefs.GetInt("cash") + 50);

        if (Input.GetKeyUp(clear)) PlayerPrefs.DeleteAll(); 
    }
}
