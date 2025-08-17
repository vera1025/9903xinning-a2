using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int sceneIndex;

    public void OnDoorOpen()
    {
        Debug.Log("=====open door==========="+ sceneIndex);

        SceneFade.Instance.FadeIn(() =>
        {
            SceneManager.LoadScene(sceneIndex);
        });
    }

    //private IEnumerator ChangeScene()
    //{
    //    yield return new WaitForSeconds(1);
        
       
    //}

}
