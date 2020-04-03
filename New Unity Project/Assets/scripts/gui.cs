using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gui : MonoBehaviour
{
    public GameObject warriorKnob;
    public GameObject workerKnob;
    public static GameObject producedKnob;
    // Start is called before the first frame update
    void Start()
    {
        producedKnob = warriorKnob;
    }

    public void HandleProductionDropdown(int value)
    {
        switch (value)
        {
            case 0:
                producedKnob = warriorKnob;
                break;
            case 1:
                producedKnob = workerKnob;
                break;
            default:
                break;
        }
    }
}
