using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Packages.SocialPlatforms;
using ModApi.Input;
using Rewired;

namespace Assets.Scripts.Input
{
	public class GameInput : IGameInput
	{
		private static readonly Func<bool> _DefaultCustomModifierCheck = () => true;

		private Func<bool> _customModifierCheck;

		private List<ActionElementMap> _tempActionElementMap = new List<ActionElementMap>();

		public int ActionId { get; private set; }

		public string DescriptiveName { get; private set; }

		public bool Enabled { get; set; }

		public string Id { get; private set; }

		public bool IsBound { get; set; }

		public GameInput(string id)
		{
			Id = id;
			ActionId = -1;
			Enabled = true;
			InputAction action = ReInput.mapping.GetAction(Id);
			if (action != null)
			{
				DescriptiveName = action.descriptiveName;
				ActionId = action.id;
			}
			_customModifierCheck = _DefaultCustomModifierCheck;
		}

		public float GetAxis()
		{
			if (!_customModifierCheck())
			{
				return 0f;
			}
			return InputWrapper.GetAxis(ActionId);
		}

		public float GetAxisIfEnabled()
		{
			if (!_customModifierCheck() || !Enabled)
			{
				return 0f;
			}
			return InputWrapper.GetAxis(ActionId);
		}

		public bool GetButton()
		{
			if (!_customModifierCheck())
			{
				return false;
			}
			return InputWrapper.GetButton(ActionId);
		}

		public bool GetButtonDown()
		{
			if (!_customModifierCheck())
			{
				return false;
			}
			return InputWrapper.GetButtonDown(ActionId);
		}

		public bool GetButtonDownIfEnabled()
		{
			if (!_customModifierCheck() || !Enabled)
			{
				return false;
			}
			return InputWrapper.GetButtonDown(ActionId);
		}

		public bool GetButtonIfEnabled()
		{
			if (!_customModifierCheck() || !Enabled)
			{
				return false;
			}
			return InputWrapper.GetButton(ActionId);
		}

		public bool GetButtonRepeating()
		{
			if (!_customModifierCheck())
			{
				return false;
			}
			return InputWrapper.GetButtonRepeating(ActionId);
		}

		public float GetButtonTimePressed()
		{
			if (!_customModifierCheck())
			{
				return 0f;
			}
			return InputWrapper.GetButtonTimePressed(ActionId);
		}

		public bool GetButtonUp()
		{
			if (!_customModifierCheck())
			{
				return false;
			}
			return InputWrapper.GetButtonUp(ActionId);
		}

		public bool GetButtonUpIfEnabled()
		{
			if (!_customModifierCheck() || !Enabled)
			{
				return false;
			}
			return InputWrapper.GetButtonUp(ActionId);
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

		public string GetControllerNegativeBindingText()
		{
			return GetControllerBindingText(Pole.Negative);
		}

		public string GetControllerPositiveBindingText()
		{
			return GetControllerBindingText(Pole.Positive);
		}

		public string GetFirstBindingText()
		{
			ControllerType controllerType = (SocialExt.IsSteamDeckOrBigPicture ? ControllerType.Joystick : ControllerType.Keyboard);
			ActionElementMap firstElementMapWithAction = InputWrapper.Player.controllers.maps.GetFirstElementMapWithAction(controllerType, ActionId, skipDisabledMaps: false);
			if (firstElementMapWithAction == null)
			{
				firstElementMapWithAction = InputWrapper.Player.controllers.maps.GetFirstElementMapWithAction(ActionId, skipDisabledMaps: false);
			}
			if (firstElementMapWithAction != null)
			{
				return InputUtilities.GetBindingDisplayName(firstElementMapWithAction);
			}
			return null;
		}

		public string GetKeyboardPrimaryBindingText(Pole? axisContribution)
		{
			IEnumerable<ActionElementMap> enumerable = InputWrapper.Player.controllers.maps.ElementMapsWithAction(ControllerType.Keyboard, ActionId, skipDisabledMaps: false);
			if (!axisContribution.HasValue)
			{
				ActionElementMap actionElementMap = enumerable.FirstOrDefault();
				if (actionElementMap != null)
				{
					return InputUtilities.GetKeyCodeDisplayName(actionElementMap.keyCode, actionElementMap.elementIdentifierName);
				}
				return null;
			}
			foreach (ActionElementMap item in enumerable)
			{
				if (item.axisContribution == axisContribution.Value)
				{
					return InputUtilities.GetKeyCodeDisplayName(item.keyCode, item.elementIdentifierName);
				}
			}
			return null;
		}

		public string GetKeyboardPrimaryBindingText()
		{
			return GetKeyboardPrimaryBindingText(null);
		}

		public string GetKeyboardPrimaryNegativeBindingText()
		{
			return GetKeyboardPrimaryBindingText(Pole.Negative);
		}

		public string GetKeyboardPrimaryPositiveBindingText()
		{
			return GetKeyboardPrimaryBindingText(Pole.Positive);
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
