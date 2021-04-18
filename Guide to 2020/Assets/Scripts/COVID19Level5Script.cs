using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class COVID19Level5Script : MonoBehaviour
{

    private float xMaxLeft = 1160;
    private float xMinLeft = 1060;
    private float yMaxLeft = 350;
    private float yMinLeft = 310;

    private float xMaxRight = 1285;
    private float xMinRight = 1185;
    private float yMaxRight = 350;
    private float yMinRight = 305;

    public Sprite answerYes;
    public Sprite answerNo;

    public GameObject panel;

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

        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x >= xMinLeft && Input.mousePosition.x <= xMaxLeft && Input.mousePosition.y >= yMinLeft && Input.mousePosition.y <= yMaxLeft)
        {
            panel.GetComponent<Image>().sprite = answerYes;
        }
        else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x >= xMinRight && Input.mousePosition.x <= xMaxRight && Input.mousePosition.y >= yMinRight && Input.mousePosition.y <= yMaxRight)
        {
            panel.GetComponent<Image>().sprite = answerNo;

            Invoke("LoadNextLevel", 2f);
        }


    }

    void LoadNextLevel()
    {

        int levelNumber = MainMenuManager.levels[Random.Range(1, MainMenuManager.levels.Count)];

        MainMenuManager.levels.Remove(levelNumber);

        Debug.Log("COVID-19 Level" + levelNumber.ToString());

        SceneManager.LoadScene("COVID-19 Level" + levelNumber.ToString());
    }

}
