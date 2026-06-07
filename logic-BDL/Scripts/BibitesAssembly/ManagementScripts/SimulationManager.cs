using System.Collections;
using OneUseScripts;
using SettingScripts;
using SimulationScripts;
using UnityEngine;
using Utility;

namespace ManagementScripts
{
	public class SimulationManager : MonoBehaviour
	{
		[SerializeField]
		private AutoPanner autopan;

		public static SimulationManager Instance;

		public static bool fromAutosaveReload;

		public static bool hadSomethingSelected;

		public static Vector3 posAtAutoReload;

		public static float camSizeAtAutoReload;

		public BibiteSpawner bibiteSpawner;

		public UICamera camUI;

		public static string gameName;

		public static bool gameWasLoaded;

		public static bool loadedGame => !string.IsNullOrEmpty(GameManager.saveToLoad);

		private void Awake()
		{
			if (Instance != null)
			{
				Object.Destroy(this);
			}
			else
			{
				Instance = this;
			}
		}

		private void Start()
		{
			Application.runInBackground = true;
			PlantCounter.ResetCount();
			MeatCounter.ResetCount();
			TimeController.targetTimeScale.SetValue(1f);
			TimeController.engineTimeScale.SetValue(1f);
			if (!loadedGame)
			{
				gameWasLoaded = false;
				TimeKeeper.simulatedTime = 0.0;
				BuildSpawners();
				StartSpawners();
			}
			else
			{
				string saveToLoad = GameManager.saveToLoad;
				GameManager.saveToLoad = "";
				gameWasLoaded = true;
				if (!fromAutosaveReload && UserSettings.PauseAfterLoad.val)
				{
					TimeController.Instance.TogglePause();
				}
				SaveController.Instance.LoadWorld(saveToLoad);
			}
			InitializeScene();
		}

		public void BuildSpawners()
		{
			WorldObjectsSpawner worldObjectsSpawner = Object.FindFirstObjectByType<WorldObjectsSpawner>();
			ZoneManager.instance.InitializeSpawner();
			bibiteSpawner = worldObjectsSpawner.GenerateNewBibiteSpawner().GetComponent<BibiteSpawner>();
		}

		public void StartSpawners()
		{
			ZoneManager.instance.StartSpawner();
			bibiteSpawner.StartSpawner();
			autopan.StartAutoPanner();
		}

		public void ResumeSpawners()
		{
			ZoneManager.instance.ResumeSpawner();
			bibiteSpawner.StartSpawner();
			autopan.StartAutoPanner();
		}

		public void InitializeScene()
		{
			if (fromAutosaveReload)
			{
				CameraManager.instance.transform.position = posAtAutoReload;
				CameraManager.instance.SetCamSize(camSizeAtAutoReload);
				fromAutosaveReload = false;
				if (hadSomethingSelected)
				{
					StartCoroutine(SelectClosest());
				}
			}
		}

		private IEnumerator SelectClosest()
		{
			yield return null;
			UserControl.Instance.SelectClosestEntity();
		}
	}
}
