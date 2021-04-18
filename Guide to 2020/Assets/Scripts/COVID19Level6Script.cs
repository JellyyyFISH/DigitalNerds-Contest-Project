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

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Debug.Log(Input.mousePosition);
        }

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

            if (levelWon)
            {
                Debug.Log("YOU WON!");

                Invoke("LoadNextLevel", 2f);

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

        int levelNumber = MainMenuManager.levels[Random.Range(1, MainMenuManager.levels.Count)];

        MainMenuManager.levels.Remove(levelNumber);

        Debug.Log("COVID-19 Level" + levelNumber.ToString());

        SceneManager.LoadScene("COVID-19 Level" + levelNumber.ToString());
    }

}
