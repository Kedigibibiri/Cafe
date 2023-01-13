using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmusic : MonoBehaviour
{
    public AudioSource[] sounds;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1) Destroy(this.gameObject); 
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("sound") == 0 && !sounds[0].isPlaying) sounds[0].Play();
        if (PlayerPrefs.GetInt("sound") == 1) sounds[0].Stop();

        if (PlayerPrefs.GetInt("music") == 0 && !sounds[1].isPlaying) sounds[0].Play();
        if (PlayerPrefs.GetInt("music") == 1) sounds[1].Stop();
    }
}