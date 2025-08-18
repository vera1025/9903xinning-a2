using UnityEngine;
using UnityEngine.UI;


public class TextShow : MonoBehaviour
{
    public Text talkText;
    public string[] talk_content;
    public int talk_id;

    public GameObject talk;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        talk_id = 0;
         talkText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Update_talk();
        }
    }
    void Update_talk()
    {
        //if (talk_id == 0)
        //{
        //    talk.SetActive(true);
        //}



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
