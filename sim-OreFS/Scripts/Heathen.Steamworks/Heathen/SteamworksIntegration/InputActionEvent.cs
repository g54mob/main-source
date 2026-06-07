using System.Linq;
using Heathen.SteamworksIntegration.API;
using UnityEngine;

namespace Heathen.SteamworksIntegration
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/for-unity-game-engine/components/input-action-event")]
	public class InputActionEvent : MonoBehaviour
	{
		[SerializeField]
		private InputAction action;

		public ActionUpdateEvent changed;

		private void Start()
		{
			Input.Client.EventInputDataChanged.AddListener(HandleEvent);
		}

		private void OnDestroy()
		{
			Input.Client.EventInputDataChanged.RemoveListener(HandleEvent);
		}

		private void HandleEvent(InputControllerData controller)
		{
			InputActionUpdate arg = controller.changes.FirstOrDefault((InputActionUpdate p) => p.name == action.ActionName);
			if (action != null && arg.name == action.ActionName)
			{
				changed.Invoke(arg);
			}
		}
	}
}
