using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knob_move : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float hitPoints = 100f;
    public Vector2 accelerationDirection = Vector2.zero;
    private Rigidbody2D rigidBody;
    [HideInInspector]
    public bool hasTarget = false;  // do I have a target to move towards
    [HideInInspector]
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        if (rigidBody == null)
        {
            Debug.LogError("Player::Start cant find RigidBody2D </sadface>");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 directionOfMovement = Vector2.zero;
        Vector2 randomDirection = Random.insideUnitCircle;

        if (hasTarget)
        {
            //get distance between me and my target
            float distance = Vector2.Distance(transform.position, target.transform.position);
            // am I further than 2 units away
            if (distance > .3)
            {
                directionOfMovement = (target.transform.position - transform.position).normalized* moveSpeed;
            }
        }
        else
        {
            randomDirection *= moveSpeed;
        }

        directionOfMovement += randomDirection;

        rigidBody.AddForce(directionOfMovement);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        target = collision.gameObject;      // it is so set him as my target
        hasTarget = true;   // I have a target   
    }

    // if something is no longer coliiding with me I will run this code
    private void OnTriggerExit2D(Collider2D collision)
    {
        target = null;
        hasTarget = false;
    }

}
