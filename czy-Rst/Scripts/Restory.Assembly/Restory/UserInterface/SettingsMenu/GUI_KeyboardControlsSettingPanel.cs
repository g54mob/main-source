using System.Collections.Generic;
using Restory.Data.Remapping;
using Restory.Data.SaveLoad.Observers;
using Restory.Gameplay.PlayerInput;
using Restory.Gameplay.PlayerInput.Observers;
using Restory.Remapping;
using Rewired;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Restory.UserInterface.SettingsMenu
{
	public sealed class GUI_KeyboardControlsSettingPanel : GUI_ChildControlsSettingPanel
	{
		public UnityEvent OnRemappingInputListeningStarted = new UnityEvent();

		public UnityEvent OnRemappingSuccessfullyCompleted = new UnityEvent();

		public UnityEvent OnRemappingFailed = new UnityEvent();

		private ControllerType controllerType;

		private int controllerId;

		[SerializeField]
		private GameObject remapItemPrefab;

		[SerializeField]
		private RectTransform container;

		[SerializeField]
		[Min(0f)]
		private float remapTimeout = 5f;

		private readonly List<GUI_RemapItem> buttons = new List<GUI_RemapItem>();

		private IInputUserData inputUserData;

		private RewiredControllerConnectedObserver controllerConnectedObserver;

		private RewiredControllerDisconnectedObserver controllerDisconnectedObserver;

		private PlayerProfileChangeObserver playerProfileChangeObserver;

		private bool initialized;

		private InputRemapping inputMapperKeyboard;

		private GUI_RemapItem remappedButton;

		private HashSet<KeyCode> ignoreKeyCodes = new HashSet<KeyCode>
		{
			KeyCode.Escape,
			KeyCode.LeftWindows,
			KeyCode.RightWindows,
			KeyCode.LeftMeta,
			KeyCode.RightMeta
		};

		private GUI_RemapItem RemappedButton
		{
			get
			{
				return remappedButton;
			}
			set
			{
				if (remappedButton != null)
				{
					remappedButton.IsRemapped = false;
				}
				remappedButton = value;
				if (remappedButton != null)
				{
					remappedButton.IsRemapped = true;
					canvasGroup.interactable = false;
					canvasGroup.ignoreParentGroups = true;
				}
				else
				{
					canvasGroup.interactable = true;
					canvasGroup.ignoreParentGroups = false;
				}
			}
		}

		[Inject]
		private void Construct(IPlayerInput playerInput, RewiredControllerConnectedObserver controllerConnectedObserver, RewiredControllerDisconnectedObserver controllerDisconnectedObserver, PlayerProfileChangeObserver playerProfileChangeObserver, IInputUserData inputUserData)
		{
			base.playerInput = playerInput;
			this.controllerConnectedObserver = controllerConnectedObserver;
			this.controllerDisconnectedObserver = controllerDisconnectedObserver;
			this.inputUserData = inputUserData;
			this.playerProfileChangeObserver = playerProfileChangeObserver;
			playerProfileChangeObserver.AddSubscriber(this, OnProfileChanged);
			inputMapperKeyboard = new InputRemapping(inputUserData, playerInput.Id, controllerType, controllerId);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			playerProfileChangeObserver?.RemoveSubscriber(this);
			OnRemappingInputListeningStarted.RemoveAllListeners();
			OnRemappingSuccessfullyCompleted.RemoveAllListeners();
			OnRemappingFailed.RemoveAllListeners();
		}

		private void Initialize()
		{
			if (!initialized)
			{
				initialized = true;
				inputMapperKeyboard.Options.timeout = remapTimeout;
				inputMapperKeyboard.Options.allowKeyboardKeysWithModifiers = false;
				inputMapperKeyboard.Options.allowKeyboardModifierKeyAsPrimary = true;
				inputMapperKeyboard.Options.ignoreMouseXAxis = true;
				inputMapperKeyboard.Options.ignoreMouseYAxis = true;
				inputMapperKeyboard.Options.allowButtonsOnFullAxisAssignment = false;
				inputMapperKeyboard.Options.isElementAllowedCallback = IsElementAllowed;
				CreateButtons();
				InitializeNavigation();
			}
		}

		private void InitializeNavigation()
		{
			firstNavigationSetter.TargetNavigation = ((buttons.Count > 0) ? buttons[0].gameObject : null);
			for (int i = 0; i < buttons.Count; i++)
			{
				GUI_RemapItem gUI_RemapItem = buttons[i];
				gUI_RemapItem.Navigation.Navigation.SelectOnLeft.SetNone();
				gUI_RemapItem.Navigation.Navigation.SelectOnRight.SetNone();
			}
			for (int j = 1; j < buttons.Count; j++)
			{
				GUI_RemapItem gUI_RemapItem2 = buttons[j - 1];
				GUI_RemapItem gUI_RemapItem3 = buttons[j];
				gUI_RemapItem2.Navigation.Navigation.SelectOnDown.SetExplicit(gUI_RemapItem3.Navigation);
				gUI_RemapItem3.Navigation.Navigation.SelectOnUp.SetExplicit(gUI_RemapItem2.Navigation);
			}
		}

		private void CreateButtons()
		{
			ClearButtons();
			if (!inputUserData.RemappingButtonsList.TryGetRemappingButtons(controllerType, out var readOnlyList))
			{
				return;
			}
			foreach (RemappingButton item in readOnlyList)
			{
				GUI_RemapItem gUI_RemapItem = objectPool.GetObject<GUI_RemapItem>(remapItemPrefab, container);
				gUI_RemapItem.RemappingButton = item;
				gUI_RemapItem.OnClick += Item_OnClick;
				buttons.Add(gUI_RemapItem);
			}
		}

		private void ClearButtons()
		{
			foreach (GUI_RemapItem button in buttons)
			{
				if (!(button == null))
				{
					button.OnClick -= Item_OnClick;
					if (objectPool != null)
					{
						objectPool.Clean(remapItemPrefab, button.gameObject);
					}
				}
			}
			buttons.Clear();
		}

		private void UpdateViewButtons()
		{
			foreach (GUI_RemapItem button in buttons)
			{
				button.Key = inputUserData.GetButtonName(playerInput.Id, controllerType, controllerId, button.RemappingButton.Action, button.RemappingButton.AxisRange);
				button.Conflict = inputUserData.CheckConflict(playerInput.Id, controllerType, controllerId, button.RemappingButton.Action, button.RemappingButton.AxisRange);
			}
		}

		public override void Show()
		{
			Initialize();
			base.Show();
		}

		public override void Hide()
		{
			StopListening();
			inputUserData?.Load();
			base.Hide();
		}

		protected override void SubscribeChildren()
		{
			base.SubscribeChildren();
			if (inputMapperKeyboard != null)
			{
				inputMapperKeyboard.StartedEvent += InputMapperKeyboard_StartedEvent;
				inputMapperKeyboard.InputMappedEvent += InputMapperKeyboard_OnInputMapped;
				inputMapperKeyboard.ErrorEvent += InputMapperKeyboard_ErrorEvent;
				inputMapperKeyboard.TimedOutEvent += InputMapperKeyboard_TimedOutEvent;
				inputMapperKeyboard.CanceledEvent += InputMapperKeyboard_CanceledEvent;
				inputMapperKeyboard.StoppedEvent += InputMapperKeyboard_OnStopped;
			}
			controllerConnectedObserver?.AddSubscriber(this, ReInput_OnControllerChanged);
			controllerDisconnectedObserver?.AddSubscriber(this, ReInput_OnControllerChanged);
		}

		protected override void UnsubscribeChildren()
		{
			base.UnsubscribeChildren();
			if (inputMapperKeyboard != null)
			{
				inputMapperKeyboard.StartedEvent -= InputMapperKeyboard_StartedEvent;
				inputMapperKeyboard.InputMappedEvent -= InputMapperKeyboard_OnInputMapped;
				inputMapperKeyboard.ErrorEvent -= InputMapperKeyboard_ErrorEvent;
				inputMapperKeyboard.TimedOutEvent -= InputMapperKeyboard_TimedOutEvent;
				inputMapperKeyboard.CanceledEvent -= InputMapperKeyboard_CanceledEvent;
				inputMapperKeyboard.StoppedEvent -= InputMapperKeyboard_OnStopped;
			}
			controllerConnectedObserver?.RemoveSubscriber(this);
			controllerDisconnectedObserver?.RemoveSubscriber(this);
		}

		public override void Load()
		{
			inputUserData.Load();
			UpdateViewButtons();
			SetHasChange(value: false);
			UpdateIsDefaultValues();
		}

		public override void SetDefault()
		{
			inputUserData.LoadDefault();
			UpdateViewButtons();
			SetHasChange(value: true);
			UpdateIsDefaultValues();
		}

		public override void Apply()
		{
			inputUserData.Save();
			gameSettingsSaver.Save();
			SetHasChange(value: false);
			UpdateIsDefaultValues();
		}

		protected override void UpdateHasChanges()
		{
			SetHasChange(value: false);
		}

		protected override void UpdateIsDefaultValues()
		{
			SetIsDefaultValues(inputUserData.IsDefault());
		}

		private void StartListening(GUI_RemapItem button)
		{
			StopListening();
			if (inputMapperKeyboard.Start(button.RemappingButton.Action, button.RemappingButton.AxisRange))
			{
				RemappedButton = button;
			}
			else
			{
				Debug.LogError("<color=red>Failed to start listening</color>");
			}
		}

		private void StopListening()
		{
			inputMapperKeyboard?.Stop();
			RemappedButton = null;
		}

		private void OnProfileChanged()
		{
			playerInput.ResetToDefaults(controllerType);
			Load();
		}

		private void Item_OnClick(GUI_RemapItem button)
		{
			StartListening(button);
		}

		private void ReInput_OnControllerChanged(int controllerId, ControllerType type)
		{
			StopListening();
		}

		public bool IsElementAllowed(ControllerPollingInfo info)
		{
			return !ignoreKeyCodes.Contains(info.keyboardKey);
		}

		private void InputMapperKeyboard_StartedEvent()
		{
			OnRemappingInputListeningStarted?.Invoke();
		}

		private void InputMapperKeyboard_OnStopped()
		{
			RemappedButton = null;
		}

		private void InputMapperKeyboard_OnInputMapped()
		{
			RemappedButton = null;
			UpdateViewButtons();
			SetHasChange(value: true);
			UpdateIsDefaultValues();
			OnRemappingSuccessfullyCompleted?.Invoke();
		}

		private void InputMapperKeyboard_ErrorEvent(string message)
		{
			OnRemappingFailed?.Invoke();
		}

		private void InputMapperKeyboard_TimedOutEvent()
		{
			OnRemappingFailed?.Invoke();
		}

		private void InputMapperKeyboard_CanceledEvent(string message)
		{
			OnRemappingFailed?.Invoke();
		}
	}
}
