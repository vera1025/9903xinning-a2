using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Internaction : MonoBehaviour
{

    public bool can_pick;
    public GameObject tip;

    public GameObject show_ui;

    void Update()
    {

        if (can_pick && Input.GetKeyDown(KeyCode.E) && !show_ui.activeSelf)
        {
            show_ui.gameObject.SetActive(true);
            Invoke("Hide", 3f);
            can_pick = false;
            tip.SetActive(false);
        }
        

    }
    void Hide()
    {
        show_ui.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !show_ui.activeSelf)
        {
            can_pick = true;
            tip.SetActive(true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && !show_ui.activeSelf)
        {
            can_pick = false;
            tip.SetActive(false);
        }
    }
}
