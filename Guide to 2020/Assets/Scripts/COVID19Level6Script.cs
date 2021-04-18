using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class COVID19Level6Script : MonoBehaviour
{

    private float xMax = 1215;
    private float xMin = 710;
    private float yMax = 860;
    private float yMin = 450;

    public Slider timerSlider;

    private const float timerMax = 10f;
    private float timeRemaining = timerMax;

    private bool levelWon = true;

    private bool canLoadNextLevel = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
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
            Debug.Log("YOU LOST!");
            levelWon = false;
            Invoke("LoadStartMenu", 2f);
        }

        timerSlider.value = CalculatedSliderValue();

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (timeRemaining <= 0)
        {
            timeRemaining = 0;

            if (levelWon && canLoadNextLevel)
            {
                Debug.Log("YOU WON!");

                canLoadNextLevel = false;

                Invoke("LoadNextLevel", 1f);

            }

        }

    }
    void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu Scene");
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

}
