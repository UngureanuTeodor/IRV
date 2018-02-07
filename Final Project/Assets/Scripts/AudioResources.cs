using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum AmbientalMusic
{
    SaveSound,
}

public enum BackgroundMusic
{
    Music1,
    Music2,
}

public class AudioResources : MonoBehaviour
{

    public AudioSource backgroundMusic;
    public AudioSource ambientalMusic;
    public AudioSource voiceMusic;
    public AudioSource[] sfxMusic;

    public Slider musicSlider;
    public Slider voiceSlider;
    public Slider sfxSlider;
    public Slider ambientalSlider;

    public static AudioResources Instance;

    void Start()
    {
        Instance = this;
        backgroundMusic.Play();
    }

    void Update()
    {
        backgroundMusic.volume = musicSlider.value;
        voiceMusic.volume = voiceSlider.value;
        ambientalMusic.volume = ambientalSlider.value;
        foreach (AudioSource sfxSong in sfxMusic)
        {
            sfxSong.volume = sfxSlider.value;
        }
    }
}