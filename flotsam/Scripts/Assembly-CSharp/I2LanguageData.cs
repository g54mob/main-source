using System;
using System.Collections.Generic;
using I2.Loc;
using Rewired;
using Rewired.UI.ControlMapper;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "ControlMapper LanguageData", menuName = "Pajama Llama/Rewired/ControlMapper LanguageData")]
public class I2LanguageData : LanguageDataBase
{
	[Serializable]
	protected class CustomEntry
	{
		public string key;

		public string value;

		public CustomEntry()
		{
		}

		public CustomEntry(string key, string value)
		{
			this.key = key;
			this.value = value;
		}

		public static Dictionary<string, string> ToDictionary(CustomEntry[] array)
		{
			if (array == null)
			{
				return new Dictionary<string, string>();
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null && !string.IsNullOrEmpty(array[i].key) && !string.IsNullOrEmpty(array[i].value))
				{
					if (dictionary.ContainsKey(array[i].key))
					{
						Debug.LogError("Key \"" + array[i].key + "\" is already in dictionary!");
					}
					else
					{
						dictionary.Add(array[i].key, array[i].value);
					}
				}
			}
			return dictionary;
		}
	}

	[Serializable]
	protected class ModifierKeys
	{
		public string control = "Control";

		public string alt = "Alt";

		public string shift = "Shift";

		public string command = "Command";

		public string separator = " + ";
	}

	[SerializeField]
	private LocalizedString _yes;

	[SerializeField]
	private LocalizedString _no;

	[SerializeField]
	private LocalizedString _add;

	[SerializeField]
	private LocalizedString _replace;

	[SerializeField]
	private LocalizedString _remove;

	[SerializeField]
	private LocalizedString _swap;

	[SerializeField]
	private LocalizedString _cancel;

	[SerializeField]
	private LocalizedString _none;

	[SerializeField]
	private LocalizedString _okay;

	[SerializeField]
	private LocalizedString _done;

	[SerializeField]
	private LocalizedString _default;

	[SerializeField]
	private LocalizedString _assignControllerWindowTitle;

	[SerializeField]
	private LocalizedString _assignControllerWindowMessage;

	[SerializeField]
	private LocalizedString _controllerAssignmentConflictWindowTitle;

	[SerializeField]
	[Tooltip("{0} = Joystick Name\n{1} = Other Player Name\n{2} = This Player Name")]
	private LocalizedString _controllerAssignmentConflictWindowMessage;

	[SerializeField]
	private LocalizedString _elementAssignmentPrePollingWindowMessage;

	[SerializeField]
	[Tooltip("{0} = Action Name")]
	private LocalizedString _joystickElementAssignmentPollingWindowMessage;

	[SerializeField]
	[Tooltip("This text is only displayed when split-axis fields have been disabled and the user clicks on the full-axis field. Button/key/D-pad input cannot be assigned to a full-axis field.\n{0} = Action Name")]
	private LocalizedString _joystickElementAssignmentPollingWindowMessage_fullAxisFieldOnly;

	[SerializeField]
	[Tooltip("{0} = Action Name")]
	private LocalizedString _keyboardElementAssignmentPollingWindowMessage;

	[SerializeField]
	[Tooltip("{0} = Action Name")]
	private LocalizedString _mouseElementAssignmentPollingWindowMessage;

	[SerializeField]
	[Tooltip("This text is only displayed when split-axis fields have been disabled and the user clicks on the full-axis field. Button/key/D-pad input cannot be assigned to a full-axis field.\n{0} = Action Name")]
	private LocalizedString _mouseElementAssignmentPollingWindowMessage_fullAxisFieldOnly;

	[SerializeField]
	private LocalizedString _elementAssignmentConflictWindowMessage;

	[SerializeField]
	[Tooltip("{0} = Element Name")]
	private LocalizedString _elementAlreadyInUseBlocked;

	[SerializeField]
	[Tooltip("{0} = Element Name")]
	private LocalizedString _elementAlreadyInUseCanReplace;

	[SerializeField]
	[Tooltip("{0} = Element Name")]
	private LocalizedString _elementAlreadyInUseCanReplace_conflictAllowed;

	[SerializeField]
	private LocalizedString _mouseAssignmentConflictWindowTitle;

	[SerializeField]
	[Tooltip("{0} = Other Player Name\n{1} = This Player Name")]
	private LocalizedString _mouseAssignmentConflictWindowMessage;

	[SerializeField]
	private LocalizedString _calibrateControllerWindowTitle;

	[SerializeField]
	private LocalizedString _calibrateAxisStep1WindowTitle;

	[SerializeField]
	[Tooltip("{0} = Axis Name")]
	private LocalizedString _calibrateAxisStep1WindowMessage;

	[SerializeField]
	private LocalizedString _calibrateAxisStep2WindowTitle;

	[SerializeField]
	[Tooltip("{0} = Axis Name")]
	private LocalizedString _calibrateAxisStep2WindowMessage;

	[SerializeField]
	private LocalizedString _inputBehaviorSettingsWindowTitle;

	[SerializeField]
	private LocalizedString _restoreDefaultsWindowTitle;

	[SerializeField]
	[Tooltip("Message for a single player game.")]
	private LocalizedString _restoreDefaultsWindowMessage_onePlayer;

	[SerializeField]
	[Tooltip("Message for a multi-player game.")]
	private LocalizedString _restoreDefaultsWindowMessage_multiPlayer;

	[SerializeField]
	private LocalizedString _actionColumnLabel;

	[SerializeField]
	private LocalizedString _keyboardColumnLabel;

	[SerializeField]
	private LocalizedString _mouseColumnLabel;

	[SerializeField]
	private LocalizedString _controllerColumnLabel;

	[SerializeField]
	private LocalizedString _removeControllerButtonLabel;

	[SerializeField]
	private LocalizedString _calibrateControllerButtonLabel;

	[SerializeField]
	private LocalizedString _assignControllerButtonLabel;

	[SerializeField]
	private LocalizedString _inputBehaviorSettingsButtonLabel;

	[SerializeField]
	private LocalizedString _doneButtonLabel;

	[SerializeField]
	private LocalizedString _restoreDefaultsButtonLabel;

	[SerializeField]
	private LocalizedString _playersGroupLabel;

	[SerializeField]
	private LocalizedString _controllerSettingsGroupLabel;

	[SerializeField]
	private LocalizedString _assignedControllersGroupLabel;

	[SerializeField]
	private LocalizedString _settingsGroupLabel;

	[SerializeField]
	private LocalizedString _mapCategoriesGroupLabel;

	[SerializeField]
	private LocalizedString _calibrateWindow_deadZoneSliderLabel;

	[SerializeField]
	private LocalizedString _calibrateWindow_zeroSliderLabel;

	[SerializeField]
	private LocalizedString _calibrateWindow_sensitivitySliderLabel;

	[SerializeField]
	private LocalizedString _calibrateWindow_invertToggleLabel;

	[SerializeField]
	private LocalizedString _calibrateWindow_calibrateButtonLabel;

	[SerializeField]
	private ModifierKeys _modifierKeys;

	[SerializeField]
	private CustomEntry[] _customEntries;

	private bool _initialized;

	private Dictionary<string, string> customDict;

	public override string yes => _yes;

	public override string no => _no;

	public override string add => _add;

	public override string replace => _replace;

	public override string remove => _remove;

	public override string swap => _swap;

	public override string cancel => _cancel;

	public override string none => _none;

	public override string okay => _okay;

	public override string done => _done;

	public override string default_ => _default;

	public override string assignControllerWindowTitle => _assignControllerWindowTitle;

	public override string assignControllerWindowMessage => _assignControllerWindowMessage;

	public override string controllerAssignmentConflictWindowTitle => _controllerAssignmentConflictWindowTitle;

	public override string elementAssignmentPrePollingWindowMessage => _elementAssignmentPrePollingWindowMessage;

	public override string elementAssignmentConflictWindowMessage => _elementAssignmentConflictWindowMessage;

	public override string mouseAssignmentConflictWindowTitle => _mouseAssignmentConflictWindowTitle;

	public override string calibrateControllerWindowTitle => _calibrateControllerWindowTitle;

	public override string calibrateAxisStep1WindowTitle => _calibrateAxisStep1WindowTitle;

	public override string calibrateAxisStep2WindowTitle => _calibrateAxisStep2WindowTitle;

	public override string inputBehaviorSettingsWindowTitle => _inputBehaviorSettingsWindowTitle;

	public override string restoreDefaultsWindowTitle => _restoreDefaultsWindowTitle;

	public override string actionColumnLabel => _actionColumnLabel;

	public override string keyboardColumnLabel => _keyboardColumnLabel;

	public override string mouseColumnLabel => _mouseColumnLabel;

	public override string controllerColumnLabel => _controllerColumnLabel;

	public override string removeControllerButtonLabel => _removeControllerButtonLabel;

	public override string calibrateControllerButtonLabel => _calibrateControllerButtonLabel;

	public override string assignControllerButtonLabel => _assignControllerButtonLabel;

	public override string inputBehaviorSettingsButtonLabel => _inputBehaviorSettingsButtonLabel;

	public override string doneButtonLabel => _doneButtonLabel;

	public override string restoreDefaultsButtonLabel => _restoreDefaultsButtonLabel;

	public override string controllerSettingsGroupLabel => _controllerSettingsGroupLabel;

	public override string playersGroupLabel => _playersGroupLabel;

	public override string assignedControllersGroupLabel => _assignedControllersGroupLabel;

	public override string settingsGroupLabel => _settingsGroupLabel;

	public override string mapCategoriesGroupLabel => _mapCategoriesGroupLabel;

	public override string restoreDefaultsWindowMessage
	{
		get
		{
			if (ReInput.players.playerCount > 1)
			{
				return _restoreDefaultsWindowMessage_multiPlayer;
			}
			return _restoreDefaultsWindowMessage_onePlayer;
		}
	}

	public override string calibrateWindow_deadZoneSliderLabel => _calibrateWindow_deadZoneSliderLabel;

	public override string calibrateWindow_zeroSliderLabel => _calibrateWindow_zeroSliderLabel;

	public override string calibrateWindow_sensitivitySliderLabel => _calibrateWindow_sensitivitySliderLabel;

	public override string calibrateWindow_invertToggleLabel => _calibrateWindow_invertToggleLabel;

	public override string calibrateWindow_calibrateButtonLabel => _calibrateWindow_calibrateButtonLabel;

	public override string calibrateWindow_upperDeadZoneSliderLabel => "NOT IMPLEMENTED";

	public override void Initialize()
	{
		if (!_initialized)
		{
			customDict = CustomEntry.ToDictionary(_customEntries);
			_initialized = true;
		}
	}

	public override string GetCustomEntry(string key)
	{
		if (string.IsNullOrEmpty(key))
		{
			return string.Empty;
		}
		return GetTranslation(key);
	}

	public override bool ContainsCustomEntryKey(string key)
	{
		string Translation;
		return LocalizationManager.TryGetTranslation(key, out Translation);
	}

	public override string GetControllerAssignmentConflictWindowMessage(string joystickName, string otherPlayerName, string currentPlayerName)
	{
		return string.Format(_controllerAssignmentConflictWindowMessage, joystickName, otherPlayerName, currentPlayerName);
	}

	public override string GetJoystickElementAssignmentPollingWindowMessage(string actionName)
	{
		return string.Format(_joystickElementAssignmentPollingWindowMessage, actionName);
	}

	public override string GetJoystickElementAssignmentPollingWindowMessage_FullAxisFieldOnly(string actionName)
	{
		return string.Format(_joystickElementAssignmentPollingWindowMessage_fullAxisFieldOnly, actionName);
	}

	public override string GetKeyboardElementAssignmentPollingWindowMessage(string actionName)
	{
		return string.Format(_keyboardElementAssignmentPollingWindowMessage, actionName);
	}

	public override string GetMouseElementAssignmentPollingWindowMessage(string actionName)
	{
		return string.Format(_mouseElementAssignmentPollingWindowMessage, actionName);
	}

	public override string GetMouseElementAssignmentPollingWindowMessage_FullAxisFieldOnly(string actionName)
	{
		return string.Format(_mouseElementAssignmentPollingWindowMessage_fullAxisFieldOnly, actionName);
	}

	public override string GetElementAlreadyInUseBlocked(string elementName)
	{
		return string.Format(_elementAlreadyInUseBlocked, elementName);
	}

	public override string GetElementAlreadyInUseCanReplace(string elementName, bool allowConflicts)
	{
		if (!allowConflicts)
		{
			return string.Format(_elementAlreadyInUseCanReplace, elementName);
		}
		return string.Format(_elementAlreadyInUseCanReplace_conflictAllowed, elementName);
	}

	public override string GetMouseAssignmentConflictWindowMessage(string otherPlayerName, string thisPlayerName)
	{
		return string.Format(_mouseAssignmentConflictWindowMessage, otherPlayerName, thisPlayerName);
	}

	public override string GetCalibrateAxisStep1WindowMessage(string axisName)
	{
		return string.Format(_calibrateAxisStep1WindowMessage, axisName);
	}

	public override string GetCalibrateAxisStep2WindowMessage(string axisName)
	{
		return string.Format(_calibrateAxisStep2WindowMessage, axisName);
	}

	public override string GetPlayerName(int playerId)
	{
		Player player = ReInput.players.GetPlayer(playerId);
		if (player == null)
		{
			throw new ArgumentException("Invalid player id: " + playerId);
		}
		return GetTranslation(player.descriptiveName);
	}

	public override string GetControllerName(Controller controller)
	{
		if (controller == null)
		{
			throw new ArgumentNullException("controller");
		}
		return controller.name;
	}

	public override string GetElementIdentifierName(ActionElementMap actionElementMap)
	{
		if (actionElementMap == null)
		{
			throw new ArgumentNullException("actionElementMap");
		}
		if (actionElementMap.controllerMap.controllerType == ControllerType.Keyboard)
		{
			return GetElementIdentifierName(actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
		}
		return GetElementIdentifierName(actionElementMap.controllerMap.controller, actionElementMap.elementIdentifierId, actionElementMap.axisRange);
	}

	public override string GetElementIdentifierName(Controller controller, int elementIdentifierId, AxisRange axisRange)
	{
		if (controller == null)
		{
			throw new ArgumentNullException("controller");
		}
		ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(elementIdentifierId);
		if (elementIdentifierById == null)
		{
			throw new ArgumentException("Invalid element identifier id: " + elementIdentifierId);
		}
		Controller.Element elementById = controller.GetElementById(elementIdentifierId);
		if (elementById == null)
		{
			return string.Empty;
		}
		return elementById.type switch
		{
			ControllerElementType.Axis => elementIdentifierById.GetDisplayName(elementById.type, axisRange), 
			ControllerElementType.Button => elementIdentifierById.name, 
			_ => elementIdentifierById.name, 
		};
	}

	public override string GetElementIdentifierName(KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
	{
		if (modifierKeyFlags != ModifierKeyFlags.None)
		{
			return $"{ModifierKeyFlagsToString(modifierKeyFlags)}{_modifierKeys.separator}{Keyboard.GetKeyName(keyCode)}";
		}
		return Keyboard.GetKeyName(keyCode);
	}

	public override string GetActionName(int actionId)
	{
		InputAction action = ReInput.mapping.GetAction(actionId);
		if (action == null)
		{
			throw new ArgumentException("Invalid action id: " + actionId);
		}
		return GetTranslation(action.descriptiveName);
	}

	public override string GetActionName(int actionId, AxisRange axisRange)
	{
		InputAction action = ReInput.mapping.GetAction(actionId);
		if (action == null)
		{
			throw new ArgumentException("Invalid action id: " + actionId);
		}
		switch (axisRange)
		{
		case AxisRange.Full:
			return GetTranslation(action.descriptiveName);
		case AxisRange.Positive:
			if (string.IsNullOrEmpty(action.positiveDescriptiveName))
			{
				return GetTranslation(action.descriptiveName) + " +";
			}
			return GetTranslation(action.positiveDescriptiveName);
		case AxisRange.Negative:
			if (string.IsNullOrEmpty(action.negativeDescriptiveName))
			{
				return GetTranslation(action.descriptiveName) + " -";
			}
			return GetTranslation(action.negativeDescriptiveName);
		default:
			throw new NotImplementedException();
		}
	}

	public override string GetMapCategoryName(int id)
	{
		InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(id);
		if (mapCategory == null)
		{
			throw new ArgumentException("Invalid map category id: " + id);
		}
		return GetTranslation(mapCategory.descriptiveName);
	}

	public override string GetActionCategoryName(int id)
	{
		InputCategory actionCategory = ReInput.mapping.GetActionCategory(id);
		if (actionCategory == null)
		{
			throw new ArgumentException("Invalid action category id: " + id);
		}
		return GetTranslation(actionCategory.descriptiveName);
	}

	public override string GetLayoutName(ControllerType controllerType, int id)
	{
		InputLayout layout = ReInput.mapping.GetLayout(controllerType, id);
		if (layout == null)
		{
			throw new ArgumentException("Invalid " + controllerType.ToString() + " layout id: " + id);
		}
		return GetTranslation(layout.descriptiveName);
	}

	public override string ModifierKeyFlagsToString(ModifierKeyFlags flags)
	{
		int num = 0;
		string text = string.Empty;
		if (Keyboard.ModifierKeyFlagsContain(flags, ModifierKey.Control))
		{
			text += _modifierKeys.control;
			num++;
		}
		if (Keyboard.ModifierKeyFlagsContain(flags, ModifierKey.Command))
		{
			if (num > 0 && !string.IsNullOrEmpty(_modifierKeys.separator))
			{
				text += _modifierKeys.separator;
			}
			text += _modifierKeys.command;
			num++;
		}
		if (Keyboard.ModifierKeyFlagsContain(flags, ModifierKey.Alt))
		{
			if (num > 0 && !string.IsNullOrEmpty(_modifierKeys.separator))
			{
				text += _modifierKeys.separator;
			}
			text += _modifierKeys.alt;
			num++;
		}
		if (num >= 3)
		{
			return text;
		}
		if (Keyboard.ModifierKeyFlagsContain(flags, ModifierKey.Shift))
		{
			if (num > 0 && !string.IsNullOrEmpty(_modifierKeys.separator))
			{
				text += _modifierKeys.separator;
			}
			text += _modifierKeys.shift;
			num++;
		}
		return text;
	}

	private string GetTranslation(string term)
	{
		if (LocalizationManager.TryGetTranslation(term, out var Translation))
		{
			return Translation;
		}
		return term;
	}
}
