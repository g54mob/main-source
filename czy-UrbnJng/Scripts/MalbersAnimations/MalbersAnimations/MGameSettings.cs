using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Managers/Game Settings <Simple>")]
	public class MGameSettings : MonoBehaviour, IScene
	{
		public bool HideCursor;

		public bool ForceFPS;

		[Hide("ForceFPS")]
		[Min(-1f)]
		public int GameFPS = 120;

		[Min(0f)]
		public int vSyncCount;

		public bool DebugBuild;

		[Tooltip("Add the Additive scene in the Editor")]
		public bool InEditor = true;

		[HideInInspector]
		public List<string> sceneNames;

		private void Awake()
		{
			Debug.developerConsoleVisible = DebugBuild;
			base.transform.parent = null;
			Object.DontDestroyOnLoad(this);
			if (HideCursor)
			{
				Cursor.lockState = CursorLockMode.Locked;
			}
			QualitySettings.vSyncCount = vSyncCount;
			Application.targetFrameRate = (ForceFPS ? GameFPS : (-1));
			if (sceneNames == null || InEditor)
			{
				return;
			}
			foreach (string sceneName in sceneNames)
			{
				SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
			}
		}

		[ContextMenu("Add Additive Scene")]
		public void SceneLoaded()
		{
		}
	}
}
