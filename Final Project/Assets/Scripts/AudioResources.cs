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
        initSliders();
        handleListeners();
        AudioManager.PlayBackgroundMusic(backgroundMusic);
    }

    void initSliders()
    {
        musicSlider.value = AudioManager.GetVolume(AudioManager.AudioChannel.Music);
        voiceSlider.value = AudioManager.GetVolume(AudioManager.AudioChannel.Voice);
        sfxSlider.value = AudioManager.GetVolume(AudioManager.AudioChannel.SFX);
        ambientalSlider.value = AudioManager.GetVolume(AudioManager.AudioChannel.Ambiental);
    }

    void handleListeners()
    {
        musicSlider.onValueChanged.AddListener(delegate { changeBackgroundVolume(); });
        voiceSlider.onValueChanged.AddListener(delegate { changeVoiceVolume(); });
        sfxSlider.onValueChanged.AddListener(delegate { changeSFXVolume(); });
        ambientalSlider.onValueChanged.AddListener(delegate { changeAmbientalVolume(); });
    }

    void changeBackgroundVolume()
    {
        AudioManager.SetVolume(AudioManager.AudioChannel.Music, musicSlider.value);
        AudioManager.SaveSettings();
    }
    void changeVoiceVolume()
    {
        AudioManager.SetVolume(AudioManager.AudioChannel.Voice, voiceSlider.value);
        AudioManager.SaveSettings();
    }

    void changeSFXVolume()
    {
        AudioManager.SetVolume(AudioManager.AudioChannel.SFX, sfxSlider.value);
        AudioManager.SaveSettings();
    }

    void changeAmbientalVolume()
    {
        AudioManager.SetVolume(AudioManager.AudioChannel.Ambiental, ambientalSlider.value);
        AudioManager.SaveSettings();
    }

}