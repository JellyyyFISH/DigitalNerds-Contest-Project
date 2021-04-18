using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    static int[] levelsInput = { 0, 1, 2, 3, 4, 5};

    public static List<int> levels = new List<int>(levelsInput);

    public void PlayCovid19 ()
    {

        int levelNumber = levels[Random.Range(1, levels.Count)];

        levels.Remove(levelNumber);

        Debug.Log("COVID-19 Level" + levelNumber.ToString());

        SceneManager.LoadScene("COVID-19 Level" + levelNumber.ToString());
    }

    public void PlayAustralianWildfires ()
    {
        SceneManager.LoadScene("Australian Wildfires Scene");
    }

    public void PlayEducationSystem()
    {
        SceneManager.LoadScene("Education System Scene");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

}
