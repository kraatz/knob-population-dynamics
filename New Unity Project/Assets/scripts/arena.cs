using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arena : MonoBehaviour
{
    public float bounce = -.5f;
    public GameObject knobPrefab;
    public Camera arenaCamera;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // if the player pressed space (exclude holding key down)
            Vector3 mousePosition = arenaCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = -1;

            GameObject go = Instantiate(knobPrefab);
            go.gameObject.transform.position = mousePosition;
            //go.gameObject.transform.SetParent(null);
            //Debug.Log(go.gameObject.transform.position);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        GameObject go = collision.gameObject;
        Debug.Log(go.name);
        Rigidbody2D rigidBody = go.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(rigidBody.position * bounce, ForceMode2D.Impulse);
        Debug.Log(rigidBody.position);
    }
}
