using Heathen.SteamworksIntegration.API;
using Steamworks;
using TMPro;
using UnityEngine;

namespace Heathen.SteamworksIntegration
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/unity-engine/ui-components/input-action-name")]
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class InputActionName : MonoBehaviour
	{
		public InputActionSet set;

		public InputActionSetLayer layer;

		public InputAction action;

		private TextMeshProUGUI label;

		private void Start()
		{
			label = GetComponent<TextMeshProUGUI>();
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
