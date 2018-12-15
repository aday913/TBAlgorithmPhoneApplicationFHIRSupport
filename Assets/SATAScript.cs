using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SATAScript : MonoBehaviour {
    public int order;
    public void SATA_OnSelect()
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<Settings>().choices[order] = gameObject.GetComponent<Toggle>().isOn;
    }
}
