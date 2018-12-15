using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultipleChoiceCode : MonoBehaviour {
    public void ValueChange()
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<Settings>().Response = gameObject.GetComponent<Dropdown>().value + 1;
    }
}
