using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace ManagementScripts
{
	public class GameManager : MonoBehaviour
	{
		public static List<string> defaultScenarios = new List<string>();

		public static List<string> defaultScenarioKeys = new List<string>();

		public static List<string> defaultBibites = new List<string>();

		public static List<string> defaultChallenges = new List<string>();

		public static List<string> defaultChallengesKeys = new List<string>();

		public static UnityEvent onSceneChange = new UnityEvent();

		public static UnityEvent<string> onChangeToScene = new UnityEvent<string>();

		public static BibiteScenes activeScene = BibiteScenes.Other;

		public static string saveToLoad;

		public static void OpenMenu()
		{
			onSceneChange.Invoke();
			UserControl.ClearBlockStack();
			onChangeToScene.Invoke("Menu");
			activeScene = BibiteScenes.Menu;
			SceneManager.LoadScene("Menu");
		}

		public static void OpenSpriteGenerator()
		{
			onSceneChange.Invoke();
			UserControl.ClearBlockStack();
			onChangeToScene.Invoke("SpriteGenerator");
			activeScene = BibiteScenes.Other;
			SceneManager.LoadScene("SpriteGenerator");
		}

		public static void OpenPatreonSimulation()
		{
			onSceneChange.Invoke();
			UserControl.ClearBlockStack();
			onChangeToScene.Invoke("PatreonSimulation");
			activeScene = BibiteScenes.Other;
			SceneManager.LoadScene("PatreonSimulation");
		}

		public static void OpenAnimationScene()
		{
			onSceneChange.Invoke();
			UserControl.ClearBlockStack();
			onChangeToScene.Invoke("TestAndAnimation");
			activeScene = BibiteScenes.Other;
			SceneManager.LoadScene("TestAndAnimation");
		}

		public static void StartGame()
		{
			onSceneChange.Invoke();
			UserControl.ClearBlockStack();
			onChangeToScene.Invoke("Main");
			activeScene = BibiteScenes.Simulation;
			SceneManager.LoadScene("Main");
		}

		public static void StartGame(string saveToLoadPath)
		{
			saveToLoad = saveToLoadPath;
			StartGame();
		}

		public static void Continue()
		{
			StartGame(SaveController.GetLastSave());
		}

		public static void QuitGame()
		{
			UserControl.ClearBlockStack();
			Application.Quit();
		}

		public static void GiveFeedback()
		{
			Application.OpenURL("https://forms.gle/LNDovpSVDA6A8Dxm7");
		}

		public static void ReportBug()
		{
			Application.OpenURL("https://forms.gle/d5dJtnn7uMfdoPbq6");
		}

		public static void brainHelp()
		{
			Application.OpenURL("https://drive.google.com/open?id=1-6AyPj3MMdWPcam4Uq-2ofupDO9vKrZP");
		}
	}
}
