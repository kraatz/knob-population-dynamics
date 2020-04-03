using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class factory : MonoBehaviour
{
    //public GameObject knobPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Produce");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Produce()
    {
        yield return new WaitForSeconds(1);
        for (; ; )
        {
            GameObject knobPrefab = gui.producedKnob;
            GameObject go = Instantiate(knobPrefab, gameObject.transform);
            go.transform.position = gameObject.transform.position;
            yield return new WaitForSeconds(.7f);
        }
    }

}

