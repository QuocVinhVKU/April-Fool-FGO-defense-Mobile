using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public GameObject panelSoundOn;
    public GameObject panelSoundOff;

    private void Start()
    {
        if (PlayerPrefs.GetInt("mute", 0) == 0)
        {
            PressSoundOff();
        }
        else PressSoundOn();
    }
    public void PressSoundOn()
    {
        PlayerPrefs.SetInt("mute", 1);
        AudioListener.volume = 0f;
        panelSoundOn.SetActive(false);
        panelSoundOff.SetActive(true);
    }
    public void PressSoundOff()
    {
        PlayerPrefs.SetInt("mute", 0);
        AudioListener.volume = 1f;
        panelSoundOn.SetActive(true);
        panelSoundOff.SetActive(false);
    }
}

