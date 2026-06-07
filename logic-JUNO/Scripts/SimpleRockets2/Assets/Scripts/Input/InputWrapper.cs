using System;
using System.Collections.Generic;
using System.Linq;
using ModApi.Input;
using Rewired;
using UnityEngine;

namespace Assets.Scripts.Input
{
	internal static class InputWrapper
	{
		public const string DefaultLayoutName = "Default";

		private static Dictionary<string, bool> _axisOverides = new Dictionary<string, bool>();

		private static Player _player;

		public static Vector2 MouseScreenPosition => Player.controllers.Mouse?.screenPosition ?? Vector2.zero;

		public static Player Player
		{
			get
			{
				if (_player == null)
				{
					_player = ReInput.players.GetPlayer(0);
				}
				return _player;
			}
		}

		public static event EventHandler<EventArgs> ControlMapsChanged;

		public static List<string> GetAllActionIds()
		{
			List<string> list = new List<string>();
			foreach (InputAction action in ReInput.mapping.Actions)
			{
				if (!list.Contains(action.name))
				{
					list.Add(action.name);
				}
			}
			return list;
		}

		public static bool GetAnyKeyboardOrControllerButtonDown()
		{
			if (!Player.controllers.Keyboard.GetAnyButtonDown())
			{
				return Player.controllers.Joysticks.Any((Joystick x) => x.GetAnyButtonDown());
			}
			return true;
		}

		public static float GetAxis(string axis)
		{
			return Player.GetAxis(axis);
		}

		public static float GetAxis(int axis)
		{
			return Player.GetAxis(axis);
		}

		public static bool GetButton(string button)
		{
			return Player.GetButton(button);
		}

		public static bool GetButton(int button)
		{
			return Player.GetButton(button);
		}

		public static bool GetButtonDown(int button)
		{
			return Player.GetButtonDown(button);
		}

		public static bool GetButtonRepeating(string button)
		{
			return Player.GetButtonRepeating(button);
		}

		public static bool GetButtonRepeating(int button)
		{
			return Player.GetButtonRepeating(button);
		}

		public static float GetButtonTimePressed(string button)
		{
			return (float)Player.GetButtonTimePressed(button);
		}

		public static float GetButtonTimePressed(int button)
		{
			return (float)Player.GetButtonTimePressed(button);
		}

		public static bool GetButtonUp(string button)
		{
			return Player.GetButtonUp(button);
		}

		public static bool GetButtonUp(int button)
		{
			return Player.GetButtonUp(button);
		}

		public static bool LastInputWasNormalAxis(IGameInput input)
		{
			if (string.IsNullOrEmpty(input.Id))
			{
				return false;
			}
			if (_axisOverides.TryGetValue(input.Id, out var value))
			{
				return !value;
			}
			return false;
		}

		public static void OnControlsChanged()
		{
			InputWrapper.ControlMapsChanged?.Invoke(null, new EventArgs());
		}

		public static void OnVersionUpgrade(Version newVersion, Version oldVersion)
		{
		}

		public static void SetControllerUINavigationEnabled(bool enabled)
		{
			Player.controllers.maps.SetMapsEnabled(enabled, "Default");
		}

		public static void SetEnabledControlCategories(params string[] categories)
		{
			Player.controllers.maps.SetAllMapsEnabled(state: false);
			for (int i = 0; i < categories.Length; i++)
			{
				Player.controllers.maps.SetMapsEnabled(state: true, categories[i]);
			}
			LogAllMapInformation();
			InputWrapper.ControlMapsChanged?.Invoke(null, new EventArgs());
		}

		public static void SetLastInput(IGameInput input, bool wasAxis)
		{
			string id = input.Id;
			if (!string.IsNullOrEmpty(id))
			{
				_axisOverides[id] = !wasAxis;
			}
		}

		public static void SetMapEnabled(string category, bool enabled)
		{
			Player.controllers.maps.SetMapsEnabled(enabled, category);
		}

		public static void UpdateLastInput(IGameInput input)
		{
			string id = input.Id;
			if (string.IsNullOrEmpty(id))
			{
				return;
			}
			if (!_axisOverides.ContainsKey(id))
			{
				_axisOverides[id] = true;
			}
			IList<InputActionSourceData> currentInputSources = Player.GetCurrentInputSources(id);
			bool value = _axisOverides[id];
			for (int i = 0; i < currentInputSources.Count; i++)
			{
				ActionElementMap actionElementMap = currentInputSources[i].actionElementMap;
				if (actionElementMap.elementType != ControllerElementType.Axis || actionElementMap.axisType != AxisType.Normal || currentInputSources[i].controllerType != ControllerType.Joystick)
				{
					value = true;
					break;
				}
				value = false;
			}
			_axisOverides[id] = value;
		}

		internal static bool GetButtonDown(string button)
		{
			return Player.GetButtonDown(button);
		}

		private static void CreateKeyboardAssignment(string actionName, string actionCategory, KeyCode key, ModifierKeyFlags modifiers, Pole axisContribution = Pole.Positive)
		{
			foreach (ActionElementMap item in Player.controllers.maps.ElementMapsWithAction(ControllerType.Keyboard, actionName, skipDisabledMaps: false))
			{
				if (item.axisContribution == axisContribution)
				{
					return;
				}
			}
			int actionId = ReInput.mapping.GetActionId(actionName);
			ElementAssignment elementAssignment = ElementAssignment.KeyboardKeyAssignment(key, modifiers, actionId, axisContribution);
			Player.controllers.maps.GetMap(ControllerType.Keyboard, Player.controllers.Keyboard.id, actionCategory, "Default").CreateElementMap(elementAssignment);
		}

		private static void LogAllMapInformation()
		{
		}
	}
}
