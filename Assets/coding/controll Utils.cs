using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class controllUtils : MonoBehaviour
{
    public audio[] audios;
    public Animator mask;
    public Button music;
    public Button sound;
    public AudioSource[] sources;
    public Sprite[] sprites;
    public static controllUtils utils;
    bool btSound, btmusic, btsetting;

    private void Awake()
    {
        if (utils == null)
            utils = this;
        else Destroy(gameObject);
    }

    public void playToggle(string name, int i)
    {
        audio a = Array.Find(audios, x => x.name == name);
        if (a == null) Debug.Log("sound not found");
        else
        {
            sources[i].clip = a.clip;
            sources[i].Play();
        }
    }

    public void musicOn()
    {
        btmusic = !btmusic;
        if (btmusic)
        {
            music.image.sprite = sprites[1];
            sources[0].Play();
            sources[0].mute = true;
        }
        else if (!btmusic)
        {
            music.image.sprite = sprites[0];
            sources[0].Play();
            sources[0].mute = false;
        }
    }

    public void soundOn()
    {
        btSound = !btSound;
        if (btSound)
        {
            sound.image.sprite = sprites[3];
            sources[2].Play();
            sources[2].mute = true;
        }
        else if (!btmusic)
        {
            sound.image.sprite = sprites[2];
            sources[2].Play();
            sources[2].mute = false;
        }
    }

    public void setting()
    {
        btsetting = !btsetting;
        if (btsetting)
        {
            mask.Play("mask");
        }else if (!btsetting)
        {
            mask.Play("maskoff");
        }
    }
}
