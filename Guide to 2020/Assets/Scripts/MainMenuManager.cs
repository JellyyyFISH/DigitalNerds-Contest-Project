using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    static int[] levelsInput = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

    public static List<int> levels;

    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        levels = new List<int>(levelsInput);

    }

    public void PlayCovid19 ()
    {

        Debug.Log(levels.Count);

        int levelNumber = levels[Random.Range(1, levels.Count)];

        levels.Remove(levelNumber);

        Debug.Log(levels.Count);

        Debug.Log("COVID-19 Level" + levelNumber.ToString());

        SceneManager.LoadScene("COVID-19 Level" + levelNumber.ToString());
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

}
