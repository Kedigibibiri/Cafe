using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] Image soundOff;
    [SerializeField] Image soundOn;

    [Header("Music")]
    [SerializeField] Image musicOff;
    [SerializeField] Image musicOn;


    void Start() => BGSoundPreferance();
     
    public void Sound()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            PlayerPrefs.SetInt("sounds", 0);
            soundOn.gameObject.SetActive(true);
            soundOff.gameObject.SetActive(false);
            return;
        }
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            PlayerPrefs.SetInt("sounds", 1);
            soundOn.gameObject.SetActive(false);
            soundOff.gameObject.SetActive(true);
            return;
        }
    }

    public void Music()
    {
        if (PlayerPrefs.GetInt("music") == 1)
        {
            PlayerPrefs.SetInt("music", 0);
            musicOn.gameObject.SetActive(true);
            musicOff.gameObject.SetActive(false);
            return;
        }
        if (PlayerPrefs.GetInt("music") == 0)
        {
            PlayerPrefs.SetInt("music", 1);
            musicOn.gameObject.SetActive(false);
            musicOff.gameObject.SetActive(true);
            return;
        }
    }

    void BGSoundPreferance()
    {
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            soundOn.gameObject.SetActive(true);
            soundOff.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            soundOn.gameObject.SetActive(false);
            soundOff.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("music") == 0)
        {
            musicOn.gameObject.SetActive(true);
            musicOff.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("music") == 1)
        {
            musicOn.gameObject.SetActive(false);
            musicOff.gameObject.SetActive(true);
        }
    }

    public void Close() => gameObject.transform.GetChild(0).gameObject.SetActive(false);
}
