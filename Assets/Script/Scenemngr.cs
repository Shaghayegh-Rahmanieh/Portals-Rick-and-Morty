using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemngr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeSceneAfterDelay(3));
    }

    // این سین فقط 3 ثانیه نمایش داده می شود
    IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("TryAgain");
    }
}
