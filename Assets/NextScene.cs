using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

	public void Next_Scene()
    {
        SceneManager.LoadScene(28);
        /*
        The buildIndex is a unique ID assigned to each scene, we can specify an exact scene by using their ID here. For example, 
        MainMenu's buildIndex is 0. The buildIndex of each scene can be obtained from the Build Settings menu. There is a number 
        on the right side of each scene listed for the build. We have to add the scenes individually to the build settings 
        to make sure they are included in the apk file.
         */

    }
}
