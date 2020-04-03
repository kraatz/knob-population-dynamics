using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hospital : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHealth health = collision.gameObject.GetComponent<IHealth>();
        if (health == null)
            return;
        health.heal();
    }

}
