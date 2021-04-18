using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class COVID19Level7Script : MonoBehaviour
{
    public Sprite BLMchecked;

    public GameObject panel;

    private float xMax = 260;
    private float xMin = 70;
    private float yMax = 750;
    private float yMin = 440;

    public Slider timerSlider;

    private const float timerMax = 10f;
    private float timeRemaining = timerMax;

    public Texture2D cursorTexture;
    Vector2 cursorHotspot;

    // Start is called before the first frame update
    void Start()
    {
        cursorHotspot = new Vector2(0f, cursorTexture.height);

        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    Debug.Log(Input.mousePosition);
        //}

        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x >= xMin && Input.mousePosition.x <= xMax && Input.mousePosition.y >= yMin && Input.mousePosition.y <= yMax)
        {
            panel.GetComponent<Image>().sprite = BLMchecked;

            Invoke("LoadNextLevel", 1f);
        }

        timerSlider.value = CalculatedSliderValue();

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (timeRemaining <= 0)
        {
            timeRemaining = 0;

            if (panel.GetComponent<Image>().sprite != BLMchecked)
            {
                Debug.Log("YOU LOST!");

                Invoke("LoadStartMenu", 2f);

            }

        }

    }

    float CalculatedSliderValue()
    {
        return (timeRemaining / timerMax);
    }

    void LoadNextLevel()
    {

        if (MainMenuManager.levels.Count == 1)
        {
            Debug.Log("YOU FINISHED THE GAME");

            Invoke("LoadFinishedMenu", 2f);
        }
        else
        {
            int levelNumber = MainMenuManager.levels[Random.Range(1, MainMenuManager.levels.Count)];

            MainMenuManager.levels.Remove(levelNumber);

            Debug.Log("COVID-19 Level" + levelNumber.ToString());

            SceneManager.LoadScene("COVID-19 Level" + levelNumber.ToString());
        }
    }
    void LoadFinishedMenu()
    {
        SceneManager.LoadScene("Finished Menu Scene");
    }

    void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu Scene");
    }

}


