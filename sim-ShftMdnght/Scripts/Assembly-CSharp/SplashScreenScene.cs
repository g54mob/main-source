using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenScene : MonoBehaviour
{
	private void Start()
	{
		Invoke("LoadScene", 2.5f);
	}

	private void LoadScene()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
