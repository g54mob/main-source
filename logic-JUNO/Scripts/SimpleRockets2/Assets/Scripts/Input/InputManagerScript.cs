using System;
using System.IO;
using Assets.Scripts.Settings;
using ModApi.Common.Extensions;
using ModApi.Input;
using Rewired;
using Rewired.Platforms;
using UnityEngine;

namespace Assets.Scripts.Input
{
	public class InputManagerScript : MonoBehaviour
	{
		public IGameInputs Inputs { get; private set; }

		public InputManager RewiredManager { get; private set; }

		public static InputManagerScript Create(GameObject parent)
		{
			InputManagerScript inputManagerScript = new GameObject("InputManager").AddComponent<InputManagerScript>();
			inputManagerScript.transform.SetParent(parent.transform);
			Game.Instance.ResourceLoader.InstantiatePrefab("Input/RewiredEventSystem").transform.parent = inputManagerScript.transform;
			return inputManagerScript;
		}

		public void EnableControlsForScene(string sceneName)
		{
			if (string.IsNullOrEmpty(sceneName))
			{
				sceneName = Game.Instance.SceneManager.CurrentScene;
			}
			InputWrapper.SetEnabledControlCategories(sceneName switch
			{
				"Design" => new string[2] { "Other", "Designer" }, 
				"Flight" => new string[2] { "Other", "FlightCommon" }, 
				"PlanetStudio" => new string[2] { "Other", "PlanetStudio" }, 
				_ => new string[1] { "Other" }, 
			});
		}

		protected virtual void OnApplicationFocus(bool focus)
		{
			InputWrapper.Player.controllers.Mouse.enabled = focus;
			InputWrapper.Player.controllers.Keyboard.enabled = focus;
		}

		protected virtual void OnDisable()
		{
			if (RewiredManager != null)
			{
				UnityEngine.Object.Destroy(RewiredManager);
			}
		}

		protected virtual void OnEnable()
		{
			InitializeInputManager();
		}

		private void InitializeInputManager()
		{
			ApplicationSettings settings = Game.Instance.Settings;
			LegacyInputDataFileUpgrade(settings.AppVersionLastRun);
			RewiredManager = Game.Instance.ResourceLoader.InstantiatePrefab<InputManager>("Input/RewiredInputManager");
			if (RewiredManager == null)
			{
				this.LogException(null, "Unable to instantiate the input manager!!");
			}
			RewiredManager.transform.parent = base.transform;
			if (RewiredManager.gameObject.activeSelf)
			{
				Debug.LogError("The Rewired input manager is active before Rewired has been fully configured! Deactivate it in the prefab.");
			}
			RewiredManager.userData.ConfigVars.windowsStandalonePrimaryInputSource = (settings.Game.General.UseDirectInput ? WindowsStandalonePrimaryInputSource.DirectInput : WindowsStandalonePrimaryInputSource.RawInput);
			RewiredManager.userData.ConfigVars.android_supportUnknownGamepads = settings.Game.General.SupportUnknownGamepadsOnAndroid;
			RewiredManager.gameObject.SetActive(value: true);
			if (settings.AppVersionLastRun != Game.Version)
			{
				OnVersionUpgrade(settings.AppVersionLastRun, Game.Version);
			}
			Inputs = GameInputs.Create();
			EnableControlsForScene(null);
		}

		private void LegacyInputDataFileUpgrade(Version appVersionLastRun)
		{
			if (!(appVersionLastRun <= new Version(0, 9, 901, 0)))
			{
				return;
			}
			string path = Path.Combine(Game.PersistentDataPath, "ControlInputData.xml");
			if (File.Exists(path))
			{
				try
				{
					Debug.Log($"Deleting user's control input data file during upgrade from version '{appVersionLastRun}'");
					File.Delete(path);
				}
				catch (Exception exception)
				{
					Debug.LogError("Unable to delete the users control input data file.");
					Debug.LogException(exception);
				}
			}
		}

		private void OnVersionUpgrade(Version previousVersion, Version currentVersion)
		{
		}
	}
}
