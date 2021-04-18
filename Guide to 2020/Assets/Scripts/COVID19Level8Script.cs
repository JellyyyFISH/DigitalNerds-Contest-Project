using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class COVID19Level8Script : MonoBehaviour
{
    private float xMaxLeft = 725;
    private float xMinLeft = 430;
    private float yMaxLeft = 870;
    private float yMinLeft = 200;

    private float xMaxRight = 1585;
    private float xMinRight = 1290;
    private float yMaxRight = 895;
    private float yMinRight = 230;

    public Sprite stoppedLeft;
    public Sprite stoppedRight;
    public Sprite stoppedBoth;

    public GameObject panel;

    public Texture2D cursorTexture;
    Vector2 cursorHotspot;

    public Slider timerSlider;

    private const float timerMax = 10f;
    private float timeRemaining = timerMax;

    private bool canLoadNextLevel = true;
    private bool levelLost = true;

    // Start is called before the first frame update
    void Start()
    { 
        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);

        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    Debug.Log(Input.mousePosition);
        //}

        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x >= xMinLeft && Input.mousePosition.x <= xMaxLeft && Input.mousePosition.y >= yMinLeft && Input.mousePosition.y <= yMaxLeft && panel.GetComponent<Image>().sprite != stoppedLeft)
        {
            if (panel.GetComponent<Image>().sprite == stoppedRight)
            {
                panel.GetComponent<Image>().sprite = stoppedBoth;
                Debug.Log("Pressed Left - Split Both");
            }
            else
            {
                panel.GetComponent<Image>().sprite = stoppedLeft;
                Debug.Log("Pressed Left - Split Left");
            }
        }
        else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x >= xMinRight && Input.mousePosition.x <= xMaxRight && Input.mousePosition.y >= yMinRight && Input.mousePosition.y <= yMaxRight && panel.GetComponent<Image>().sprite != stoppedRight)
        {
            if (panel.GetComponent<Image>().sprite == stoppedLeft)
            {
                panel.GetComponent<Image>().sprite = stoppedBoth;
                Debug.Log("Pressed Right - Split Both");
            }
            else
            {
                panel.GetComponent<Image>().sprite = stoppedRight;
                Debug.Log("Pressed Right - Split Right");
            }
        } 
        if (panel.GetComponent<Image>().sprite == stoppedBoth && canLoadNextLevel)
        {
            canLoadNextLevel = false;

            levelLost = true;

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

            if (levelLost)
            {
                Invoke("LoadStartMenu", 2f);
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
