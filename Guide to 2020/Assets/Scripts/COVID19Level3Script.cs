using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class COVID19Level3Script : MonoBehaviour
{

    public Sprite maskOnFace;

    public GameObject panel;

    private float xMax = 1450;
    private float xMin = 1380;
    private float yMax = 680;
    private float yMin = 630;

    public Slider timerSlider;

    private const float timerMax = 10f;
    private float timeRemaining = timerMax;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x >= xMin && Input.mousePosition.x <= xMax && Input.mousePosition.y >= yMin && Input.mousePosition.y <= yMax)
        {
            panel.GetComponent<Image>().sprite = maskOnFace;

            Invoke("LoadNextLevel", 1f);

        }

        //if (Input.GetMouseButton(0))
        //{
        //    Debug.Log(Input.mousePosition);
        //}

        timerSlider.value = CalculatedSliderValue();

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (timeRemaining <= 0)
        {
            timeRemaining = 0;

            if (panel.GetComponent<Image>().sprite != maskOnFace)
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

    void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu Scene");
    }

    void LoadFinishedMenu()
    {
        SceneManager.LoadScene("Finished Menu Scene");
    }

}
