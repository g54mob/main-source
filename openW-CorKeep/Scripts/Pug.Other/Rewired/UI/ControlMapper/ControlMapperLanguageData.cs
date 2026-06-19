using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace Rewired.UI.ControlMapper
{
	[Serializable]
	[CreateAssetMenu(fileName = "ControlMapperLanguageData", menuName = "Pug/Tables/ControlMapperLanguageData", order = 1)]
	public class ControlMapperLanguageData : LanguageDataBase
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
			public LocalizedString control = "Control";

			public LocalizedString alt = "Alt";

			public LocalizedString shift = "Shift";

			public LocalizedString command = "Command";

			public LocalizedString separator = " + ";
		}

		[SerializeField]
		private LocalizedString _yes = "Yes";

		[SerializeField]
		private LocalizedString _no = "No";

		[SerializeField]
		private LocalizedString _add = "Add";

		[SerializeField]
		private LocalizedString _replace = "Replace";

		[SerializeField]
		private LocalizedString _remove = "Remove";

		[SerializeField]
		private LocalizedString _swap = "Swap";

		[SerializeField]
		private LocalizedString _cancel = "Cancel";

		[SerializeField]
		private LocalizedString _none = "None";

		[SerializeField]
		private LocalizedString _okay = "Okay";

		[SerializeField]
		private LocalizedString _done = "Done";

		[SerializeField]
		private LocalizedString _default = "Default";

		[SerializeField]
		private LocalizedString _assignControllerWindowTitle = "Choose Controller";

		[SerializeField]
		private LocalizedString _assignControllerWindowMessage = "Press any button or move an axis on the controller you would like to use.";

		[SerializeField]
		private LocalizedString _controllerAssignmentConflictWindowTitle = "Controller Assignment";

		[SerializeField]
		[Tooltip("{0} = Joystick Name\n{1} = Other Player Name\n{2} = This Player Name")]
		private LocalizedString _controllerAssignmentConflictWindowMessage = "{0} is already assigned to {1}. Do you want to assign this controller to {2} instead?";

		[SerializeField]
		private LocalizedString _elementAssignmentPrePollingWindowMessage = "First center or zero all sticks and axes and press any button or wait for the timer to finish.";

		[SerializeField]
		[Tooltip("{0} = Action Name")]
		private LocalizedString _joystickElementAssignmentPollingWindowMessage = "Now press a button or move an axis to assign it to {0}.";

		[SerializeField]
		[Tooltip("This text is only displayed when split-axis fields have been disabled and the user clicks on the full-axis field. Button/key/D-pad input cannot be assigned to a full-axis field.\n{0} = Action Name")]
		private LocalizedString _joystickElementAssignmentPollingWindowMessage_fullAxisFieldOnly = "Now move an axis to assign it to {0}.";

		[SerializeField]
		[Tooltip("{0} = Action Name")]
		private LocalizedString _keyboardElementAssignmentPollingWindowMessage = "Press a key to assign it to {0}. Modifier keys may also be used. To assign a modifier key alone, hold it down for 1 second.";

		[SerializeField]
		[Tooltip("{0} = Action Name")]
		private LocalizedString _mouseElementAssignmentPollingWindowMessage = "Press a mouse button or move an axis to assign it to {0}.";

		[SerializeField]
		[Tooltip("This text is only displayed when split-axis fields have been disabled and the user clicks on the full-axis field. Button/key/D-pad input cannot be assigned to a full-axis field.\n{0} = Action Name")]
		private LocalizedString _mouseElementAssignmentPollingWindowMessage_fullAxisFieldOnly = "Move an axis to assign it to {0}.";

		[SerializeField]
		private LocalizedString _elementAssignmentConflictWindowMessage = "Assignment Conflict";

		[SerializeField]
		[Tooltip("{0} = Element Name")]
		private LocalizedString _elementAlreadyInUseBlocked = "{0} is already in use cannot be replaced.";

		[SerializeField]
		[Tooltip("{0} = Element Name")]
		private LocalizedString _elementAlreadyInUseCanReplace = "{0} is already in use. Do you want to replace it?";

		[SerializeField]
		[Tooltip("{0} = Element Name")]
		private LocalizedString _elementAlreadyInUseCanReplace_conflictAllowed = "{0} is already in use. Do you want to replace it? You may also choose to add the assignment anyway.";

		[SerializeField]
		private LocalizedString _mouseAssignmentConflictWindowTitle = "Mouse Assignment";

		[SerializeField]
		[Tooltip("{0} = Other Player Name\n{1} = This Player Name")]
		private LocalizedString _mouseAssignmentConflictWindowMessage = "The mouse is already assigned to {0}. Do you want to assign the mouse to {1} instead?";

		[SerializeField]
		private LocalizedString _calibrateControllerWindowTitle = "Calibrate Controller";

		[SerializeField]
		private LocalizedString _calibrateAxisStep1WindowTitle = "Calibrate Zero";

		[SerializeField]
		[Tooltip("{0} = Axis Name")]
		private LocalizedString _calibrateAxisStep1WindowMessage = "Center or zero {0} and press any button or wait for the timer to finish.";

		[SerializeField]
		private LocalizedString _calibrateAxisStep2WindowTitle = "Calibrate Range";

		[SerializeField]
		[Tooltip("{0} = Axis Name")]
		private LocalizedString _calibrateAxisStep2WindowMessage = "Move {0} through its entire range then press any button or wait for the timer to finish.";

		[SerializeField]
		private LocalizedString _inputBehaviorSettingsWindowTitle = "Sensitivity Settings";

		[SerializeField]
		private LocalizedString _restoreDefaultsWindowTitle = "Restore Defaults";

		[SerializeField]
		[Tooltip("Message for a single player game.")]
		private LocalizedString _restoreDefaultsWindowMessage_onePlayer = "This will restore the default input configuration. Are you sure you want to do this?";

		[SerializeField]
		[Tooltip("Message for a multi-player game.")]
		private LocalizedString _restoreDefaultsWindowMessage_multiPlayer = "This will restore the default input configuration for all players. Are you sure you want to do this?";

		[SerializeField]
		private LocalizedString _actionColumnLabel = "Actions";

		[SerializeField]
		private LocalizedString _keyboardColumnLabel = "Keyboard";

		[SerializeField]
		private LocalizedString _mouseColumnLabel = "Mouse";

		[SerializeField]
		private LocalizedString _controllerColumnLabel = "Controller";

		[SerializeField]
		private LocalizedString _removeControllerButtonLabel = "Remove";

		[SerializeField]
		private LocalizedString _calibrateControllerButtonLabel = "Calibrate";

		[SerializeField]
		private LocalizedString _assignControllerButtonLabel = "Assign Controller";

		[SerializeField]
		private LocalizedString _inputBehaviorSettingsButtonLabel = "Sensitivity";

		[SerializeField]
		private LocalizedString _doneButtonLabel = "Done";

		[SerializeField]
		private LocalizedString _restoreDefaultsButtonLabel = "Restore Defaults";

		[SerializeField]
		private LocalizedString _playersGroupLabel = "Players:";

		[SerializeField]
		private LocalizedString _controllerSettingsGroupLabel = "Controller:";

		[SerializeField]
		private LocalizedString _assignedControllersGroupLabel = "Assigned Controllers:";

		[SerializeField]
		private LocalizedString _settingsGroupLabel = "Settings:";

		[SerializeField]
		private LocalizedString _mapCategoriesGroupLabel = "Categories:";

		[SerializeField]
		private LocalizedString _calibrateWindow_deadZoneSliderLabel = "Dead Zone:";

		[SerializeField]
		private LocalizedString _calibrateWindow_zeroSliderLabel = "Zero:";

		[SerializeField]
		private LocalizedString _calibrateWindow_sensitivitySliderLabel = "Sensitivity:";

		[SerializeField]
		private LocalizedString _calibrateWindow_invertToggleLabel = "Invert";

		[SerializeField]
		private LocalizedString _calibrateWindow_calibrateButtonLabel = "Calibrate";

		[SerializeField]
		private ModifierKeys _modifierKeys;

		[SerializeField]
		private CustomEntry[] _customEntries;

		private bool _initialized;

		private Dictionary<string, string> customDict;

		private readonly string categoryPrefix = "ControlMapper/";

		public override string yes => _yes.mTerm;

		public override string no => _no.mTerm;

		public override string add => _add.mTerm;

		public override string replace => _replace.mTerm;

		public override string remove => _remove.mTerm;

		public override string swap => _swap.mTerm;

		public override string cancel => _cancel.mTerm;

		public override string none => _none.mTerm;

		public override string okay => _okay.mTerm;

		public override string done => _done.mTerm;

		public override string default_ => _default.mTerm;

		public override string assignControllerWindowTitle => _assignControllerWindowTitle.mTerm;

		public override string assignControllerWindowMessage => _assignControllerWindowMessage.mTerm;

		public override string controllerAssignmentConflictWindowTitle => _controllerAssignmentConflictWindowTitle.mTerm;

		public override string elementAssignmentPrePollingWindowMessage => _elementAssignmentPrePollingWindowMessage.mTerm;

		public override string elementAssignmentConflictWindowMessage => _elementAssignmentConflictWindowMessage.mTerm;

		public override string mouseAssignmentConflictWindowTitle => _mouseAssignmentConflictWindowTitle.mTerm;

		public override string calibrateControllerWindowTitle => _calibrateControllerWindowTitle.mTerm;

		public override string calibrateAxisStep1WindowTitle => _calibrateAxisStep1WindowTitle.mTerm;

		public override string calibrateAxisStep2WindowTitle => _calibrateAxisStep2WindowTitle.mTerm;

		public override string inputBehaviorSettingsWindowTitle => _inputBehaviorSettingsWindowTitle.mTerm;

		public override string restoreDefaultsWindowTitle => _restoreDefaultsWindowTitle.mTerm;

		public override string actionColumnLabel => _actionColumnLabel.mTerm;

		public override string keyboardColumnLabel => _keyboardColumnLabel.mTerm;

		public override string mouseColumnLabel => _mouseColumnLabel.mTerm;

		public override string controllerColumnLabel => _controllerColumnLabel.mTerm;

		public override string removeControllerButtonLabel => _removeControllerButtonLabel.mTerm;

		public override string calibrateControllerButtonLabel => _calibrateControllerButtonLabel.mTerm;

		public override string assignControllerButtonLabel => _assignControllerButtonLabel.mTerm;

		public override string inputBehaviorSettingsButtonLabel => _inputBehaviorSettingsButtonLabel.mTerm;

		public override string doneButtonLabel => _doneButtonLabel.mTerm;

		public override string restoreDefaultsButtonLabel => _restoreDefaultsButtonLabel.mTerm;

		public override string controllerSettingsGroupLabel => _controllerSettingsGroupLabel.mTerm;

		public override string playersGroupLabel => _playersGroupLabel.mTerm;

		public override string assignedControllersGroupLabel => _assignedControllersGroupLabel.mTerm;

		public override string settingsGroupLabel => _settingsGroupLabel.mTerm;

		public override string mapCategoriesGroupLabel => _mapCategoriesGroupLabel.mTerm;

		public override string restoreDefaultsWindowMessage
		{
			get
			{
				if (ReInput.players.playerCount > 1)
				{
					return _restoreDefaultsWindowMessage_multiPlayer.mTerm;
				}
				return _restoreDefaultsWindowMessage_onePlayer.mTerm;
			}
		}

		public override string calibrateWindow_deadZoneSliderLabel => _calibrateWindow_deadZoneSliderLabel.mTerm;

		public override string calibrateWindow_zeroSliderLabel => _calibrateWindow_zeroSliderLabel.mTerm;

		public override string calibrateWindow_sensitivitySliderLabel => _calibrateWindow_sensitivitySliderLabel.mTerm;

		public override string calibrateWindow_invertToggleLabel => _calibrateWindow_invertToggleLabel.mTerm;

		public override string calibrateWindow_calibrateButtonLabel => _calibrateWindow_calibrateButtonLabel.mTerm;

		public string elementAlreadyInUseBlocked => _elementAlreadyInUseBlocked.mTerm;

		public string elementAlreadyInUseCanReplace => _elementAlreadyInUseCanReplace.mTerm;

		public string elementAlreadyInUseCanReplace_conflictAllowed => _elementAlreadyInUseCanReplace_conflictAllowed.mTerm;

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
			if (!customDict.TryGetValue(key, out var value))
			{
				return string.Empty;
			}
			return value;
		}

		public override bool ContainsCustomEntryKey(string key)
		{
			if (string.IsNullOrEmpty(key))
			{
				return false;
			}
			return customDict.ContainsKey(key);
		}

		public override string GetControllerAssignmentConflictWindowMessage(string joystickName, string otherPlayerName, string currentPlayerName)
		{
			return _controllerAssignmentConflictWindowMessage.mTerm;
		}

		public override string GetJoystickElementAssignmentPollingWindowMessage(string actionName)
		{
			return _joystickElementAssignmentPollingWindowMessage.mTerm;
		}

		public override string GetJoystickElementAssignmentPollingWindowMessage_FullAxisFieldOnly(string actionName)
		{
			return _joystickElementAssignmentPollingWindowMessage_fullAxisFieldOnly.mTerm;
		}

		public override string GetKeyboardElementAssignmentPollingWindowMessage(string actionName)
		{
			return _keyboardElementAssignmentPollingWindowMessage.mTerm;
		}

		public override string GetMouseElementAssignmentPollingWindowMessage(string actionName)
		{
			return _mouseElementAssignmentPollingWindowMessage.mTerm;
		}

		public override string GetMouseElementAssignmentPollingWindowMessage_FullAxisFieldOnly(string actionName)
		{
			return _mouseElementAssignmentPollingWindowMessage_fullAxisFieldOnly.mTerm;
		}

		public override string GetElementAlreadyInUseBlocked(string elementName)
		{
			return _elementAlreadyInUseBlocked.mTerm;
		}

		public override string GetElementAlreadyInUseCanReplace(string elementName, bool allowConflicts)
		{
			if (!allowConflicts)
			{
				return _elementAlreadyInUseCanReplace.mTerm;
			}
			return _elementAlreadyInUseCanReplace_conflictAllowed.mTerm;
		}

		public override string GetMouseAssignmentConflictWindowMessage(string otherPlayerName, string thisPlayerName)
		{
			return _mouseAssignmentConflictWindowMessage.mTerm;
		}

		public override string GetCalibrateAxisStep1WindowMessage(string axisName)
		{
			return _calibrateAxisStep1WindowMessage.mTerm;
		}

		public override string GetCalibrateAxisStep2WindowMessage(string axisName)
		{
			return _calibrateAxisStep2WindowMessage.mTerm;
		}

		public override string GetPlayerName(int playerId)
		{
			return (ReInput.players.GetPlayer(playerId) ?? throw new ArgumentException("Invalid player id: " + playerId)).descriptiveName;
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
			string translation = LocalizationManager.GetTranslation(categoryPrefix + action.descriptiveName);
			if (string.IsNullOrEmpty(translation))
			{
				translation = LocalizationManager.GetTranslation(categoryPrefix + action.descriptiveName + "PC");
			}
			return translation;
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
				return LocalizationManager.GetTranslation(categoryPrefix + action.descriptiveName);
			case AxisRange.Positive:
				if (string.IsNullOrEmpty(action.positiveDescriptiveName))
				{
					return LocalizationManager.GetTranslation(categoryPrefix + action.descriptiveName) + " +";
				}
				return LocalizationManager.GetTranslation(categoryPrefix + action.positiveDescriptiveName);
			case AxisRange.Negative:
				if (string.IsNullOrEmpty(action.negativeDescriptiveName))
				{
					return LocalizationManager.GetTranslation(categoryPrefix + action.descriptiveName) + " -";
				}
				return LocalizationManager.GetTranslation(categoryPrefix + action.negativeDescriptiveName);
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
			return LocalizationManager.GetTranslation(categoryPrefix + mapCategory.descriptiveName);
		}

		public override string GetActionCategoryName(int id)
		{
			InputCategory actionCategory = ReInput.mapping.GetActionCategory(id);
			if (actionCategory == null)
			{
				throw new ArgumentException("Invalid action category id: " + id);
			}
			return LocalizationManager.GetTranslation(categoryPrefix + actionCategory.descriptiveName);
		}

		public override string GetLayoutName(ControllerType controllerType, int id)
		{
			return (ReInput.mapping.GetLayout(controllerType, id) ?? throw new ArgumentException("Invalid " + controllerType.ToString() + " layout id: " + id)).descriptiveName;
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
	}
}
