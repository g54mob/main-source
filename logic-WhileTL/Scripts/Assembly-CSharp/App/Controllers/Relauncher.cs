using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace App.Controllers
{
	public class Relauncher : ActiveComponent
	{
		public static void Relaunch()
		{
			Relauncher relauncher = new GameObject("__relauncher__").AddComponent<Relauncher>();
			relauncher.Init();
			relauncher.RestartApp();
		}

		public void RestartApp()
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			Controller controller = UnityEngine.Object.FindObjectOfType<Controller>();
			if (controller != null)
			{
				UnityEngine.Object.Destroy(controller);
			}
			SceneManager.LoadScene("empty");
		}

		private IEnumerator OnLevelWasLoaded(int level)
		{
			if (SceneManager.GetActiveScene().name == "empty")
			{
				GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
				foreach (GameObject gameObject in array)
				{
					if (gameObject.gameObject != Program.Instance.gameObject && gameObject.gameObject != base.gameObject && gameObject.gameObject.name != "SteamManager" && gameObject.gameObject.name != "IAPUtil" && gameObject.gameObject.name != "WwiseGlobal")
					{
						UnityEngine.Object.Destroy(gameObject.gameObject);
					}
				}
				ActiveComponent.ResetGeneralComponents();
				yield return new WaitForEndOfFrame();
				yield return new WaitForEndOfFrame();
				SceneManager.LoadScene(0);
			}
			else if (level == 0)
			{
				yield return new WaitForEndOfFrame();
				Resources.UnloadUnusedAssets();
				GC.Collect();
				yield return new WaitForEndOfFrame();
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}
}
