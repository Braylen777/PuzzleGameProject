using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add me!!
public class TitleScreen : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }







}
