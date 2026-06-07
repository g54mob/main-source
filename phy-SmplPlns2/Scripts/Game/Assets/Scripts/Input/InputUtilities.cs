using System.Collections.Generic;
using Rewired;
using UnityEngine;

namespace Assets.Scripts.Input
{
	public static class InputUtilities
	{
		private static Dictionary<KeyCode, string> _keycodeNameOverrides;

		public static string GetBindingDisplayName(ActionElementMap actionElementMap)
		{
			if (actionElementMap != null && actionElementMap.controllerMap.controller.type == ControllerType.Keyboard)
			{
				return GetKeyCodeDisplayName(actionElementMap.keyCode, actionElementMap.elementIdentifierName);
			}
			return actionElementMap?.elementIdentifierName;
		}

		public static ControllerMap GetControllerMap(Controller controller, string category, string layout)
		{
			if (controller == null)
			{
				return null;
			}
			return ReInput.players.GetPlayer(0).controllers.maps.GetMap(controller.type, controller.id, category, layout);
		}

		public static string GetKeyCodeDisplayName(KeyCode? keyCode, string defaultDisplayName)
		{
			if (!keyCode.HasValue)
			{
				return defaultDisplayName;
			}
			if (_keycodeNameOverrides == null)
			{
				InitializeKeycodeNameOverrides();
			}
			if (_keycodeNameOverrides.TryGetValue(keyCode.Value, out var value))
			{
				return value;
			}
			return defaultDisplayName;
		}

		private static void InitializeKeycodeNameOverrides()
		{
			_keycodeNameOverrides = new Dictionary<KeyCode, string>();
			_keycodeNameOverrides[KeyCode.None] = string.Empty;
			_keycodeNameOverrides[KeyCode.Return] = "Enter";
		}
	}
}
