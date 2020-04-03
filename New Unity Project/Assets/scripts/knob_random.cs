using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knob_random : MonoBehaviour, IHealth
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
        StartCoroutine("RandomForce");

    }

    IEnumerator RandomForce()
    {
        for (; ; )
        {
            Vector2 directionOfMovement = Random.insideUnitCircle * moveSpeed;
            rigidBody.AddForce(directionOfMovement);
            yield return new WaitForSeconds(1f);
        }
    }

    public void takeDamage()
    {
        hitPoints -= 1;
        if (hitPoints <= 0)
            Destroy(gameObject);
    }

    public void heal()
    {
        hitPoints = 100;
    }

}
