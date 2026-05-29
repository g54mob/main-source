using System.Collections.Generic;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;

namespace HeathenEngineering.SteamworksIntegration
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/for-unity-game-engine/components/steam-input-manager")]
	public class SteamInputManager : MonoBehaviour
	{
		public static SteamInputManager current;

		[Tooltip("If set to true then we will attempt to force Steam to use input for this app on start.\nThis is generally only needed in editor testing.")]
		[SerializeField]
		private bool forceInput = true;

		[Tooltip("If set to true the system will update every input action every frame for every controller found")]
		public bool autoUpdate = true;

		public ControllerDataEvent evtInputDataChanged;

		private static InputHandle_t[] controllers = null;

		public static bool AutoUpdate
		{
			get
			{
				if (!(current != null))
				{
					return false;
				}
				return current.autoUpdate;
			}
			set
			{
				if (current != null)
				{
					current.autoUpdate = value;
				}
			}
		}

		public static List<InputControllerData> Controllers { get; private set; } = new List<InputControllerData>();

		private void Start()
		{
			current = this;
			Input.Client.EventInputDataChanged.AddListener(evtInputDataChanged.Invoke);
			if (!App.Initialized)
			{
				App.evtSteamInitialized.AddListener(HandleInitalization);
			}
			else
			{
				HandleInitalization();
			}
		}

		private void HandleInitalization()
		{
			App.evtSteamInitialized.RemoveListener(HandleInitalization);
			if (forceInput)
			{
				Application.OpenURL($"steam://forceinputappid/{App.Id}");
				Invoke("RefreshNow", 1f);
			}
			else
			{
				RefreshControllers();
			}
		}

		private void OnDestroy()
		{
			if (current == this)
			{
				current = null;
			}
			Input.Client.EventInputDataChanged.RemoveListener(evtInputDataChanged.Invoke);
			if (forceInput)
			{
				Application.OpenURL("steam://forceinputappid/0");
			}
		}

		private void Update()
		{
			if (autoUpdate)
			{
				UpdateAll();
			}
		}

		public static void UpdateAll()
		{
			if (Input.Client.Initialized && controllers != null && controllers.Length != 0)
			{
				Controllers.Clear();
				InputHandle_t[] array = controllers;
				foreach (InputHandle_t controller in array)
				{
					Controllers.Add(Input.Client.Update(controller));
				}
			}
		}

		[ContextMenu("Refresh Controllers")]
		public void RefreshNow()
		{
			RefreshControllers();
		}

		public static void RefreshControllers()
		{
			if (Input.Client.Initialized)
			{
				controllers = Input.Client.Controllers;
				Debug.Log($"Controllers refreshed found count {((controllers != null) ? controllers.Length : 0)}");
			}
		}
	}
}
