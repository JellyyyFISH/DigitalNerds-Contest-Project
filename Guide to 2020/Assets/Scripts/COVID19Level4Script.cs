using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class COVID19Level4Script : MonoBehaviour
{

    private float xMaxLeft = 810;
    private float xMinLeft = 620;
    private float yMaxLeft = 720;
    private float yMinLeft = 290;

    private float xMaxRight = 1315;
    private float xMinRight = 1140;
    private float yMaxRight = 740;
    private float yMinRight = 285;

    public Sprite splitLeft;
    public Sprite splitRight;
    public Sprite splitBoth;

    public GameObject panel;

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
        if (Input.GetMouseButton(0))
        {
            Debug.Log(Input.mousePosition);
        }

        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x >= xMinLeft && Input.mousePosition.x <= xMaxLeft && Input.mousePosition.y >= yMinLeft && Input.mousePosition.y <= yMaxLeft && panel.GetComponent<Image>().sprite != splitLeft)
        {
            if (panel.GetComponent<Image>().sprite == splitRight)
            {
                panel.GetComponent<Image>().sprite = splitBoth;
                Debug.Log("Pressed Left - Split Both");
            }
            else
            {
                panel.GetComponent<Image>().sprite = splitLeft;
                Debug.Log("Pressed Left - Split Left");
            }
        }
        else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x >= xMinRight && Input.mousePosition.x <= xMaxRight && Input.mousePosition.y >= yMinRight && Input.mousePosition.y <= yMaxRight && panel.GetComponent<Image>().sprite != splitRight)
        {
            if (panel.GetComponent<Image>().sprite == splitLeft)
            {
                panel.GetComponent<Image>().sprite = splitBoth;
                Debug.Log("Pressed Right - Split Both");
            }
            else
            {
                panel.GetComponent<Image>().sprite = splitRight;
                Debug.Log("Pressed Right - Split Right");
            }
        }

        if (panel.GetComponent<Image>().sprite == splitBoth)
        {
            Invoke("LoadNextLevel", 2f);
        }

        timerSlider.value = CalculatedSliderValue();

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (timeRemaining <= 0)
        {
            timeRemaining = 0;

            if (panel.GetComponent<Image>().sprite != splitBoth)
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

        int levelNumber = MainMenuManager.levels[Random.Range(1, MainMenuManager.levels.Count)];

        MainMenuManager.levels.Remove(levelNumber);

        Debug.Log("COVID-19 Level" + levelNumber.ToString());

        SceneManager.LoadScene("COVID-19 Level" + levelNumber.ToString());
    }

    void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu Scene");
    }

}
