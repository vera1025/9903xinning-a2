using UnityEngine;

public class DelayShow : MonoBehaviour
{
    public float showTime;

    public GameObject txt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Show", showTime);

    }
    void Show()
    {
        txt.SetActive(true);
    }
}
