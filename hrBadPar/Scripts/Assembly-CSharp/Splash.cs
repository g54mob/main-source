using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
	private void Start()
	{
		Screen.SetResolution(1120, 832, Screen.fullScreen);
		StartCoroutine(ISplash());
	}

	private IEnumerator ISplash()
	{
		yield return new WaitForSeconds(6f);
		SceneManager.LoadScene("Main");
	}
}
