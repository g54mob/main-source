using Data.UI.Controls;
using Events.UI.Overlays;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Utils.Enums;

namespace Presentation.UI.Controls
{
	public class SettingsControls : MonoBehaviour
	{
		[SerializeField]
		private SettingsRebindDatabase _database;

		[SerializeField]
		private SettingsRebindRuntimeInfo _runtimeInfo;

		[SerializeField]
		private SettingsControlsPopulator _populator;

		[SerializeField]
		private InputActionAsset _defaultInputActions;

		[SerializeField]
		private Button _resetAllButton;

		[Header("Events")]
		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private SettingsRebindEvent _settingRebindStartEvent;

		[SerializeField]
		private SettingsRebindEvent _settingRebindEndEvent;

		private InputActionMap _systemInputActionMap;

		private void Start()
		{
			_settingRebindStartEvent.Register(OnRebindStart);
			_settingRebindEndEvent.Register(OnRebindEnd);
			_resetAllButton.onClick.AddListener(ResetAllBindings);
			_systemInputActionMap = _defaultInputActions.FindActionMap("System");
			InputSystem.onActionChange += OnActionChange;
			_populator.Populate();
		}

		private void OnDestroy()
		{
			_settingRebindStartEvent.UnRegister(OnRebindStart);
			_settingRebindEndEvent.UnRegister(OnRebindEnd);
			_resetAllButton.onClick.RemoveListener(ResetAllBindings);
			InputSystem.onActionChange -= OnActionChange;
		}

		private void OnRebindStart(SettingsRebindAction _)
		{
			_systemInputActionMap.Disable();
		}

		private void OnRebindEnd(SettingsRebindAction _)
		{
			_systemInputActionMap.Enable();
		}

		private void ResetAllBindings()
		{
			MenuModalDialogDto dto = new MenuModalDialogDto("ModalWarning.Title", "ModalWarning.ResetBindings", Sizes.S, ResetAllBindingsInternal, showCancelButton: true)
			{
				OverrideSuccessButtonTextKey = "ModalWarning.ResetBindingsConfirmButton"
			};
			_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
		}

		private void ResetAllBindingsInternal()
		{
			_defaultInputActions.RemoveAllBindingOverrides();
			SettingsRebindGroup[] groups = _database.Groups;
			for (int i = 0; i < groups.Length; i++)
			{
				foreach (SettingsRebindActionData rebindActionData in groups[i].RebindActionDatas)
				{
					rebindActionData.OnChanged();
				}
			}
			foreach (SettingsRebindAction allRebindAction in _runtimeInfo.AllRebindActions)
			{
				allRebindAction.OnChanged(allRebindAction);
				_settingRebindEndEvent.Fire(allRebindAction);
			}
			foreach (SettingsRebindActionUI settingsRebindActionUI in _populator.SettingsRebindActionUIs)
			{
				settingsRebindActionUI.UpdateBindingDisplay();
			}
		}

		private void OnActionChange(object obj, InputActionChange change)
		{
			if (change != InputActionChange.BoundControlsChanged)
			{
				return;
			}
			InputAction inputAction = obj as InputAction;
			InputActionMap inputActionMap = inputAction?.actionMap ?? (obj as InputActionMap);
			InputActionAsset inputActionAsset = inputActionMap?.asset ?? (obj as InputActionAsset);
			foreach (SettingsRebindActionUI settingsRebindActionUI in _populator.SettingsRebindActionUIs)
			{
				InputAction action = settingsRebindActionUI.Action;
				if (action != null && (action == inputAction || action.actionMap == inputActionMap || action.actionMap?.asset == inputActionAsset))
				{
					settingsRebindActionUI.UpdateBindingDisplay();
				}
			}
		}
	}
}
