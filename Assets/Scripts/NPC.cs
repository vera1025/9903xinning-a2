using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject tip;
    public bool can_talk;
    public GameObject talk;
    public Text talkText;
    public string[] talk_content;
    public int talk_id;
    void Update()
    {
        if(can_talk && Input.GetKeyDown(KeyCode.E))
        {
            Update_talk();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            can_talk = true;
            tip.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            can_talk = false;
            tip.SetActive(false);
            talk_id = 0;
            talk.SetActive(false);
        }
    }
    void Update_talk()
    {
        if(talk_id == 0)
        {
            talk.SetActive(true);
        } 

        

        talk_id++;
        if (talk_id == talk_content.Length + 1)
        {
            talk_id = 0;
            talk.SetActive(false);
        }
        else
        {
            talkText.text = talk_content[talk_id - 1];
        }
    }
}
