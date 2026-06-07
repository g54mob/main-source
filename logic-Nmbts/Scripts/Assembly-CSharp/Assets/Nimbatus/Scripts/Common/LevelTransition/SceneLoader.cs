using System.Collections;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Nimbatus.Scripts.Common.LevelTransition
{
	public class SceneLoader : MonoBehaviour
	{
		public string SceneName;

		public bool LoadCustomScene;

		public UILabel LoadingLabel;

		public void Awake()
		{
			if (!LoadCustomScene)
			{
				SceneName = NimbatusSceneManager.NextSceneName;
			}
			if (LoadingLabel != null)
			{
				LoadingLabel.enabled = true;
			}
			RuntimeGlobals.ResetToDefault();
			SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
		}

		private IEnumerator LoadScene()
		{
			yield return new WaitForSeconds(1f);
			SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
		}

		public void OnDisable()
		{
		}
	}
}
