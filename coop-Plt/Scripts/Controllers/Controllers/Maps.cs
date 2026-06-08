using System;
using System.Collections.Generic;
using Platforms;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
{
	public static class Maps
	{
		[Serializable]
		private struct BindingOverride
		{
			public string Action;

			public string Override;

			public BindingOverride(string action, string @override)
			{
				Action = action;
				Override = @override;
			}
		}

		[Serializable]
		private struct BindingOverrides
		{
			public List<BindingOverride> Overrides;

			public BindingOverrides(InputActionMap map)
			{
				Overrides = new List<BindingOverride>();
				foreach (InputAction action in map.actions)
				{
					foreach (InputBinding binding in action.bindings)
					{
						if (!string.IsNullOrEmpty(binding.overridePath))
						{
							Overrides.Add(new BindingOverride(binding.action, binding.overridePath));
						}
					}
				}
			}

			public void Apply(InputActionMap map)
			{
				foreach (BindingOverride @override in Overrides)
				{
					map.FindAction(@override.Action)?.ApplyBindingOverride(0, @override.Override);
				}
			}
		}

		private static InputActionMap Actions()
		{
			InputActionMap inputActionMap = new InputActionMap();
			inputActionMap.AddAction(Controls.Interact1, InputActionType.Button);
			inputActionMap.AddAction(Controls.Interact2, InputActionType.Button);
			inputActionMap.AddAction(Controls.Interact3, InputActionType.Button);
			inputActionMap.AddAction(Controls.Interact4, InputActionType.Button);
			inputActionMap.AddAction(Controls.Interact1Crane, InputActionType.Button);
			inputActionMap.AddAction(Controls.Interact2Crane, InputActionType.Button);
			inputActionMap.AddAction(Controls.Movement);
			inputActionMap.AddAction(Controls.StopMoving, InputActionType.Button);
			inputActionMap.AddAction(Controls.MenuTrigger, InputActionType.Button);
			inputActionMap.AddAction(Controls.MenuUp, InputActionType.Button);
			inputActionMap.AddAction(Controls.MenuDown, InputActionType.Button);
			inputActionMap.AddAction(Controls.MenuLeft, InputActionType.Button);
			inputActionMap.AddAction(Controls.MenuRight, InputActionType.Button);
			inputActionMap.AddAction(Controls.MenuSelect, InputActionType.Button);
			inputActionMap.AddAction(Controls.MenuCancel, InputActionType.Button);
			return inputActionMap;
		}

		public static void ClearOverrides(InputActionMap map)
		{
			map.RemoveAllBindingOverrides();
		}

		public static void AddOverride(InputActionMap map, InputAction action, string path)
		{
			action.ApplyBindingOverride(path);
			Debug.LogError(map.SaveBindingOverridesAsJson());
		}

		public static string GetBindingName(InputAction action)
		{
			string[] array = action.bindings[0].effectivePath.Split('/');
			return array[array.Length - 1];
		}

		public static void PerformRebinding(InputDevice device, InputAction action, Action<RebindResult> callback)
		{
			Debug.LogError("INTERACTIVE REBINDING");
			action.Disable();
			InputActionRebindingExtensions.RebindingOperation rebinding = action.PerformInteractiveRebinding();
			HashSet<string> cancel_paths = new HashSet<string>();
			HashSet<string> exclude_paths = new HashSet<string>();
			cancel_paths.Add(fix_unity_path(action.actionMap.FindAction(Controls.MenuTrigger).bindings[0].effectivePath));
			exclude_paths.Add(fix_unity_path(action.actionMap.FindAction(Controls.MenuTrigger).bindings[0].effectivePath));
			foreach (string gameplayControl in Controls.GameplayControls)
			{
				if (!(gameplayControl != action.name))
				{
					continue;
				}
				foreach (InputBinding binding in action.actionMap.FindAction(gameplayControl).bindings)
				{
					exclude_paths.Add(fix_unity_path(binding.effectivePath));
				}
			}
			rebinding.OnMatchWaitForAnother(-1f);
			rebinding.OnPotentialMatch(delegate(InputActionRebindingExtensions.RebindingOperation ro)
			{
				for (int num = ro.candidates.Count - 1; num >= 0; num--)
				{
					InputControl inputControl = ro.candidates[num];
					string item = fix_unity_path(inputControl.path);
					if (cancel_paths.Contains(item))
					{
						rebinding.Cancel();
						return;
					}
					if (exclude_paths.Contains(item))
					{
						callback(RebindResult.RejectedInUse);
						ro.RemoveCandidate(inputControl);
					}
					else
					{
						bool synthetic = inputControl.synthetic;
						bool flag = device != inputControl.device;
						flag &= !(device.path == "/Keyboard") || !(inputControl.device.path == "/Mouse");
						if (synthetic || flag)
						{
							ro.RemoveCandidate(inputControl);
						}
					}
				}
				if (ro.candidates.Count > 0)
				{
					rebinding.Complete();
				}
			});
			rebinding.OnComplete(delegate(InputActionRebindingExtensions.RebindingOperation ro)
			{
				Debug.LogError($"REBIND COMPLETED {ro.selectedControl} / {ro.action.bindings[0].overridePath}");
				callback(RebindResult.Success);
				rebinding.Dispose();
				action.Enable();
			});
			rebinding.OnCancel(delegate(InputActionRebindingExtensions.RebindingOperation ro)
			{
				Debug.LogError("REBIND FAILED");
				if (ro.canceled)
				{
					callback(RebindResult.Cancelled);
				}
				if (!ro.canceled)
				{
					callback(RebindResult.Fail);
				}
				rebinding.Dispose();
				action.Enable();
			});
			rebinding.Start();
			static string fix_unity_path(string path)
			{
				string[] array = path.Split('/');
				return array[array.Length - 1];
			}
		}

		public static InputActionMap NewGamepad(bool use_alternate_controller_layout)
		{
			InputActionMap inputActionMap = Actions();
			if (PlatformSettings.IsSwitch)
			{
				if (use_alternate_controller_layout)
				{
					inputActionMap.FindAction(Controls.Interact1).AddBinding("<Gamepad>/buttonEast");
					inputActionMap.FindAction(Controls.Interact2).AddBinding("<Gamepad>/buttonWest");
					inputActionMap.FindAction(Controls.Interact3).AddBinding("<Gamepad>/buttonNorth");
					inputActionMap.FindAction(Controls.Interact4).AddBinding("<Gamepad>/buttonSouth");
				}
				else
				{
					inputActionMap.FindAction(Controls.Interact1).AddBinding("<Gamepad>/buttonEast");
					inputActionMap.FindAction(Controls.Interact2).AddBinding("<Gamepad>/buttonNorth");
					inputActionMap.FindAction(Controls.Interact3).AddBinding("<Gamepad>/buttonSouth");
					inputActionMap.FindAction(Controls.Interact4).AddBinding("<Gamepad>/buttonWest");
				}
			}
			else
			{
				inputActionMap.FindAction(Controls.Interact1).AddBinding("<Gamepad>/buttonSouth");
				inputActionMap.FindAction(Controls.Interact2).AddBinding("<Gamepad>/buttonWest");
				inputActionMap.FindAction(Controls.Interact3).AddBinding("<Gamepad>/buttonNorth");
				inputActionMap.FindAction(Controls.Interact4).AddBinding("<Gamepad>/buttonEast");
			}
			inputActionMap.FindAction(Controls.Interact1).AddBinding("<Gamepad>/rightTrigger");
			inputActionMap.FindAction(Controls.Interact2).AddBinding("<Gamepad>/leftTrigger");
			inputActionMap.FindAction(Controls.StopMoving).AddBinding("<Gamepad>/leftShoulder");
			inputActionMap.FindAction(Controls.Movement).AddCompositeBinding("2DVector(mode=2)").With("Up", "<Gamepad>/leftStick/up")
				.With("Down", "<Gamepad>/leftStick/down")
				.With("Left", "<Gamepad>/leftStick/left")
				.With("Right", "<Gamepad>/leftStick/right");
			inputActionMap.FindAction(Controls.Movement).AddCompositeBinding("2DVector(mode=2)").With("Up", "<Gamepad>/dpad/up")
				.With("Down", "<Gamepad>/dpad/down")
				.With("Left", "<Gamepad>/dpad/left")
				.With("Right", "<Gamepad>/dpad/right");
			inputActionMap.FindAction(Controls.MenuTrigger).AddBinding("<Gamepad>/start");
			inputActionMap.FindAction(Controls.MenuUp).AddBinding("<Gamepad>/dpad/up");
			inputActionMap.FindAction(Controls.MenuUp).AddBinding("<Gamepad>/leftStick/up");
			inputActionMap.FindAction(Controls.MenuRight).AddBinding("<Gamepad>/dpad/right");
			inputActionMap.FindAction(Controls.MenuRight).AddBinding("<Gamepad>/leftStick/right");
			inputActionMap.FindAction(Controls.MenuLeft).AddBinding("<Gamepad>/dpad/left");
			inputActionMap.FindAction(Controls.MenuLeft).AddBinding("<Gamepad>/leftStick/left");
			inputActionMap.FindAction(Controls.MenuDown).AddBinding("<Gamepad>/dpad/down");
			inputActionMap.FindAction(Controls.MenuDown).AddBinding("<Gamepad>/leftStick/down");
			bool flag = false;
			if (PlatformSettings.IsSwitch || flag)
			{
				inputActionMap.FindAction(Controls.MenuSelect).AddBinding("<Gamepad>/buttonEast");
				inputActionMap.FindAction(Controls.MenuCancel).AddBinding("<Gamepad>/buttonSouth");
			}
			else
			{
				inputActionMap.FindAction(Controls.MenuSelect).AddBinding("<Gamepad>/buttonSouth");
				inputActionMap.FindAction(Controls.MenuCancel).AddBinding("<Gamepad>/buttonEast");
			}
			return inputActionMap;
		}

		public static InputActionMap NewKeyboard()
		{
			InputActionMap inputActionMap = Actions();
			inputActionMap.FindAction(Controls.Interact1).AddBinding("<Keyboard>/P");
			inputActionMap.FindAction(Controls.Interact2).AddBinding("<Keyboard>/O");
			inputActionMap.FindAction(Controls.Interact3).AddBinding("<Keyboard>/K");
			inputActionMap.FindAction(Controls.Interact4).AddBinding("<Keyboard>/L");
			inputActionMap.FindAction(Controls.Movement).AddCompositeBinding("2DVector").With("Up", "<Keyboard>/w")
				.With("Down", "<Keyboard>/s")
				.With("Left", "<Keyboard>/a")
				.With("Right", "<Keyboard>/d")
				.With("Up", "<Keyboard>/upArrow")
				.With("Down", "<Keyboard>/downArrow")
				.With("Left", "<Keyboard>/leftArrow")
				.With("Right", "<Keyboard>/rightArrow");
			inputActionMap.FindAction(Controls.StopMoving).AddBinding("<Keyboard>/space");
			inputActionMap.FindAction(Controls.MenuTrigger).AddBinding("<Keyboard>/escape");
			inputActionMap.FindAction(Controls.MenuSelect).AddBinding("<Keyboard>/enter");
			inputActionMap.FindAction(Controls.MenuUp).AddBinding("<Keyboard>/w");
			inputActionMap.FindAction(Controls.MenuDown).AddBinding("<Keyboard>/s");
			inputActionMap.FindAction(Controls.MenuLeft).AddBinding("<Keyboard>/a");
			inputActionMap.FindAction(Controls.MenuRight).AddBinding("<Keyboard>/d");
			inputActionMap.FindAction(Controls.MenuUp).AddBinding("<Keyboard>/upArrow");
			inputActionMap.FindAction(Controls.MenuDown).AddBinding("<Keyboard>/downArrow");
			inputActionMap.FindAction(Controls.MenuLeft).AddBinding("<Keyboard>/leftArrow");
			inputActionMap.FindAction(Controls.MenuRight).AddBinding("<Keyboard>/rightArrow");
			inputActionMap.FindAction(Controls.MenuSelect).AddBinding("<Keyboard>/P");
			inputActionMap.FindAction(Controls.MenuCancel).AddBinding("<Keyboard>/L");
			inputActionMap.FindAction(Controls.Interact1Crane).AddBinding("<Mouse>/leftButton");
			inputActionMap.FindAction(Controls.Interact2Crane).AddBinding("<Mouse>/rightButton");
			return inputActionMap;
		}

		public static void LoadBindingOverridesFromJson(InputActionMap map, string json)
		{
			map.RemoveAllBindingOverrides();
			if (json == "")
			{
				return;
			}
			try
			{
				JsonUtility.FromJson<BindingOverrides>(json).Apply(map);
			}
			catch (Exception arg)
			{
				Debug.LogError($"Failed to load bindings: {arg}");
				Debug.LogError("Binding string: " + json);
			}
		}

		public static string SaveBindingOverridesAsJson(InputActionMap map)
		{
			BindingOverrides bindingOverrides = new BindingOverrides(map);
			if (bindingOverrides.Overrides.Count == 0)
			{
				return "";
			}
			try
			{
				return JsonUtility.ToJson(bindingOverrides);
			}
			catch (Exception arg)
			{
				Debug.LogError($"Failed to save bindings: {arg}");
			}
			return "";
		}
	}
}
