using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToMenuManager : MonoBehaviour
{
	public static GoBackToMenuManager Instance { get; private set; }

	public void GoBackToMenu()
	{
		Invoke("ActuallyLoadScene", 0.5f);
	}

	private void ActuallyLoadScene()
	{
		SceneManager.LoadScene("MainMenu");
	}

	private void Awake()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		Instance = this;
	}
}
