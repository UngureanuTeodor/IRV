using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InbetweenGameManager : MonoBehaviour {

    public Text loadingText;
    public Text pressKey;

    void Start()
    {
        loadingText.gameObject.SetActive(true);
        pressKey.gameObject.SetActive(false);

        //SceneManager.LoadScene(1);
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            yield return StartCoroutine(KeyPress(asyncLoad));

        }
    }

    IEnumerator KeyPress(AsyncOperation asyncLoad)
    {
        yield return new WaitForSeconds(3);
        loadingText.gameObject.SetActive(false);
        pressKey.gameObject.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        asyncLoad.allowSceneActivation = true;
    }

}
