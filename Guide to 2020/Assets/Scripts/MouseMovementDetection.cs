using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MouseMovementDetection : MonoBehaviour
{

    public Texture2D cursorTexture;
    Vector2 cursorHotspot;

    void Start()
    {
        InvokeRepeating("DetectMouseMovement", 0.1f, 0.1f);

        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);

        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.ForceSoftware);
    }

    

    Vector3 mouseLastPosition = Vector3.zero;
    float mouseMovementTime = 0f;

    public GameObject panel;

    public Sprite cleanHands;

    public Slider timerSlider;

    private const float timerMax = 10f;
    private float timeRemaining = timerMax;

    void Update()
    {
        timerSlider.value = CalculatedSliderValue();

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (timeRemaining <= 0)
        {
            timeRemaining = 0;

            if (panel.GetComponent<Image>().sprite != cleanHands)
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

    void DetectMouseMovement()
    {
        Vector3 mousePosition = Input.mousePosition - mouseLastPosition;
        
        if (mouseLastPosition != Input.mousePosition && Input.GetMouseButton(0))
        {
            //Debug.Log("Mouse is moving");
            mouseMovementTime++;
        }
        else
        {
            //Debug.Log("Mouse is not moving");
        }

        if (mouseMovementTime >= 30)
        {
            //Debug.Log("MOUSE MOVED ENOUGH");

            panel.GetComponent<Image>().sprite = cleanHands;

            Invoke("LoadNextLevel", 1f);

        }

        mouseLastPosition = Input.mousePosition;

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
