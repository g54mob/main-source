using System;
using System.Collections;
using Assets.Packages.DevConsole;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.PlanetStudio;
using Assets.Scripts.Ui.Sharing.Upload.Craft;
using ModApi;
using ModApi.Services.Purchasing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.DevConsole
{
	public class DevConsoleManagerScript : MonoBehaviour
	{
		private DeveloperConsole _devConsole;

		private GameObject _inputBlocker;

		public static bool IsConsoleOpen { get; private set; }

		public static bool OpenedThisSession { get; private set; }

		public static DevConsoleManagerScript Create(GameObject parent)
		{
			DevConsoleManagerScript devConsoleManagerScript = new GameObject("DevConsoleManager").AddComponent<DevConsoleManagerScript>();
			devConsoleManagerScript.transform.SetParent(parent.transform);
			return devConsoleManagerScript;
		}

		public void CloseConsole()
		{
			if (IsConsoleOpen)
			{
				if (_inputBlocker != null)
				{
					UnityEngine.Object.Destroy(_inputBlocker);
					_inputBlocker = null;
				}
				if (EventSystem.current.currentSelectedGameObject == _devConsole.CommandInputField.gameObject)
				{
					EventSystem.current.SetSelectedGameObject(null);
				}
				_devConsole.CloseConsole();
				_devConsole.gameObject.SetActive(value: false);
				IsConsoleOpen = false;
				FlightSceneScript.Instance?.TimeManager.RequestPauseChange(paused: false, userInitiated: false);
			}
		}

		public void OpenConsole()
		{
			if (IsConsoleOpen)
			{
				return;
			}
			IInAppPurchaseFeatures<IInAppPurchaseFeature> features = Game.Instance.InAppPurchases.Features;
			if (features.IsFeatureUnlocked(features.DevConsole, "unlock the Dev Console."))
			{
				if (_devConsole == null)
				{
					Initialize();
				}
				if (!OpenedThisSession)
				{
					OpenedThisSession = true;
				}
				_devConsole.OpenConsole();
				_devConsole.gameObject.SetActive(value: true);
				StartCoroutine(ActivateInputField());
				IsConsoleOpen = true;
				FlightSceneScript.Instance?.TimeManager.RequestPauseChange(paused: true, userInitiated: false);
			}
		}

		public void ToggleConsole()
		{
			if (IsConsoleOpen)
			{
				CloseConsole();
			}
			else
			{
				OpenConsole();
			}
		}

		private IEnumerator ActivateInputField()
		{
			yield return new WaitForFixedUpdate();
			_devConsole.CommandInputField.ActivateInputField();
		}

		private void Initialize()
		{
			_devConsole = Game.Instance.ResourceLoader.InstantiatePrefab<DeveloperConsole>("DevConsole/DeveloperConsole");
			_devConsole.transform.parent = base.transform;
			_devConsole.gameObject.SetActive(value: true);
			Utilities.GetFirstChild<Button>("ConsoleCloseButton", this).onClick.AddListener(CloseConsole);
			DevConsoleApi.RegisterCommand("Pause", delegate
			{
				FlightSceneScript.Instance.TimeManager.RequestPauseChange(paused: true, userInitiated: false);
			});
			DevConsoleApi.RegisterCommand("Unpause", delegate
			{
				FlightSceneScript.Instance.TimeManager.RequestPauseChange(paused: false, userInitiated: false);
			});
			string helpMessage = string.Format("Developer Console Help: Click this entry to view help regarding the developer console. {0}Start typing to view a popup of available commands matching containing your command text. {0}Custom commands can be registered via the mod tools API (ModApi.DevConsole.IDevConsole). {0}Command arguments should be separated with a space between them. {0}For command arguments that include spaces, wrap the argument in quotes. {0}The following commands can be used to inspect and interact with the game object hierarchy. {0} /   - Find root game objects or immediate child game objects of the preceding selection. {0} //  - Find all game objects or all child game objects of the preceding selection. {0} >   - Find root components or all components of the preceding game object selection. {0} >> - Find all components or all child components of the preceding game object selection. {0} .   - Find all public methods, fields, and properties on the preceding game object or component selection. {0} ..  - Find all public and private methods, fields, and properties on the preceding game object or component selection. {0}", Environment.NewLine);
			DevConsoleApi.RegisterCommand("Help", delegate
			{
				Debug.Log(helpMessage);
			});
			DevConsoleApi.RegisterCommand("?", delegate
			{
				Debug.Log(helpMessage);
			});
			DevConsoleApi.RegisterCommand("ToggleFPS", delegate
			{
				Game.Instance.UserInterface.ToggleFps();
			});
			DevConsoleApi.RegisterCommand("Benchmark", delegate
			{
				if (!Game.InFlightScene)
				{
					Debug.Log("Must be in flight scene to start the benchmark");
				}
				((FlightSceneInterfaceScript)Game.Instance.FlightScene.FlightSceneUI).OnBenchmarkButtonClicked();
			});
			DevConsoleApi.RegisterCommand("CleanupGeneratedData", delegate
			{
				Game.Instance.CelestialDatabase.CleanupGeneratedData(forceDeleteAll: true);
				Game.Instance.CelestialDatabase.RefreshDatabase();
			});
			DevConsoleApi.RegisterCommand("CompressCraftXmlOnUpload", delegate(bool x)
			{
				UploadCraftViewModel.CompressCraftXml = x;
				Debug.Log("Craft XML compression on upload " + (UploadCraftViewModel.CompressCraftXml ? "enabled" : "disabled"));
			});
			PlanetarySystemDesignerScript.RegisterGlobalDevConsoleCommands();
			CelestialBodyDesignerScript.RegisterGlobalDevConsoleCommands();
			DevConsoleService.Instance.RaiseInitialized();
		}

		private void Update()
		{
			if (Game.Instance.Inputs.DeveloperConsole.GetButtonDownIfEnabled())
			{
				ToggleConsole();
			}
		}
	}
}
