using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Assets.Scripts.Flight;
using Assets.Scripts.Input.XR;
using Assets.Scripts.Settings;
using MSP_Input;
using Rewired;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Input
{
	public static class InputWrapper
	{
		private struct MouseAsJoystickHelper
		{
			public float HalfDeadzone;

			public float MidX;

			public float MidY;

			public float Range;

			public int ScreenHeight;

			public int ScreenWidth;

			public Vector2 GetMouseAxis()
			{
				Vector2 zero = Vector2.zero;
				UpdateIfNecessary();
				Vector2 mouseScreenPosition = MouseScreenPosition;
				if (mouseScreenPosition.x > MidX)
				{
					float num = mouseScreenPosition.x - MidX - HalfDeadzone;
					zero.x = Mathf.Clamp01(num / Range);
				}
				else
				{
					float num2 = MidX - HalfDeadzone - mouseScreenPosition.x;
					zero.x = 0f - Mathf.Clamp01(num2 / Range);
				}
				if (mouseScreenPosition.y > MidY)
				{
					float num3 = mouseScreenPosition.y - MidY - HalfDeadzone;
					zero.y = Mathf.Clamp01(num3 / Range);
				}
				else
				{
					float num4 = MidY - HalfDeadzone - mouseScreenPosition.y;
					zero.y = 0f - Mathf.Clamp01(num4 / Range);
				}
				if ((bool)Game.Instance.Settings.Gameplay.MouseJoystick.MouseJoystickInvertPitch)
				{
					zero.y *= -1f;
				}
				return zero;
			}

			private void UpdateIfNecessary()
			{
				if (ScreenWidth != Screen.width || ScreenHeight != Screen.height || MouseAsJoystickSettingsChanged)
				{
					ScreenWidth = Screen.width;
					ScreenHeight = Screen.height;
					MouseJoystickSettings mouseJoystick = Game.Instance.Settings.Gameplay.MouseJoystick;
					int num = Mathf.Min(ScreenWidth, ScreenHeight);
					MidX = (float)ScreenWidth / 2f;
					MidY = (float)ScreenHeight / 2f;
					HalfDeadzone = (float)num * (float)mouseJoystick.MouseJoystickDeadzone / 2f;
					Range = (float)num / 2f * (float)mouseJoystick.MouseJoystickRange - HalfDeadzone;
					MouseAsJoystickSettingsChanged = false;
				}
			}
		}

		public const string MapCategoryCharacter = "Character";

		public const string MapCategoryCraft = "Craft";

		public const string MapCategoryDefault = "Default";

		public const string MapCategoryDesigner = "Designer";

		public const string MapCategoryOther = "Other";

		public const string MapCategoryWorld = "World";

		private static Dictionary<string, bool> _axisOverides = new Dictionary<string, bool>();

		private static List<string> _craftActionIds;

		private static MouseAsJoystickHelper _mouseAsJoystickHelper;

		private static Player _player;

		public static bool MouseAsJoystickSettingsChanged { get; set; }

		public static Vector2 MouseScreenPosition => Player.controllers.Mouse.screenPosition;

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

		public static event EventHandler<EventArgs> OnControlsChanged;

		public static void ApplySceneControls()
		{
			string name = SceneManager.GetActiveScene().name;
			if (!(name == "Designer"))
			{
				if (name == "Terrain")
				{
					if (FlightSceneScript.Instance?.Designer?.Active == true)
					{
						UseDesignerSceneControls();
					}
					else
					{
						UseFlightSceneControls();
					}
				}
				else
				{
					UseMenuSceneControls();
				}
			}
			else
			{
				UseDesignerSceneControls();
			}
			InputWrapper.OnControlsChanged?.Invoke(null, new EventArgs());
		}

		public static void CalibrateGyro()
		{
			float devicePitch = 0f;
			float deviceRoll = 0f;
			GyroAccel.GetDevicePitchAndRollFromGravityVector(out devicePitch, out deviceRoll);
			GyroAccel.SetPitchOffset(devicePitch);
		}

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

		public static bool GetButtonDown(string button)
		{
			return Player.GetButtonDown(button);
		}

		public static bool GetButtonDown(int button)
		{
			return Player.GetButtonDown(button);
		}

		public static bool GetButtonUp(string button)
		{
			return Player.GetButtonUp(button);
		}

		public static bool GetButtonUp(int button)
		{
			return Player.GetButtonUp(button);
		}

		public static ReadOnlyCollection<string> GetCraftActionsIds()
		{
			if (_craftActionIds == null)
			{
				_craftActionIds = (from x in ReInput.mapping.ActionsInCategory("Craft")
					select x.name).ToList();
			}
			return _craftActionIds.AsReadOnly();
		}

		public static Vector2 GetMouseAsJoystickAxis(bool overrideEnabled = false)
		{
			if (Game.Instance.Settings.Gameplay.MouseJoystick.MouseJoystickEnabled.Value || overrideEnabled)
			{
				return _mouseAsJoystickHelper.GetMouseAxis();
			}
			return Vector2.zero;
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

		public static void OnVersionUpgrade(Version newVersion, Version oldVersion)
		{
		}

		public static void SetControllerUINavigationEnabled(bool enabled)
		{
			Player.controllers.maps.SetMapsEnabled(enabled, "Default");
		}

		public static void SetLastInput(IGameInput input, bool wasAxis)
		{
			string id = input.Id;
			if (!string.IsNullOrEmpty(id))
			{
				_axisOverides[id] = !wasAxis;
			}
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

		public static void UseCharacterControls()
		{
			Player.controllers.maps.SetMapsEnabled(state: false, "Craft");
			Player.controllers.maps.SetMapsEnabled(state: true, "Character");
			InputWrapper.OnControlsChanged?.Invoke(null, new EventArgs());
		}

		public static void UseCraftControls()
		{
			Player.controllers.maps.SetMapsEnabled(state: true, "Craft");
			Player.controllers.maps.SetMapsEnabled(state: false, "Character");
			InputWrapper.OnControlsChanged?.Invoke(null, new EventArgs());
		}

		public static void UseDesignerSceneControls()
		{
			Player.controllers.maps.SetAllMapsEnabled(state: false);
			Player.controllers.maps.SetMapsEnabled(state: true, "Designer");
			Player.controllers.maps.SetMapsEnabled(state: true, "Other");
			if (Game.Instance.Device.IsVRBuild)
			{
				XRInputs.Flight.ActionMap.Disable();
				XRInputs.Menu.ActionMap.Disable();
				XRInputs.PoseLeftHand.ActionMap.Disable();
				XRInputs.PoseRightHand.ActionMap.Disable();
			}
			LogAllMapInformation();
		}

		public static void UseFlightSceneControls()
		{
			Player.controllers.maps.SetAllMapsEnabled(state: false);
			Player.controllers.maps.SetMapsEnabled(state: true, "World");
			Player.controllers.maps.SetMapsEnabled(state: true, "Other");
			if (FlightSceneScript.Instance?.LocalPlayer != null)
			{
				if (FlightSceneScript.Instance.LocalPlayer.Aircraft != null)
				{
					UseCraftControls();
				}
				else
				{
					UseCharacterControls();
				}
			}
			else
			{
				UseCraftControls();
			}
			if (Game.Instance.Device.IsVRBuild)
			{
				XRInputs.Flight.ActionMap.Enable();
				XRInputs.Menu.ActionMap.Disable();
				XRInputs.PoseLeftHand.ActionMap.Enable();
				XRInputs.PoseRightHand.ActionMap.Enable();
				XRInputs.Flight.Throttle.Enable();
				XRInputs.Flight.Vtol.Disable();
			}
			LogAllMapInformation();
		}

		public static void UseMenuSceneControls()
		{
			Player.controllers.maps.SetAllMapsEnabled(state: false);
			Player.controllers.maps.SetMapsEnabled(state: true, "Default");
			Player.controllers.maps.SetMapsEnabled(state: true, "Other");
			if (Game.Instance.Device.IsVRBuild)
			{
				XRInputs.Flight.ActionMap.Disable();
				XRInputs.Menu.ActionMap.Enable();
				XRInputs.PoseLeftHand.ActionMap.Enable();
				XRInputs.PoseRightHand.ActionMap.Enable();
			}
			LogAllMapInformation();
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

		private static void CreateMouseWheelAssignment(string actionName, string actionCategory)
		{
			if (!Player.controllers.maps.ElementMapsWithAction(ControllerType.Mouse, actionName, skipDisabledMaps: false).Any())
			{
				int actionId = ReInput.mapping.GetActionId(actionName);
				ElementAssignment elementAssignment = ElementAssignment.FullAxisAssignment(Player.controllers.Mouse.AxisElementIdentifiers.Where((ControllerElementIdentifier x) => x.name.ToLower().Contains("wheel")).FirstOrDefault().id, actionId, invert: false);
				Player.controllers.maps.GetMap(ControllerType.Mouse, Player.controllers.Mouse.id, actionCategory, "Default").CreateElementMap(elementAssignment);
			}
		}

		private static void LogAllMapInformation()
		{
		}
	}
}
