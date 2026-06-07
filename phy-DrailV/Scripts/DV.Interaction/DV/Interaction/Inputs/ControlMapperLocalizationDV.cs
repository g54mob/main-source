using DV.Localization;
using Rewired;
using Rewired.UI.ControlMapper;
using UnityEngine;

namespace DV.Interaction.Inputs
{
	[CreateAssetMenu(menuName = "DV/Control Mapper Localization")]
	public class ControlMapperLocalizationDV : LanguageDataBase
	{
		public LanguageData fallback;

		[SerializeField]
		private string _yes = "yes";

		[SerializeField]
		private string _no = "no";

		[SerializeField]
		private string _add = "binding/add";

		[SerializeField]
		private string _replace = "binding/replace";

		[SerializeField]
		private string _remove = "binding/remove";

		[SerializeField]
		private string _swap = "binding/swap";

		[SerializeField]
		private string _cancel = "cancel";

		[SerializeField]
		private string _none = "binding/none";

		[SerializeField]
		private string _okay = "binding/okay";

		[SerializeField]
		private string _done = "done";

		[SerializeField]
		private string _default = "binding/default";

		[SerializeField]
		private string _assignControllerWindowTitle = "binding/assignControllerWindowTitle";

		[SerializeField]
		private string _assignControllerWindowMessage = "binding/assignControllerWindowMessage";

		[SerializeField]
		private string _controllerAssignmentConflictWindowTitle = "binding/controllerAssignmentConflictWindowTitle";

		[SerializeField]
		[Tooltip("{0} = Joystick Name\n{1} = Other Player Name\n{2} = This Player Name")]
		private string _controllerAssignmentConflictWindowMessage = "binding/controllerAssignmentConflictWindowMessage";

		[SerializeField]
		private string _elementAssignmentPrePollingWindowMessage = "binding/elementAssignmentPrePollingWindowMessage";

		[SerializeField]
		[Tooltip("{0} = Action Name")]
		private string _joystickElementAssignmentPollingWindowMessage = "binding/joystickElementAssignmentPollingWindowMessage";

		[SerializeField]
		[Tooltip("This text is only displayed when split-axis fields have been disabled and the user clicks on the full-axis field. Button/key/D-pad input cannot be assigned to a full-axis field.\n{0} = Action Name")]
		private string _joystickElementAssignmentPollingWindowMessage_fullAxisFieldOnly = "binding/joystickElementAssignmentPollingWindowMessage_fullAxisFieldOnly";

		[SerializeField]
		[Tooltip("{0} = Action Name")]
		private string _keyboardElementAssignmentPollingWindowMessage = "binding/keyboardElementAssignmentPollingWindowMessage";

		[SerializeField]
		[Tooltip("{0} = Action Name")]
		private string _mouseElementAssignmentPollingWindowMessage = "binding/mouseElementAssignmentPollingWindowMessage";

		[SerializeField]
		[Tooltip("This text is only displayed when split-axis fields have been disabled and the user clicks on the full-axis field. Button/key/D-pad input cannot be assigned to a full-axis field.\n{0} = Action Name")]
		private string _mouseElementAssignmentPollingWindowMessage_fullAxisFieldOnly = "binding/mouseElementAssignmentPollingWindowMessage_fullAxisFieldOnly";

		[SerializeField]
		private string _elementAssignmentConflictWindowMessage = "binding/elementAssignmentConflictWindowMessage";

		[SerializeField]
		[Tooltip("{0} = Element Name")]
		private string _elementAlreadyInUseBlocked = "binding/elementAlreadyInUseBlocked";

		[SerializeField]
		[Tooltip("{0} = Element Name")]
		private string _elementAlreadyInUseCanReplace = "binding/elementAlreadyInUseCanReplace";

		[SerializeField]
		[Tooltip("{0} = Element Name")]
		private string _elementAlreadyInUseCanReplace_conflictAllowed = "binding/elementAlreadyInUseCanReplace_conflictAllowed";

		[SerializeField]
		private string _mouseAssignmentConflictWindowTitle = "binding/mouseAssignmentConflictWindowTitle";

		[SerializeField]
		[Tooltip("{0} = Other Player Name\n{1} = This Player Name")]
		private string _mouseAssignmentConflictWindowMessage = "binding/mouseAssignmentConflictWindowMessage";

		[SerializeField]
		private string _calibrateControllerWindowTitle = "binding/calibrateControllerWindowTitle";

		[SerializeField]
		private string _calibrateAxisStep1WindowTitle = "binding/calibrateAxisStep1WindowTitle";

		[SerializeField]
		[Tooltip("{0} = Axis Name")]
		private string _calibrateAxisStep1WindowMessage = "binding/calibrateAxisStep1WindowMessage";

		[SerializeField]
		private string _calibrateAxisStep2WindowTitle = "binding/calibrateAxisStep2WindowTitle";

		[SerializeField]
		[Tooltip("{0} = Axis Name")]
		private string _calibrateAxisStep2WindowMessage = "binding/calibrateAxisStep2WindowMessage";

		[SerializeField]
		private string _inputBehaviorSettingsWindowTitle = "binding/inputBehaviorSettingsWindowTitle";

		[SerializeField]
		private string _restoreDefaultsWindowTitle = "binding/restoreDefaultsWindowTitle";

		[SerializeField]
		[Tooltip("Message for a single player game.")]
		private string _restoreDefaultsWindowMessage_onePlayer = "binding/restoreDefaultsWindowMessage_onePlayer";

		[SerializeField]
		[Tooltip("Message for a multi-player game.")]
		private string _restoreDefaultsWindowMessage_multiPlayer = "binding/restoreDefaultsWindowMessage_multiPlayer";

		[SerializeField]
		private string _actionColumnLabel = "binding/actionColumnLabel";

		[SerializeField]
		private string _keyboardColumnLabel = "binding/keyboardColumnLabel";

		[SerializeField]
		private string _mouseColumnLabel = "binding/mouseColumnLabel";

		[SerializeField]
		private string _controllerColumnLabel = "binding/controllerColumnLabel";

		[SerializeField]
		private string _removeControllerButtonLabel = "binding/removeControllerButtonLabel";

		[SerializeField]
		private string _calibrateControllerButtonLabel = "binding/calibrateControllerButtonLabel";

		[SerializeField]
		private string _assignControllerButtonLabel = "binding/assignControllerButtonLabel";

		[SerializeField]
		private string _inputBehaviorSettingsButtonLabel = "binding/inputBehaviorSettingsButtonLabel";

		[SerializeField]
		private string _doneButtonLabel = "binding/doneButtonLabel";

		[SerializeField]
		private string _restoreDefaultsButtonLabel = "binding/restoreDefaultsButtonLabel";

		[SerializeField]
		private string _playersGroupLabel = "binding/playersGroupLabel";

		[SerializeField]
		private string _controllerSettingsGroupLabel = "binding/controllerSettingsGroupLabel";

		[SerializeField]
		private string _assignedControllersGroupLabel = "binding/assignedControllersGroupLabel";

		[SerializeField]
		private string _settingsGroupLabel = "binding/settingsGroupLabel";

		[SerializeField]
		private string _mapCategoriesGroupLabel = "binding/mapCategoriesGroupLabel";

		[SerializeField]
		private string _calibrateWindow_deadZoneSliderLabel = "binding/calibrateWindow_deadZoneSliderLabel";

		[SerializeField]
		private string _calibrateWindow_zeroSliderLabel = "binding/calibrateWindow_zeroSliderLabel";

		[SerializeField]
		private string _calibrateWindow_sensitivitySliderLabel = "binding/calibrateWindow_sensitivitySliderLabel";

		[SerializeField]
		private string _calibrateWindow_invertToggleLabel = "binding/calibrateWindow_invertToggleLabel";

		[SerializeField]
		private string _calibrateWindow_calibrateButtonLabel = "binding/calibrateWindow_calibrateButtonLabel";

		public override string yes => LocalizationAPI.L(_yes);

		public override string no => LocalizationAPI.L(_no);

		public override string add => LocalizationAPI.L(_add);

		public override string replace => LocalizationAPI.L(_replace);

		public override string remove => LocalizationAPI.L(_remove);

		public override string swap => LocalizationAPI.L(_swap);

		public override string cancel => LocalizationAPI.L(_cancel);

		public override string none => LocalizationAPI.L(_none);

		public override string okay => LocalizationAPI.L(_okay);

		public override string done => LocalizationAPI.L(_done);

		public override string default_ => LocalizationAPI.L(_default);

		public override string assignControllerWindowTitle => LocalizationAPI.L(_assignControllerWindowTitle);

		public override string assignControllerWindowMessage => LocalizationAPI.L(_assignControllerWindowMessage);

		public override string controllerAssignmentConflictWindowTitle => LocalizationAPI.L(_controllerAssignmentConflictWindowTitle);

		public override string elementAssignmentPrePollingWindowMessage => LocalizationAPI.L(_elementAssignmentPrePollingWindowMessage);

		public override string elementAssignmentConflictWindowMessage => LocalizationAPI.L(_elementAssignmentConflictWindowMessage);

		public override string mouseAssignmentConflictWindowTitle => LocalizationAPI.L(_mouseAssignmentConflictWindowTitle);

		public override string calibrateControllerWindowTitle => LocalizationAPI.L(_calibrateControllerWindowTitle);

		public override string calibrateAxisStep1WindowTitle => LocalizationAPI.L(_calibrateAxisStep1WindowTitle);

		public override string calibrateAxisStep2WindowTitle => LocalizationAPI.L(_calibrateAxisStep2WindowTitle);

		public override string inputBehaviorSettingsWindowTitle => LocalizationAPI.L(_inputBehaviorSettingsWindowTitle);

		public override string restoreDefaultsWindowTitle => LocalizationAPI.L(_restoreDefaultsWindowTitle);

		public override string actionColumnLabel => LocalizationAPI.L(_actionColumnLabel);

		public override string keyboardColumnLabel => LocalizationAPI.L(_keyboardColumnLabel);

		public override string mouseColumnLabel => LocalizationAPI.L(_mouseColumnLabel);

		public override string controllerColumnLabel => LocalizationAPI.L(_controllerColumnLabel);

		public override string removeControllerButtonLabel => LocalizationAPI.L(_removeControllerButtonLabel);

		public override string calibrateControllerButtonLabel => LocalizationAPI.L(_calibrateControllerButtonLabel);

		public override string assignControllerButtonLabel => LocalizationAPI.L(_assignControllerButtonLabel);

		public override string inputBehaviorSettingsButtonLabel => LocalizationAPI.L(_inputBehaviorSettingsButtonLabel);

		public override string doneButtonLabel => LocalizationAPI.L(_doneButtonLabel);

		public override string restoreDefaultsButtonLabel => LocalizationAPI.L(_restoreDefaultsButtonLabel);

		public override string controllerSettingsGroupLabel => LocalizationAPI.L(_controllerSettingsGroupLabel);

		public override string playersGroupLabel => LocalizationAPI.L(_playersGroupLabel);

		public override string assignedControllersGroupLabel => LocalizationAPI.L(_assignedControllersGroupLabel);

		public override string settingsGroupLabel => LocalizationAPI.L(_settingsGroupLabel);

		public override string mapCategoriesGroupLabel => LocalizationAPI.L(_mapCategoriesGroupLabel);

		public override string restoreDefaultsWindowMessage => LocalizationAPI.L((ReInput.players.playerCount > 1) ? _restoreDefaultsWindowMessage_multiPlayer : _restoreDefaultsWindowMessage_onePlayer);

		public override string calibrateWindow_deadZoneSliderLabel => LocalizationAPI.L(_calibrateWindow_deadZoneSliderLabel);

		public override string calibrateWindow_zeroSliderLabel => LocalizationAPI.L(_calibrateWindow_zeroSliderLabel);

		public override string calibrateWindow_sensitivitySliderLabel => LocalizationAPI.L(_calibrateWindow_sensitivitySliderLabel);

		public override string calibrateWindow_invertToggleLabel => LocalizationAPI.L(_calibrateWindow_invertToggleLabel);

		public override string calibrateWindow_calibrateButtonLabel => LocalizationAPI.L(_calibrateWindow_calibrateButtonLabel);

		public override void Initialize()
		{
		}

		public override string GetCustomEntry(string key)
		{
			return fallback.GetCustomEntry(key);
		}

		public override bool ContainsCustomEntryKey(string key)
		{
			return fallback.ContainsCustomEntryKey(key);
		}

		public override string GetControllerAssignmentConflictWindowMessage(string joystickName, string otherPlayerName, string currentPlayerName)
		{
			return LocalizationAPI.L(_controllerAssignmentConflictWindowMessage, joystickName, otherPlayerName, currentPlayerName);
		}

		public override string GetJoystickElementAssignmentPollingWindowMessage(string actionName)
		{
			return LocalizationAPI.L(_joystickElementAssignmentPollingWindowMessage, actionName);
		}

		public override string GetJoystickElementAssignmentPollingWindowMessage_FullAxisFieldOnly(string actionName)
		{
			return LocalizationAPI.L(_joystickElementAssignmentPollingWindowMessage_fullAxisFieldOnly, actionName);
		}

		public override string GetKeyboardElementAssignmentPollingWindowMessage(string actionName)
		{
			return LocalizationAPI.L(_keyboardElementAssignmentPollingWindowMessage, actionName);
		}

		public override string GetMouseElementAssignmentPollingWindowMessage(string actionName)
		{
			return LocalizationAPI.L(_mouseElementAssignmentPollingWindowMessage, actionName);
		}

		public override string GetMouseElementAssignmentPollingWindowMessage_FullAxisFieldOnly(string actionName)
		{
			return LocalizationAPI.L(_mouseElementAssignmentPollingWindowMessage_fullAxisFieldOnly, actionName);
		}

		public override string GetElementAlreadyInUseBlocked(string elementName)
		{
			return LocalizationAPI.L(_elementAlreadyInUseBlocked, elementName);
		}

		public override string GetElementAlreadyInUseCanReplace(string elementName, bool allowConflicts)
		{
			if (!allowConflicts)
			{
				return LocalizationAPI.L(_elementAlreadyInUseCanReplace, elementName);
			}
			return LocalizationAPI.L(_elementAlreadyInUseCanReplace_conflictAllowed, elementName);
		}

		public override string GetMouseAssignmentConflictWindowMessage(string otherPlayerName, string thisPlayerName)
		{
			return LocalizationAPI.L(_mouseAssignmentConflictWindowMessage, otherPlayerName, thisPlayerName);
		}

		public override string GetCalibrateAxisStep1WindowMessage(string axisName)
		{
			return LocalizationAPI.L(_calibrateAxisStep1WindowMessage, axisName);
		}

		public override string GetCalibrateAxisStep2WindowMessage(string axisName)
		{
			return LocalizationAPI.L(_calibrateAxisStep2WindowMessage, axisName);
		}

		public override string GetPlayerName(int playerId)
		{
			return fallback.GetPlayerName(playerId);
		}

		public override string GetControllerName(Controller controller)
		{
			return fallback.GetControllerName(controller);
		}

		public override string GetElementIdentifierName(ActionElementMap actionElementMap)
		{
			return fallback.GetElementIdentifierName(actionElementMap);
		}

		public override string GetElementIdentifierName(Controller controller, int elementIdentifierId, AxisRange axisRange)
		{
			return fallback.GetElementIdentifierName(controller, elementIdentifierId, axisRange);
		}

		public override string GetElementIdentifierName(KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			return fallback.GetElementIdentifierName(keyCode, modifierKeyFlags);
		}

		public override string GetActionName(int actionId)
		{
			return fallback.GetActionName(actionId);
		}

		public override string GetActionName(int actionId, AxisRange axisRange)
		{
			return fallback.GetActionName(actionId, axisRange);
		}

		public override string GetMapCategoryName(int id)
		{
			return fallback.GetMapCategoryName(id);
		}

		public override string GetActionCategoryName(int id)
		{
			return fallback.GetActionCategoryName(id);
		}

		public override string GetLayoutName(ControllerType controllerType, int id)
		{
			return fallback.GetLayoutName(controllerType, id);
		}

		public override string ModifierKeyFlagsToString(ModifierKeyFlags flags)
		{
			return fallback.ModifierKeyFlagsToString(flags);
		}
	}
}
