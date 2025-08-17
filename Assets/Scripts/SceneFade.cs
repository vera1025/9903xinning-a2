using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{
    public Image image;

    public Color fadeColor;

    public float fadeDuration;

    public static SceneFade Instance;

    public bool isFadeOutFirst;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if(isFadeOutFirst)
        {
            image.gameObject.SetActive(true);
            FadeOut();
        }
    }

    public void FadeIn(Action callback)
    {
        image.gameObject.SetActive(true);
        StartCoroutine(Fade(0, 1, callback));
    }
    public void FadeOut()
    {
       // Debug.Log("======FadeOut========" + image.color);
        if (image.gameObject.activeSelf)
        {
            StartCoroutine(Fade(1, 0, () =>
            {
                image.gameObject.SetActive(false);
            }));
        }

    }

    private IEnumerator Fade(float alphaFrom, float alphaTo, Action callback)
    {
        float timer = 0;
        while (timer < fadeDuration)
        {
            fadeColor.a = Mathf.Lerp(alphaFrom, alphaTo, timer / fadeDuration);
            image.color= fadeColor;

            timer += Time.deltaTime;

            yield return null;
        }

        fadeColor.a = alphaTo;
        image.color = fadeColor;

        callback?.Invoke();
    }
}
