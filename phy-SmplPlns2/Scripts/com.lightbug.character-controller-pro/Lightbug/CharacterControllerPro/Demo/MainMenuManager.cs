using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class MainMenuManager : MonoBehaviour
	{
		private string mainMenuName = "";

		private static MainMenuManager instance;

		public static MainMenuManager Instance => instance;

		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
				Object.DontDestroyOnLoad(base.gameObject);
				mainMenuName = SceneManager.GetActiveScene().name;
			}
			else
			{
				Object.Destroy(base.gameObject);
			}
		}

		public void QuitApplication()
		{
			Application.Quit();
		}

		public void GoToScene(string sceneName)
		{
			if (sceneName == mainMenuName)
			{
				Cursor.visible = true;
			}
			else
			{
				Cursor.visible = false;
			}
			SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				if (SceneManager.GetActiveScene().name == mainMenuName)
				{
					Application.Quit();
				}
				else
				{
					GoToScene(mainMenuName);
				}
			}
		}
	}
}
