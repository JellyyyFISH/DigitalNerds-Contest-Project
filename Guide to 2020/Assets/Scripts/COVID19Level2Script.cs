using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class COVID19Level2Script : MonoBehaviour
{

    public Sprite maskOnFace;

    public GameObject panel;

    private float xMax = 970;
    private float xMin = 850;
    private float yMax = 450;
    private float yMin = 360;

    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && Input.mousePosition.x >= xMin && Input.mousePosition.x <= xMax && Input.mousePosition.y >= yMin && Input.mousePosition.y <= yMax)
        {
            panel.GetComponent<Image>().sprite = maskOnFace;

            Invoke("LoadNextLevel", 2f);

        }

        if (Input.GetMouseButton(0))
        {
            Debug.Log(Input.mousePosition);
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
