using System;
using System.Collections.Generic;
using System.Linq;
using Rewired;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Input
{
	public class GameInput : IGameInput
	{
		private static readonly Func<bool> _DefaultCustomModifierCheck = () => true;

		private Func<bool> _customModifierCheck;

		private UnityEngine.InputSystem.InputAction _inputAction;

		private List<ActionElementMap> _tempActionElementMap = new List<ActionElementMap>();

		public int ActionId { get; private set; }

		public string DescriptiveName { get; private set; }

		public bool Enabled { get; set; }

		public string Id { get; private set; }

		public GameInput(string id)
		{
			Id = id;
			ActionId = -1;
			Enabled = true;
			Rewired.InputAction action = ReInput.mapping.GetAction(Id);
			if (action != null)
			{
				DescriptiveName = action.descriptiveName;
				ActionId = action.id;
			}
			_customModifierCheck = _DefaultCustomModifierCheck;
		}

		public void AddInputAction(UnityEngine.InputSystem.InputAction inputAction)
		{
			if (_inputAction != null)
			{
				Debug.LogError("Only 1 input action may be tied to a GameInput. The previous input action will be overridden. Game input: " + Id);
			}
			_inputAction = inputAction;
		}

		public float GetAxis()
		{
			if (_inputAction == null)
			{
				if (!_customModifierCheck())
				{
					return 0f;
				}
				return InputWrapper.GetAxis(ActionId);
			}
			if (!_customModifierCheck())
			{
				return 0f;
			}
			return InputWrapper.GetAxis(ActionId) + _inputAction.ReadValue<float>();
		}

		public float GetAxisIfEnabled()
		{
			if (_inputAction == null)
			{
				if (!_customModifierCheck() || !Enabled)
				{
					return 0f;
				}
				return InputWrapper.GetAxis(ActionId);
			}
			if (!_customModifierCheck() || !Enabled)
			{
				return 0f;
			}
			return InputWrapper.GetAxis(ActionId) + _inputAction.ReadValue<float>();
		}

		public bool GetButton()
		{
			if (_inputAction == null)
			{
				if (!_customModifierCheck())
				{
					return false;
				}
				return InputWrapper.GetButton(ActionId);
			}
			if (!_customModifierCheck())
			{
				return false;
			}
			if (!InputWrapper.GetButton(ActionId))
			{
				return _inputAction.ReadValue<float>() > 0f;
			}
			return true;
		}

		public bool GetButtonDown()
		{
			if (_inputAction == null)
			{
				if (!_customModifierCheck())
				{
					return false;
				}
				return InputWrapper.GetButtonDown(ActionId);
			}
			if (!_customModifierCheck())
			{
				return false;
			}
			if (!InputWrapper.GetButtonDown(ActionId))
			{
				return _inputAction.WasPressedThisFrame();
			}
			return true;
		}

		public bool GetButtonDownIfEnabled()
		{
			if (_inputAction == null)
			{
				if (!_customModifierCheck() || !Enabled)
				{
					return false;
				}
				return InputWrapper.GetButtonDown(ActionId);
			}
			if (!_customModifierCheck() || !Enabled)
			{
				return false;
			}
			if (!InputWrapper.GetButtonDown(ActionId))
			{
				return _inputAction.WasPressedThisFrame();
			}
			return true;
		}

		public bool GetButtonIfEnabled()
		{
			if (_inputAction == null)
			{
				if (!_customModifierCheck() || !Enabled)
				{
					return false;
				}
				return InputWrapper.GetButton(ActionId);
			}
			if (!_customModifierCheck() || !Enabled)
			{
				return false;
			}
			if (!InputWrapper.GetButton(ActionId))
			{
				return _inputAction.ReadValue<float>() > 0f;
			}
			return true;
		}

		public bool GetButtonUp()
		{
			if (_inputAction == null)
			{
				if (!_customModifierCheck())
				{
					return false;
				}
				return InputWrapper.GetButtonUp(ActionId);
			}
			if (!_customModifierCheck())
			{
				return false;
			}
			if (!InputWrapper.GetButtonUp(ActionId))
			{
				return _inputAction.WasReleasedThisFrame();
			}
			return true;
		}

		public bool GetButtonUpIfEnabled()
		{
			if (_inputAction == null)
			{
				if (!_customModifierCheck() || !Enabled)
				{
					return false;
				}
				return InputWrapper.GetButtonUp(ActionId);
			}
			if (!_customModifierCheck() || !Enabled)
			{
				return false;
			}
			if (!InputWrapper.GetButtonUp(ActionId))
			{
				return _inputAction.WasReleasedThisFrame();
			}
			return true;
		}

		public string GetControllerBindingText()
		{
			string text = null;
			InputWrapper.Player.controllers.maps.GetElementMapsWithAction(ControllerType.Joystick, ActionId, skipDisabledMaps: false, _tempActionElementMap);
			foreach (ActionElementMap item in _tempActionElementMap)
			{
				if (!string.IsNullOrWhiteSpace(item?.elementIdentifierName))
				{
					text = ((text == null) ? item.elementIdentifierName : (text + "/" + item.elementIdentifierName));
				}
			}
			return text;
		}

		public string GetControllerBindingText(Pole? axisContribution)
		{
			if (!axisContribution.HasValue)
			{
				return GetControllerBindingText();
			}
			string text = null;
			InputWrapper.Player.controllers.maps.GetElementMapsWithAction(ControllerType.Joystick, ActionId, skipDisabledMaps: false, _tempActionElementMap);
			foreach (ActionElementMap item in _tempActionElementMap)
			{
				if (string.IsNullOrWhiteSpace(item?.elementIdentifierName))
				{
					continue;
				}
				if (item.axisRange == AxisRange.Full)
				{
					Pole pole = ((!item.invert) ? axisContribution.Value : ((axisContribution.Value == Pole.Positive) ? Pole.Negative : Pole.Positive));
					if (item.elementIdentifierName.EndsWith("Stick Y", StringComparison.OrdinalIgnoreCase))
					{
						string text2 = item.elementIdentifierName.Remove(item.elementIdentifierName.Length - 1) + ((pole == Pole.Positive) ? "Up" : "Down");
						text = ((text == null) ? text2 : (text + "/" + text2));
					}
					else if (item.elementIdentifierName.EndsWith("Stick X", StringComparison.OrdinalIgnoreCase))
					{
						string text3 = item.elementIdentifierName.Remove(item.elementIdentifierName.Length - 1) + ((pole == Pole.Positive) ? "Right" : "Left");
						text = ((text == null) ? text3 : (text + "/" + text3));
					}
					else
					{
						text = ((text == null) ? item.elementIdentifierName : (text + "/" + item.elementIdentifierName));
					}
				}
				else if (item.axisContribution == axisContribution.Value)
				{
					text = ((text == null) ? item.elementIdentifierName : (text + "/" + item.elementIdentifierName));
				}
			}
			return text;
		}

		public string GetFirstBindingText()
		{
			return InputWrapper.Player.controllers.maps.GetFirstElementMapWithAction(ActionId, skipDisabledMaps: false)?.elementIdentifierName;
		}

		public string GetKeyboardPrimaryBindingText(Pole? axisContribution)
		{
			IEnumerable<ActionElementMap> enumerable = InputWrapper.Player.controllers.maps.ElementMapsWithAction(ControllerType.Keyboard, ActionId, skipDisabledMaps: false);
			if (!axisContribution.HasValue)
			{
				return enumerable.FirstOrDefault()?.elementIdentifierName;
			}
			foreach (ActionElementMap item in enumerable)
			{
				if (item.axisContribution == axisContribution.Value)
				{
					return item.elementIdentifierName;
				}
			}
			return null;
		}

		public string GetKeyboardPrimaryBindingText()
		{
			return GetKeyboardPrimaryBindingText(null);
		}

		public string GetKeyboardSecondaryBindingText()
		{
			return InputWrapper.Player.controllers.maps.ElementMapsWithAction(ControllerType.Keyboard, ActionId, skipDisabledMaps: false).Skip(1).FirstOrDefault()?.elementIdentifierName;
		}

		public string GetMouseBindingText()
		{
			return InputWrapper.Player.controllers.maps.GetFirstElementMapWithAction(ControllerType.Mouse, ActionId, skipDisabledMaps: false)?.elementIdentifierName;
		}

		public void ResetCustomModifier()
		{
			_customModifierCheck = _DefaultCustomModifierCheck;
		}

		public void SetCustomModifier(Func<bool> modifierCheck)
		{
			_customModifierCheck = modifierCheck;
		}
	}
}
