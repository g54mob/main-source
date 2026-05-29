using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.UI.ControlMapper
{
	[Serializable]
	public class LanguageData : LanguageDataBase
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
			}

			public static Dictionary<string, string> ToDictionary(CustomEntry[] array)
			{
				return null;
			}
		}

		[Serializable]
		protected class ModifierKeys
		{
			public string control;

			public string alt;

			public string shift;

			public string command;

			public string separator;
		}

		[SerializeField]
		private string _yes;

		[SerializeField]
		private string _no;

		[SerializeField]
		private string _add;

		[SerializeField]
		private string _replace;

		[SerializeField]
		private string _remove;

		[SerializeField]
		private string _swap;

		[SerializeField]
		private string _cancel;

		[SerializeField]
		private string _none;

		[SerializeField]
		private string _okay;

		[SerializeField]
		private string _done;

		[SerializeField]
		private string _default;

		[SerializeField]
		private string _assignControllerWindowTitle;

		[SerializeField]
		private string _assignControllerWindowMessage;

		[SerializeField]
		private string _controllerAssignmentConflictWindowTitle;

		[SerializeField]
		private string _controllerAssignmentConflictWindowMessage;

		[SerializeField]
		private string _elementAssignmentPrePollingWindowMessage;

		[SerializeField]
		private string _joystickElementAssignmentPollingWindowMessage;

		[SerializeField]
		private string _joystickElementAssignmentPollingWindowMessage_fullAxisFieldOnly;

		[SerializeField]
		private string _keyboardElementAssignmentPollingWindowMessage;

		[SerializeField]
		private string _mouseElementAssignmentPollingWindowMessage;

		[SerializeField]
		private string _mouseElementAssignmentPollingWindowMessage_fullAxisFieldOnly;

		[SerializeField]
		private string _elementAssignmentConflictWindowMessage;

		[SerializeField]
		private string _elementAlreadyInUseBlocked;

		[SerializeField]
		private string _elementAlreadyInUseCanReplace;

		[SerializeField]
		private string _elementAlreadyInUseCanReplace_conflictAllowed;

		[SerializeField]
		private string _mouseAssignmentConflictWindowTitle;

		[SerializeField]
		private string _mouseAssignmentConflictWindowMessage;

		[SerializeField]
		private string _calibrateControllerWindowTitle;

		[SerializeField]
		private string _calibrateAxisStep1WindowTitle;

		[SerializeField]
		private string _calibrateAxisStep1WindowMessage;

		[SerializeField]
		private string _calibrateAxisStep2WindowTitle;

		[SerializeField]
		private string _calibrateAxisStep2WindowMessage;

		[SerializeField]
		private string _inputBehaviorSettingsWindowTitle;

		[SerializeField]
		private string _restoreDefaultsWindowTitle;

		[SerializeField]
		private string _restoreDefaultsWindowMessage_onePlayer;

		[SerializeField]
		private string _restoreDefaultsWindowMessage_multiPlayer;

		[SerializeField]
		private string _actionColumnLabel;

		[SerializeField]
		private string _keyboardColumnLabel;

		[SerializeField]
		private string _mouseColumnLabel;

		[SerializeField]
		private string _controllerColumnLabel;

		[SerializeField]
		private string _removeControllerButtonLabel;

		[SerializeField]
		private string _calibrateControllerButtonLabel;

		[SerializeField]
		private string _assignControllerButtonLabel;

		[SerializeField]
		private string _inputBehaviorSettingsButtonLabel;

		[SerializeField]
		private string _doneButtonLabel;

		[SerializeField]
		private string _restoreDefaultsButtonLabel;

		[SerializeField]
		private string _playersGroupLabel;

		[SerializeField]
		private string _controllerSettingsGroupLabel;

		[SerializeField]
		private string _assignedControllersGroupLabel;

		[SerializeField]
		private string _settingsGroupLabel;

		[SerializeField]
		private string _mapCategoriesGroupLabel;

		[SerializeField]
		private string _calibrateWindow_deadZoneSliderLabel;

		[SerializeField]
		private string _calibrateWindow_zeroSliderLabel;

		[SerializeField]
		private string _calibrateWindow_sensitivitySliderLabel;

		[SerializeField]
		private string _calibrateWindow_invertToggleLabel;

		[SerializeField]
		private string _calibrateWindow_calibrateButtonLabel;

		[SerializeField]
		private ModifierKeys _modifierKeys;

		[SerializeField]
		private CustomEntry[] _customEntries;

		private bool _initialized;

		private Dictionary<string, string> customDict;

		public override string yes => null;

		public override string no => null;

		public override string add => null;

		public override string replace => null;

		public override string remove => null;

		public override string swap => null;

		public override string cancel => null;

		public override string none => null;

		public override string okay => null;

		public override string done => null;

		public override string default_ => null;

		public override string assignControllerWindowTitle => null;

		public override string assignControllerWindowMessage => null;

		public override string controllerAssignmentConflictWindowTitle => null;

		public override string elementAssignmentPrePollingWindowMessage => null;

		public override string elementAssignmentConflictWindowMessage => null;

		public override string mouseAssignmentConflictWindowTitle => null;

		public override string calibrateControllerWindowTitle => null;

		public override string calibrateAxisStep1WindowTitle => null;

		public override string calibrateAxisStep2WindowTitle => null;

		public override string inputBehaviorSettingsWindowTitle => null;

		public override string restoreDefaultsWindowTitle => null;

		public override string actionColumnLabel => null;

		public override string keyboardColumnLabel => null;

		public override string mouseColumnLabel => null;

		public override string controllerColumnLabel => null;

		public override string removeControllerButtonLabel => null;

		public override string calibrateControllerButtonLabel => null;

		public override string assignControllerButtonLabel => null;

		public override string inputBehaviorSettingsButtonLabel => null;

		public override string doneButtonLabel => null;

		public override string restoreDefaultsButtonLabel => null;

		public override string controllerSettingsGroupLabel => null;

		public override string playersGroupLabel => null;

		public override string assignedControllersGroupLabel => null;

		public override string settingsGroupLabel => null;

		public override string mapCategoriesGroupLabel => null;

		public override string restoreDefaultsWindowMessage => null;

		public override string calibrateWindow_deadZoneSliderLabel => null;

		public override string calibrateWindow_zeroSliderLabel => null;

		public override string calibrateWindow_sensitivitySliderLabel => null;

		public override string calibrateWindow_invertToggleLabel => null;

		public override string calibrateWindow_calibrateButtonLabel => null;

		public override void Initialize()
		{
		}

		public override string GetCustomEntry(string key)
		{
			return null;
		}

		public override bool ContainsCustomEntryKey(string key)
		{
			return false;
		}

		public override string GetControllerAssignmentConflictWindowMessage(string joystickName, string otherPlayerName, string currentPlayerName)
		{
			return null;
		}

		public override string GetJoystickElementAssignmentPollingWindowMessage(string actionName)
		{
			return null;
		}

		public override string GetJoystickElementAssignmentPollingWindowMessage_FullAxisFieldOnly(string actionName)
		{
			return null;
		}

		public override string GetKeyboardElementAssignmentPollingWindowMessage(string actionName)
		{
			return null;
		}

		public override string GetMouseElementAssignmentPollingWindowMessage(string actionName)
		{
			return null;
		}

		public override string GetMouseElementAssignmentPollingWindowMessage_FullAxisFieldOnly(string actionName)
		{
			return null;
		}

		public override string GetElementAlreadyInUseBlocked(string elementName)
		{
			return null;
		}

		public override string GetElementAlreadyInUseCanReplace(string elementName, bool allowConflicts)
		{
			return null;
		}

		public override string GetMouseAssignmentConflictWindowMessage(string otherPlayerName, string thisPlayerName)
		{
			return null;
		}

		public override string GetCalibrateAxisStep1WindowMessage(string axisName)
		{
			return null;
		}

		public override string GetCalibrateAxisStep2WindowMessage(string axisName)
		{
			return null;
		}

		public override string GetPlayerName(int playerId)
		{
			return null;
		}

		public override string GetControllerName(Controller controller)
		{
			return null;
		}

		public override string GetElementIdentifierName(ActionElementMap actionElementMap)
		{
			return null;
		}

		public override string GetElementIdentifierName(Controller controller, int elementIdentifierId, AxisRange axisRange)
		{
			return null;
		}

		public override string GetElementIdentifierName(KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			return null;
		}

		public override string GetActionName(int actionId)
		{
			return null;
		}

		public override string GetActionName(int actionId, AxisRange axisRange)
		{
			return null;
		}

		public override string GetMapCategoryName(int id)
		{
			return null;
		}

		public override string GetActionCategoryName(int id)
		{
			return null;
		}

		public override string GetLayoutName(ControllerType controllerType, int id)
		{
			return null;
		}

		public override string ModifierKeyFlagsToString(ModifierKeyFlags flags)
		{
			return null;
		}
	}
}
