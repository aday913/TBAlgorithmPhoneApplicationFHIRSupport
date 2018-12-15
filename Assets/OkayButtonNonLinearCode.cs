using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OkayButtonNonLinearCode : MonoBehaviour {
    public int[] Scenes;
    public int choice;
    public void GoToChosenSceneOnClick()
    {
        if (choice != 0)
        {
            SceneManager.LoadScene(Scenes[choice - 1]);//Note that arrays start from 0, and go up to desired size.
        }
        else
        {
            choice = GameObject.FindGameObjectWithTag("Manager").GetComponent<Settings>().Response;
            if (choice != 0)
            {
                SceneManager.LoadScene(Scenes[choice - 1]);
            }
            else
            {
                //Display a message asking the user to choose something.
            }
        }
    }
}
