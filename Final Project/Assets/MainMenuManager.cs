using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public Button mainMenu;
    public Button continueGame;
    public Button newGame;
    public Button loadGame;
    public Button options;
    public Button quit;

    public Button optionsMenu;
    public Text music;
    public Text voice;
    public Text sfx;
    public Text ambiental;
    public Slider musicSlider;
    public Slider voiceSlider;
    public Slider sfxSlider;
    public Slider ambientalSlider;

    public Button back;

	// Use this for initialization
	void Start ()
    {
        mainMenu = mainMenu.GetComponent<Button>();
        continueGame = continueGame.GetComponent<Button>();
        newGame = newGame.GetComponent<Button>();
        loadGame = loadGame.GetComponent<Button>();
        options = options.GetComponent<Button>();
        quit = quit.GetComponent<Button>();
        optionsMenu = optionsMenu.GetComponent<Button>();
        music = music.GetComponent<Text>();
        voice = voice.GetComponent<Text>();
        sfx = sfx.GetComponent<Text>();
        ambiental = ambiental.GetComponent<Text>();
        back = back.GetComponent<Button>();
        musicSlider = musicSlider.GetComponent<Slider>();
        voiceSlider = voiceSlider.GetComponent<Slider>();
        sfxSlider = sfxSlider.GetComponent<Slider>();
        ambientalSlider = ambientalSlider.GetComponent<Slider>();

        mainMenu.GetComponentInParent<Image>().color = Color.clear;
        continueGame.GetComponentInParent<Image>().color = Color.clear;
        newGame.GetComponentInParent<Image>().color = Color.clear;
        loadGame.GetComponentInParent<Image>().color = Color.clear;
        options.GetComponentInParent<Image>().color = Color.clear;
        quit.GetComponentInParent<Image>().color = Color.clear;
        optionsMenu.GetComponentInParent<Image>().color = Color.clear;
        back.GetComponentInParent<Image>().color = Color.clear;

        continueGame.onClick.AddListener(ContinueGame);
        newGame.onClick.AddListener(NewGame);
        loadGame.onClick.AddListener(LoadGame);
        options.onClick.AddListener(Options);
        quit.onClick.AddListener(Quit);
        back.onClick.AddListener(Back);

        mainMenu.gameObject.SetActive(true);
        continueGame.gameObject.SetActive(true);
        newGame.gameObject.SetActive(true);
        loadGame.gameObject.SetActive(true);
        options.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        optionsMenu.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        voice.gameObject.SetActive(false);
        sfx.gameObject.SetActive(false);
        ambiental.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
        musicSlider.gameObject.SetActive(false);
        voiceSlider.gameObject.SetActive(false);
        sfxSlider.gameObject.SetActive(false);
        ambientalSlider.gameObject.SetActive(false);
	}

    void ContinueGame() 
    {
        Debug.Log("Continue");
    }

    void NewGame()
    {
        //SceneManager.LoadScene(1);
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        this.GetComponentInChildren<Canvas>().enabled = false;
        AudioManager.StopBackgroundMusic();
    }

    void LoadGame()
    {
        if (loadGame.gameObject.active)
        {
            loadGame.gameObject.SetActive(false);
        }
    }

    void Options()
    {
        mainMenu.gameObject.SetActive(false);
        continueGame.gameObject.SetActive(false);
        newGame.gameObject.SetActive(false);
        loadGame.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(true);
        music.gameObject.SetActive(true);
        voice.gameObject.SetActive(true);
        sfx.gameObject.SetActive(true);
        ambiental.gameObject.SetActive(true);
        back.gameObject.SetActive(true);
        musicSlider.gameObject.SetActive(true);
        voiceSlider.gameObject.SetActive(true);
        sfxSlider.gameObject.SetActive(true);
        ambientalSlider.gameObject.SetActive(true);
    }

    void Back()
    {
        mainMenu.gameObject.SetActive(true);
        continueGame.gameObject.SetActive(true);
        newGame.gameObject.SetActive(true);
        loadGame.gameObject.SetActive(true);
        options.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        optionsMenu.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        voice.gameObject.SetActive(false);
        sfx.gameObject.SetActive(false);
        ambiental.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
        musicSlider.gameObject.SetActive(false);
        voiceSlider.gameObject.SetActive(false);
        sfxSlider.gameObject.SetActive(false);
        ambientalSlider.gameObject.SetActive(false);
    }

    void Quit()
    {
        Application.Quit();
    }
}
