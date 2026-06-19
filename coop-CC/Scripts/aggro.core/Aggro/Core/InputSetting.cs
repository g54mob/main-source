using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Aggro.Core
{
	public class InputSetting : AggroSettingBase
	{
		public struct Action
		{
			public InputAction action;

			public InputBinding? kbmBinding;

			public InputBinding? gamepadBinding;

			public Action(InputAction action, InputBinding? kbmBinding, InputBinding? gamepadBinding)
			{
				this.action = action;
				this.kbmBinding = kbmBinding;
				this.gamepadBinding = gamepadBinding;
			}
		}

		public struct RebindingAction
		{
			public InputAction action;

			public bool enabled;

			public InputBinding binding;
		}

		private readonly Action[] _actions;

		private string _kbmKey;

		private string _gamepadKey;

		private InputMode _rebindMode;

		private List<RebindingAction> _rebindingActions = new List<RebindingAction>();

		private readonly InputRebindKbmMask _kbmMask;

		private readonly InputRebindGamepadMask _gamepadMask;

		private readonly int _layer;

		private readonly int _layerCollision;

		private InputActionRebindingExtensions.RebindingOperation _rebindOperation;

		public bool isRebinding => _rebindOperation != null;

		public InputMode rebindMode => _rebindMode;

		public InputSetting(InputAction action, InputBinding? kbmBinding, InputRebindKbmMask kbmMask, InputBinding? gamepadBinding, InputRebindGamepadMask gamepadMask, int layer = 0, int layerCollision = int.MinValue)
		{
			_actions = new Action[1]
			{
				new Action(action, kbmBinding, gamepadBinding)
			};
			_kbmMask = kbmMask;
			_gamepadMask = gamepadMask;
			_layer = layer;
			_layerCollision = layerCollision;
		}

		public InputSetting(Action[] actions, InputRebindKbmMask kbmMask, InputRebindGamepadMask gamepadMask, int layer = 0, int layerCollision = int.MinValue)
		{
			_actions = new Action[actions.Length];
			Array.Copy(actions, _actions, actions.Length);
			_kbmMask = kbmMask;
			_gamepadMask = gamepadMask;
			_layer = layer;
			_layerCollision = layerCollision;
		}

		protected override void Initialize(string preferencesKey)
		{
			_kbmKey = preferencesKey + "-kbm";
			_gamepadKey = preferencesKey + "-gamepad";
		}

		public override void SetToDefault()
		{
			for (int i = 0; i < _actions.Length; i++)
			{
				Action action = _actions[i];
				if (action.kbmBinding.HasValue)
				{
					action.action.RemoveBindingOverride(action.kbmBinding.Value);
				}
				if (action.gamepadBinding.HasValue)
				{
					action.action.RemoveBindingOverride(action.gamepadBinding.Value);
				}
			}
			PlayerPrefs.DeleteKey(_kbmKey);
			PlayerPrefs.DeleteKey(_gamepadKey);
			Save();
		}

		protected override void SaveToPrefs(string preferencesKey)
		{
		}

		protected override void LoadFromPrefs(string preferencesKey)
		{
			string text = PlayerPrefs.GetString(_kbmKey, null);
			string text2 = PlayerPrefs.GetString(_gamepadKey, null);
			for (int i = 0; i < _actions.Length; i++)
			{
				Action action = _actions[i];
				if (action.kbmBinding.HasValue)
				{
					if (!string.IsNullOrEmpty(text))
					{
						action.action.ApplyBindingOverride(action.action.GetBindingIndex(action.kbmBinding.Value), text);
					}
					else
					{
						action.action.RemoveBindingOverride(action.kbmBinding.Value);
					}
				}
				if (action.gamepadBinding.HasValue)
				{
					if (!string.IsNullOrEmpty(text2))
					{
						action.action.ApplyBindingOverride(action.action.GetBindingIndex(action.gamepadBinding.Value), text2);
					}
					else
					{
						action.action.RemoveBindingOverride(action.gamepadBinding.Value);
					}
				}
			}
		}

		public bool SupportsMode(InputMode mode)
		{
			return mode switch
			{
				InputMode.None => false, 
				InputMode.KBM => _kbmMask != InputRebindKbmMask.None, 
				InputMode.Gamepad => _gamepadMask != InputRebindGamepadMask.None, 
				_ => throw new InvalidEnumException(), 
			};
		}

		public bool IsReadOnly(InputMode mode)
		{
			return mode switch
			{
				InputMode.None => true, 
				InputMode.KBM => (_kbmMask & InputRebindKbmMask.ReadOnly) != 0, 
				InputMode.Gamepad => (_gamepadMask & InputRebindGamepadMask.ReadOnly) != 0, 
				_ => throw new InvalidEnumException(), 
			};
		}

		public bool TryPerformRebinding(InputMode mode)
		{
			_rebindingActions.Clear();
			switch (mode)
			{
			case InputMode.KBM:
			{
				if (_kbmMask == InputRebindKbmMask.None)
				{
					return false;
				}
				for (int j = 0; j < _actions.Length; j++)
				{
					Action action2 = _actions[j];
					if (action2.kbmBinding.HasValue)
					{
						RebindingAction item2 = new RebindingAction
						{
							action = action2.action,
							enabled = action2.action.enabled,
							binding = action2.kbmBinding.Value
						};
						_rebindingActions.Add(item2);
						break;
					}
				}
				break;
			}
			case InputMode.Gamepad:
			{
				if (_gamepadMask == InputRebindGamepadMask.None)
				{
					return false;
				}
				for (int i = 0; i < _actions.Length; i++)
				{
					Action action = _actions[i];
					if (action.gamepadBinding.HasValue)
					{
						RebindingAction item = new RebindingAction
						{
							action = action.action,
							enabled = action.action.enabled,
							binding = action.gamepadBinding.Value
						};
						_rebindingActions.Add(item);
						break;
					}
				}
				break;
			}
			default:
				throw new InvalidEnumException();
			}
			if (_rebindingActions.Count == 0)
			{
				Debug.LogError("Could not find an action to rebind?");
				return false;
			}
			for (int k = 0; k < _rebindingActions.Count; k++)
			{
				_rebindingActions[k].action.Disable();
			}
			_rebindMode = mode;
			_rebindOperation = _rebindingActions[0].action.PerformInteractiveRebinding(_rebindingActions[0].action.GetBindingIndex(_rebindingActions[0].binding));
			_rebindOperation.WithCancelingThrough("<Keyboard>/escape");
			switch (mode)
			{
			case InputMode.KBM:
				_rebindOperation.WithControlsExcluding("<Keyboard>/escape");
				_rebindOperation.WithControlsExcluding("<Keyboard>/leftMeta");
				_rebindOperation.WithControlsExcluding("<Keyboard>/rightMeta");
				_rebindOperation.WithControlsExcluding("<Keyboard>/contextMenu");
				_rebindOperation.WithControlsExcluding("<Keyboard>/anyKey");
				_rebindOperation.WithControlsExcluding("<Pointer>/press");
				if (!HasKbmFlag(InputRebindKbmMask.MouseButtons))
				{
					_rebindOperation.WithControlsExcluding("<Mouse>/leftButton");
					_rebindOperation.WithControlsExcluding("<Mouse>/rightButton");
					_rebindOperation.WithControlsExcluding("<Mouse>/middleButton");
				}
				if (!HasKbmFlag(InputRebindKbmMask.MouseScroll))
				{
					_rebindOperation.WithControlsExcluding("<Mouse>/scroll/*");
				}
				else
				{
					_rebindOperation.WithExpectedControlType("axis");
					_rebindOperation.WithControlsExcluding("<Mouse>/scroll/y");
					_rebindOperation.WithControlsExcluding("<Mouse>/scroll/x");
				}
				if (!HasKbmFlag(InputRebindKbmMask.KeyboardKeys))
				{
					_rebindOperation.WithControlsExcluding("<Keyboard>/*");
				}
				break;
			case InputMode.Gamepad:
				_rebindOperation.WithControlsExcluding("<Gamepad>/start");
				_rebindOperation.WithControlsExcluding("<Gamepad>/select");
				_rebindOperation.WithControlsExcluding("<Gamepad>/leftStick/*");
				_rebindOperation.WithControlsExcluding("<Gamepad>/rightStick/*");
				_rebindOperation.WithControlsExcluding("<DualSenseGamepadHID>/*");
				if (!HasGamepadFlag(InputRebindGamepadMask.FaceButtons))
				{
					_rebindOperation.WithControlsExcluding("<Gamepad>/buttonEast");
					_rebindOperation.WithControlsExcluding("<Gamepad>/buttonSouth");
					_rebindOperation.WithControlsExcluding("<Gamepad>/buttonWest");
					_rebindOperation.WithControlsExcluding("<Gamepad>/buttonNorth");
				}
				if (!HasGamepadFlag(InputRebindGamepadMask.ShoulderTriggers))
				{
					_rebindOperation.WithControlsExcluding("<Gamepad>/rightTrigger");
					_rebindOperation.WithControlsExcluding("<Gamepad>/leftTrigger");
				}
				if (!HasGamepadFlag(InputRebindGamepadMask.ShoulderButtons))
				{
					_rebindOperation.WithControlsExcluding("<Gamepad>/rightShoulder");
					_rebindOperation.WithControlsExcluding("<Gamepad>/leftShoulder");
				}
				if (!HasGamepadFlag(InputRebindGamepadMask.DpadButtons))
				{
					_rebindOperation.WithControlsExcluding("<Gamepad>/dpad/*");
				}
				if (!HasGamepadFlag(InputRebindGamepadMask.StickButtons))
				{
					_rebindOperation.WithControlsExcluding("<Gamepad>/leftStickPress");
					_rebindOperation.WithControlsExcluding("<Gamepad>/rightStickPress");
				}
				break;
			default:
				throw new InvalidEnumException();
			}
			_rebindOperation.OnApplyBinding(OnApplyBinding);
			_rebindOperation.OnComplete(OnBindingComplete);
			_rebindOperation.OnCancel(OnBindingCancel);
			_rebindOperation.Start();
			return true;
		}

		public void CancelRebind()
		{
			if (_rebindOperation != null)
			{
				_rebindOperation.Cancel();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool HasKbmFlag(InputRebindKbmMask mask)
		{
			return (_kbmMask & mask) == mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool HasGamepadFlag(InputRebindGamepadMask mask)
		{
			return (_gamepadMask & mask) == mask;
		}

		private void OnApplyBinding(InputActionRebindingExtensions.RebindingOperation op, string binding)
		{
			switch (_rebindMode)
			{
			case InputMode.KBM:
			{
				for (int j = 0; j < _actions.Length; j++)
				{
					Action action2 = _actions[j];
					if (action2.kbmBinding.HasValue)
					{
						int bindingIndex2 = action2.action.GetBindingIndex(action2.kbmBinding.Value);
						action2.action.ApplyBindingOverride(bindingIndex2, binding);
					}
				}
				break;
			}
			case InputMode.Gamepad:
			{
				for (int i = 0; i < _actions.Length; i++)
				{
					Action action = _actions[i];
					if (action.gamepadBinding.HasValue)
					{
						int bindingIndex = action.action.GetBindingIndex(action.gamepadBinding.Value);
						action.action.ApplyBindingOverride(bindingIndex, binding);
					}
				}
				break;
			}
			default:
				throw new InvalidEnumException();
			}
		}

		private void OnBindingComplete(InputActionRebindingExtensions.RebindingOperation op)
		{
			switch (_rebindMode)
			{
			case InputMode.KBM:
				PlayerPrefs.SetString(_kbmKey, GetKbmPath());
				break;
			case InputMode.Gamepad:
				PlayerPrefs.SetString(_gamepadKey, GetGamepadPath());
				break;
			default:
				throw new InvalidEnumException();
			}
			_rebindMode = InputMode.None;
			_rebindOperation.Dispose();
			_rebindOperation = null;
			for (int i = 0; i < _rebindingActions.Count; i++)
			{
				RebindingAction rebindingAction = _rebindingActions[i];
				if (rebindingAction.enabled)
				{
					rebindingAction.action.Enable();
				}
			}
			AggroSettings.IncrementSaveVersion();
			AggroSettingsManagerUI.SuppressInput();
		}

		private void OnBindingCancel(InputActionRebindingExtensions.RebindingOperation op)
		{
			_rebindMode = InputMode.None;
			_rebindOperation.Dispose();
			_rebindOperation = null;
			for (int i = 0; i < _rebindingActions.Count; i++)
			{
				RebindingAction rebindingAction = _rebindingActions[i];
				if (rebindingAction.enabled)
				{
					rebindingAction.action.Enable();
				}
			}
			AggroSettingsManagerUI.SuppressInput();
		}

		public string GetKbmPath()
		{
			for (int i = 0; i < _actions.Length; i++)
			{
				Action action = _actions[i];
				if (action.kbmBinding.HasValue)
				{
					return action.action.bindings[action.action.GetBindingIndex(action.kbmBinding.Value)].effectivePath;
				}
			}
			return "<UNKNOWN>";
		}

		public string GetGamepadPath()
		{
			for (int i = 0; i < _actions.Length; i++)
			{
				Action action = _actions[i];
				if (action.gamepadBinding.HasValue)
				{
					return action.action.bindings[action.action.GetBindingIndex(action.gamepadBinding.Value)].effectivePath;
				}
			}
			return "<UNKNOWN>";
		}

		public bool DoesKbmConflict(InputSetting other)
		{
			if (other == this)
			{
				return false;
			}
			if (other == null)
			{
				return false;
			}
			if (_kbmMask == InputRebindKbmMask.None)
			{
				return false;
			}
			if (other._kbmMask == InputRebindKbmMask.None)
			{
				return false;
			}
			if ((_layerCollision & (1 << other._layer)) == 0)
			{
				return false;
			}
			if (string.Equals(GetKbmPath(), other.GetKbmPath(), StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return false;
		}

		public bool DoesGamepadConflict(InputSetting other)
		{
			if (other == this)
			{
				return false;
			}
			if (other == null)
			{
				return false;
			}
			if (_gamepadMask == InputRebindGamepadMask.None)
			{
				return false;
			}
			if (other._gamepadMask == InputRebindGamepadMask.None)
			{
				return false;
			}
			if ((_layerCollision & (1 << other._layer)) == 0)
			{
				return false;
			}
			if (string.Equals(GetGamepadPath(), other.GetGamepadPath(), StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return false;
		}
	}
}
