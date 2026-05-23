using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[SerializeField]
	private Animator transition;

	private string sceneName;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		sceneName = SceneManager.GetActiveScene().name;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && (sceneName == "End" || sceneName == "Credits"))
		{
			SceneManager.LoadScene("MainMenu");
		}
	}

	public void LoadScene(string name)
	{
		StartCoroutine(StartScene(name));
	}

	private IEnumerator StartScene(string name)
	{
		transition.transform.gameObject.SetActive(value: true);
		transition.SetTrigger("FadeIn");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(name);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
