using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State
    {
        idle,
        walking,
        swimming,
        climbing
    }

    public State currentState = State.idle;
    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.idle: Idle(); break;
            case State.walking: Walking(); break;
            case State.climbing: Climbing(); break;
            case State.swimming: Swimming(); break;
            default: break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "WaterTrigger")
        {
            currentState = State.swimming;
        }
        else if (other.name == "MountainTrigger")
        {
            currentState = State.climbing;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentState = State.walking;
    }

    void Swimming()
    {
        Debug.Log("I am currently swimming!");
    }

    void Climbing()
    {
        Debug.Log("I am currently climbing!");
    }

    void Idle()
    {
        Debug.Log("I am currently idle!");

        if (lastPosition != transform.position)
        {
            currentState = State.walking;
        }
        lastPosition = transform.position;
    }

    void Walking()
    {
        Debug.Log("I am currently walking!");

        if (lastPosition == transform.position) 
        {
            currentState = State.idle;
        }
        lastPosition = transform.position;
    }
}
