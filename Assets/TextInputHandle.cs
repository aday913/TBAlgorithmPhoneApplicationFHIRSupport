using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInputHandle : MonoBehaviour {
    //public string text;

    private GameObject gameSetting;
    private GameObject script;
    public void TextInput(string input)
    {
        string info = input;

        gameSetting  = GameObject.FindGameObjectWithTag("Manager");
        script = gameSetting.GetComponent<Settings>().OkayButtonLinear;
        script.GetComponent<OkayButtonLinearCode>().NextSceneOnClick(info);
       // text = input;
    }
}
