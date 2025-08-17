using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BasketBall : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public UnityEvent events;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(-speed, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            events?.Invoke();
        }
    }

    public void Game_on()
    {
        Debug.Log("======Game_on========");
        SceneFade.Instance.FadeIn(() =>
        {
            SceneManager.LoadScene(1);
        });
    }
}
