using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IdleEarnings : MonoBehaviour
{
    [SerializeField] GameObject idle;
    [SerializeField] TMP_Text earning;
    [SerializeField] TMP_Text time;

    void OnApplicationQuit()
    {
        PlayerPrefs.SetString("ClosedTime", System.DateTime.Now.ToString());

        PlayerPrefs.SetInt("firstenter", 1);
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("firstenter") == 0) idle.SetActive(false);

        if (PlayerPrefs.GetInt("firstenter") == 1)
        {
            string closedTimeString = PlayerPrefs.GetString("ClosedTime", "");
            System.DateTime closedTime = System.DateTime.Parse(closedTimeString);
            System.TimeSpan elapsedTime = System.DateTime.Now - closedTime;

            float speed = 15 - PlayerPrefs.GetFloat("casierspeed");
            float multiplyer = (float)elapsedTime.TotalSeconds / speed;
            int idleEarn = (int)multiplyer * PlayerPrefs.GetInt("coffeeprice");

            idle.SetActive(true);
            earning.text = "You get $" + idleEarn;
            time.text = "You Away " + (int)elapsedTime.TotalSeconds + " Seconds";

            PlayerPrefs.SetInt("cash", PlayerPrefs.GetInt("cash") + idleEarn);
        }
    }

    public void CloseEarning() => idle.SetActive(false);
}
