using Heathen.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

namespace Heathen.SteamworksIntegration
{
	public class UGUIInputActionName : MonoBehaviour
	{
		public InputActionSet set;

		public InputActionSetLayer layer;

		public InputAction action;

		private Text label;

		private void Start()
		{
			label = GetComponent<Text>();
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
			RefreshName();
		}

		private void OnEnable()
		{
			RefreshName();
		}

		public void RefreshName()
		{
			if (!(action != null) || !(label != null))
			{
				return;
			}
			if (set != null)
			{
				InputHandle_t[] controllers = Input.Client.Controllers;
				if (controllers.Length != 0)
				{
					string[] inputNames = action.GetInputNames(controllers[0], set);
					if (inputNames.Length != 0)
					{
						label.text = inputNames[0];
					}
				}
			}
			else
			{
				if (!(layer != null))
				{
					return;
				}
				InputHandle_t[] controllers2 = Input.Client.Controllers;
				if (controllers2.Length != 0)
				{
					string[] inputNames2 = action.GetInputNames(controllers2[0], layer);
					if (inputNames2.Length != 0)
					{
						label.text = inputNames2[0];
					}
				}
			}
		}
	}
}
