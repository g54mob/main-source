using System;
using System.Collections.Generic;
using Restory.Data.GUIControllerElements;
using Restory.Data.Localization;
using Restory.UserInterface.CommonElements;
using Rewired;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface.SettingsMenu
{
	public sealed class GUI_GamepadControlsSettingPanel : GUI_ChildControlsSettingPanel
	{
		[Space]
		[SerializeField]
		private GUI_DropdownWithData gamepadSchemeDropdown;

		[SerializeField]
		private string gamepadSchemeAutoLocKey;

		[SerializeField]
		private ControllerIdsList controllerIdsList;

		[SerializeField]
		private RewiredControllerIdsDependencyMap rewiredControllerIdsDependencyMap;

		[SerializeField]
		private GUI_GamepadSchemeContainer gamepadSchemeContainer;

		private LocalizationSystem localizationSystem;

		[Inject]
		private void Construct(LocalizationSystem localizationSystem)
		{
			this.localizationSystem = localizationSystem;
			if (localizationSystem == null)
			{
				Debug.LogException(new Exception("[Type] got injected with a null LocalizationSystem!"));
			}
		}

		protected override void SubscribeChildren()
		{
			base.SubscribeChildren();
			gamepadSchemeDropdown.onValueChanged.AddListener(ResolveGamepadSchemeDropdownOnValueChanged);
			gamepadSchemeDropdown.IsShownChanged += ResolveDropdownIsShownChanged;
			if (gameSettingsManager != null)
			{
				gameSettingsManager.OnLocalisationChanged.AddListener(OnLocalisationChanged);
			}
		}

		protected override void UnsubscribeChildren()
		{
			base.UnsubscribeChildren();
			gamepadSchemeDropdown.onValueChanged.RemoveListener(ResolveGamepadSchemeDropdownOnValueChanged);
			gamepadSchemeDropdown.IsShownChanged += ResolveDropdownIsShownChanged;
			if (gameSettingsManager != null)
			{
				gameSettingsManager.OnLocalisationChanged.RemoveListener(OnLocalisationChanged);
			}
		}

		public override void Load()
		{
			gamepadSchemeDropdown.SetValueWithoutNotifyByData(gameSettingsManager.GamepadScheme);
			UpdateSchemeContainer();
			UpdateHasChanges();
			UpdateIsDefaultValues();
		}

		public override void SetDefault()
		{
			gamepadSchemeDropdown.SetValueWithoutNotifyByData(gameSettingsManager.DefaultData.GamepadScheme);
			UpdateSchemeContainer();
			UpdateHasChanges();
			UpdateIsDefaultValues();
		}

		public override void Apply()
		{
			gameSettingsManager.GamepadScheme = gamepadSchemeDropdown.GetData(string.Empty);
			gameSettingsSaver.Save();
			UpdateHasChanges();
			UpdateIsDefaultValues();
		}

		public override void UpdateView()
		{
			base.UpdateView();
			UpdateGamepadSchemeDropdownValues();
		}

		private void UpdateGamepadSchemeDropdownValues()
		{
			string data = gamepadSchemeDropdown.GetData(string.Empty);
			List<Dropdown.OptionData> list = new List<Dropdown.OptionData>(controllerIdsList.GamepadIds.Count);
			string translation = localizationSystem.GetTranslation(gamepadSchemeAutoLocKey);
			list.Add(new GUI_DropdownWithData.OptionData<string>(string.Empty, translation));
			foreach (ControllerId gamepadId in controllerIdsList.GamepadIds)
			{
				translation = localizationSystem.GetTranslation(gamepadId.LocalizationNameKey);
				list.Add(new GUI_DropdownWithData.OptionData<string>(gamepadId.ID, translation));
			}
			gamepadSchemeDropdown.ClearOptions();
			gamepadSchemeDropdown.AddOptions(list);
			gamepadSchemeDropdown.SetValueWithoutNotifyByData(data);
		}

		protected override void UpdateHasChanges()
		{
			if (!(gameSettingsManager == null))
			{
				SetHasChange(gameSettingsManager.GamepadScheme != gamepadSchemeDropdown.GetData(string.Empty));
			}
		}

		protected override void UpdateIsDefaultValues()
		{
			if (!(gameSettingsManager == null))
			{
				SetIsDefaultValues(gameSettingsManager.DefaultData.GamepadScheme == gamepadSchemeDropdown.GetData(string.Empty));
			}
		}

		private void UpdateSchemeContainer()
		{
			gamepadSchemeContainer.SetControllerId(GetGamepadId());
		}

		private ControllerId GetGamepadId()
		{
			string data = gamepadSchemeDropdown.GetData(string.Empty);
			if (!controllerIdsList.TryGetControllerId(data, out var controllerId))
			{
				return GetActiveGamepadId();
			}
			return controllerId;
		}

		private ControllerId GetActiveGamepadId()
		{
			Controller controller = playerInput.GetLastActiveController(ControllerType.Joystick);
			if (controller == null && playerInput.Controllers.joystickCount > 0)
			{
				controller = playerInput.Controllers.Joysticks[0];
			}
			if (controller != null)
			{
				rewiredControllerIdsDependencyMap.TryGetControllerId(controller.hardwareTypeGuid, out var controllerId);
				return controllerId;
			}
			return null;
		}

		private void OnLocalisationChanged(SystemLanguage parLanguage)
		{
			UpdateView();
		}

		private void ResolveDropdownIsShownChanged(Dropdown dropdown, bool isShown)
		{
			canvasGroup.interactable = !isShown;
			dropdown.GetComponent<CanvasGroup>().ignoreParentGroups = isShown;
		}

		private void ResolveGamepadSchemeDropdownOnValueChanged(int value)
		{
			UpdateSchemeContainer();
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnDropdownChangedValue?.Invoke();
		}
	}
}
