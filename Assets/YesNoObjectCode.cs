using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesNoObjectCode : MonoBehaviour {
    //public bool Selection;
    public void OptionSelected(bool selection)
    {
        if (selection)
        {
            GameObject.FindGameObjectWithTag("Manager").GetComponent<Settings>().Response = 1;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Manager").GetComponent<Settings>().Response = 2;
        }
        
    }
}
