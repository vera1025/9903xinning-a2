using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Footballfall : MonoBehaviour
{
    public UnityEvent events;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            events?.Invoke();
        }
    }
}
