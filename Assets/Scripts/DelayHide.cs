using UnityEngine;

public class DelayHide : MonoBehaviour
{
    public float hideTime;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Hide", hideTime);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }

}
