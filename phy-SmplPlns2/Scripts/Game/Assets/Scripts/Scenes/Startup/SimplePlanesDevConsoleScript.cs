using System;
using System.Collections;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design;
using Assets.Scripts.Flight;
using Assets.Scripts.Input;
using Jundroo.Common.Utils;
using Jundroo.DevConsole;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Scenes.Startup
{
	public class SimplePlanesDevConsoleScript : MonoBehaviour
	{
		public DeveloperConsole DevConsolePrefab;

		private DeveloperConsole _devConsole;

		private GameObject _fpsDisplay;

		private GameObject _inputBlocker;

		private bool _tripleTouch;

		public static bool IsConsoleOpen { get; private set; }

		public static bool OpenedThisSession { get; private set; }

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

		protected virtual void Awake()
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
		}

		protected virtual void OnDestroy()
		{
			UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
		}

		protected virtual void Update()
		{
			if (UnityEngine.Input.touchCount >= 3 && !_tripleTouch && Game.Instance.Settings.App.DevConsoleTapEnabled)
			{
				_tripleTouch = true;
				ToggleConsole();
			}
			else if (UnityEngine.Input.touchCount == 0 && _tripleTouch)
			{
				_tripleTouch = false;
			}
			if (GameInputs.Instance.DeveloperConsole.GetButtonDownIfEnabled())
			{
				ToggleConsole();
			}
		}

		private IEnumerator ActivateInputField()
		{
			yield return new WaitForFixedUpdate();
			_devConsole.CommandInputField.ActivateInputField();
		}

		private void CloseConsole()
		{
			_devConsole.CommandInputField.DeactivateInputField();
			EventSystem.current.SetSelectedGameObject(null);
			if (_inputBlocker != null)
			{
				UnityEngine.Object.Destroy(_inputBlocker);
				_inputBlocker = null;
			}
			_devConsole.CloseConsole();
			_devConsole.gameObject.SetActive(value: false);
			IsConsoleOpen = false;
			PauseManager.RequestPauseChange(paused: false, userInitiated: false);
		}

		private void Initialize()
		{
			_devConsole = UnityEngine.Object.Instantiate(DevConsolePrefab);
			_devConsole.transform.parent = base.transform;
			_devConsole.gameObject.SetActive(value: true);
			Utilities.GetFirstChild<Button>("ConsoleCloseButton", this).onClick.AddListener(CloseConsole);
			DevConsoleApi.RegisterCommand("Pause", delegate
			{
				PauseManager.RequestPauseChange(paused: true, userInitiated: false);
			});
			DevConsoleApi.RegisterCommand("Unpause", delegate
			{
				PauseManager.RequestPauseChange(paused: false, userInitiated: false);
			});
			string helpMessage = string.Format("Developer Console Help: Click this entry to view help regarding the developer console. {0}Start typing to view a popup of available commands matching containing your command text. {0}Custom commands can be registered via the mod tools API (Jundroo.SimplePlanes.ModTools.DevConsole.IDevConsole). {0}Command arguments should be separated with a space between them. {0}For command arguments that include spaces, wrap the argument in quotes. {0}The following commands can be used to inspect and interact with the game object hierarchy. {0} /   - Find root game objects or immediate child game objects of the preceding selection. {0} //  - Find all game objects or all child game objects of the preceding selection. {0} >   - Find root components or all components of the preceding game object selection. {0} >> - Find all components or all child components of the preceding game object selection. {0} .   - Find all public methods, fields, and properties on the preceding game object or component selection. {0} ..  - Find all public and private methods, fields, and properties on the preceding game object or component selection. {0}", System.Environment.NewLine);
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
				if (_fpsDisplay == null)
				{
					_fpsDisplay = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Gui/FpsCounter"));
				}
				else
				{
					_fpsDisplay.SetActive(!_fpsDisplay.activeSelf);
				}
			});
			DevConsoleApi.RegisterCommand("SetWindSpeed", delegate(float x, float y, float z)
			{
				AircraftScript aircraftScript = FlightSceneScript.Instance.LocalPlayer?.Aircraft;
				if (aircraftScript != null)
				{
					aircraftScript.WindVelocity = new Vector3(x, y, z);
				}
			});
			DevConsoleApi.RegisterCommand("SelectPartById", delegate(int id)
			{
				AircraftScript aircraftScript = Designer.Instance?.Aircraft;
				if (aircraftScript != null)
				{
					foreach (PartData part in aircraftScript.Aircraft.Assembly.Parts)
					{
						if (part.Id == id)
						{
							Designer.Instance.SelectedPart = part.PartScript;
							Debug.Log($"Selected part {id}");
							return;
						}
					}
				}
				Debug.Log($"Failed to select part {id}");
			});
			DevConsoleApi.RegisterCommand("ClearPlayerPrefsImmediately", delegate
			{
				PlayerPrefs.DeleteAll();
				PlayerPrefs.Save();
				Debug.Log("Player Prefs have been cleared.  Please restart the game so changes can be properly finalized.");
			});
			DevConsoleApi.RegisterCommand("RestoreAllStockAircraft", delegate
			{
				Game.Instance.CraftDatabase.RestoreStockCraft();
			});
			DevConsoleApi.RegisterCommand("RestoreStockAircraft", delegate(string name)
			{
				Game.Instance.CraftDatabase.RestoreStockCraft(name);
			});
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			_ = scene.name == "Startup";
		}

		private void OpenConsole()
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
			if (_inputBlocker != null)
			{
				UnityEngine.Object.Destroy(_inputBlocker);
				_inputBlocker = null;
			}
			StartCoroutine(ActivateInputField());
			IsConsoleOpen = true;
			PauseManager.RequestPauseChange(paused: true, userInitiated: false);
		}
	}
}
