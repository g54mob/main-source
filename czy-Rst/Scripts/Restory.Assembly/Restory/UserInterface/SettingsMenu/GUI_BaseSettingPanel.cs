using System;
using Restory.EventSystems;
using Restory.Gameplay.GameSettings;
using Restory.Gameplay.PlayerInput;
using Restory.ObjectPools;
using Restory.UserInterface.CommonElements;
using Restory.UserInterface.ConfirmationDialogues;
using Restory.UserInterface.GameplayMenu;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Restory.UserInterface.SettingsMenu
{
	public abstract class GUI_BaseSettingPanel : GUI_PanelBase
	{
		[Serializable]
		public class BaseSettingEvent : UnityEvent<GUI_BaseSettingPanel>
		{
		}

		public UnityEvent<GUI_BaseSettingPanel> OnPanelShown = new UnityEvent<GUI_BaseSettingPanel>();

		public UnityEvent<GUI_BaseSettingPanel> OnPanelHidden = new UnityEvent<GUI_BaseSettingPanel>();

		public UnityEvent<bool> OnToggleSwitchedToNewValue = new UnityEvent<bool>();

		public UnityEvent OnSliderChangedValue = new UnityEvent();

		public UnityEvent OnDropdownChangedValue = new UnityEvent();

		[SerializeField]
		private string locKeyConfirmDefault;

		[SerializeField]
		private string locKeyConfirmApply;

		[Space]
		[SerializeField]
		private bool hasChanges;

		[Space]
		[SerializeField]
		private bool isDefaultValues;

		[SerializeField]
		protected BaseSettingEvent hasChanged = new BaseSettingEvent();

		[SerializeField]
		protected BaseSettingEvent isDefaultValuesChanged = new BaseSettingEvent();

		[SerializeField]
		private GameObject confirmationDialogPrefab;

		[SerializeField]
		protected GUI_SingleFirstNavigationSetter firstNavigationSetter;

		[SerializeField]
		protected CanvasGroup canvasGroup;

		protected ActiveSelectionService activeSelectionService;

		protected GlobalObjectPool objectPool;

		private GUI_ConfirmationDialog confirmationDialog;

		protected GameSettingsManager gameSettingsManager;

		protected GameSettingsDataSaveLoadSystem gameSettingsSaver;

		protected IPlayerInput playerInput;

		private GameObject lastSelection;

		public bool HasChanges => hasChanges;

		public bool IsDefaultValues => isDefaultValues;

		public event UnityAction<GUI_BaseSettingPanel> HasChanged
		{
			add
			{
				hasChanged.AddListener(value);
			}
			remove
			{
				hasChanged.RemoveListener(value);
			}
		}

		public event UnityAction<GUI_BaseSettingPanel> IsDefaultValuesChanged
		{
			add
			{
				isDefaultValuesChanged.AddListener(value);
			}
			remove
			{
				isDefaultValuesChanged.RemoveListener(value);
			}
		}

		protected virtual void OnDestroy()
		{
			UnsubscribeChildren();
			hasChanged.RemoveAllListeners();
			isDefaultValuesChanged.RemoveAllListeners();
			OnPanelShown.RemoveAllListeners();
			OnPanelHidden.RemoveAllListeners();
			OnToggleSwitchedToNewValue.RemoveAllListeners();
			OnSliderChangedValue.RemoveAllListeners();
			OnDropdownChangedValue.RemoveAllListeners();
		}

		[Inject]
		private void Construct(GameSettingsDataSaveLoadSystem gameSettingsSaver, GameSettingsManager gameSettingsManager, GlobalObjectPool objectPool, IPlayerInput playerInput, ActiveSelectionService activeSelectionService)
		{
			this.gameSettingsSaver = gameSettingsSaver;
			this.gameSettingsManager = gameSettingsManager;
			this.objectPool = objectPool;
			this.activeSelectionService = activeSelectionService;
			this.playerInput = playerInput;
			if (gameSettingsManager == null)
			{
				Debug.LogException(new Exception("[Type] got injected with a null GameSettingsManager!"));
			}
		}

		public override void Show()
		{
			base.Show();
			Load();
			SubscribeChildren();
			UpdateView();
			activeSelectionService.Select(firstNavigationSetter.TargetNavigation);
			OnPanelShown?.Invoke(this);
		}

		public override void Hide()
		{
			UnsubscribeChildren();
			base.Hide();
			OnPanelHidden?.Invoke(this);
		}

		public void ConfirmSetDefault(Action<bool> callback = null)
		{
			lastSelection = activeSelectionService.GetCurrentSelection();
			canvasGroup.interactable = false;
			confirmationDialog = objectPool.GetObject<GUI_ConfirmationDialog>(confirmationDialogPrefab.gameObject, null);
			confirmationDialog.ShowLocalizedMessage(locKeyConfirmDefault, delegate
			{
				SetDefault();
				Apply();
				activeSelectionService.Select(lastSelection);
				canvasGroup.interactable = true;
				callback?.Invoke(obj: true);
			}, delegate
			{
				activeSelectionService.Select(lastSelection);
				canvasGroup.interactable = true;
				callback?.Invoke(obj: false);
			});
		}

		public void ConfirmApply(Action<bool> callback = null)
		{
			lastSelection = activeSelectionService.GetCurrentSelection();
			canvasGroup.interactable = false;
			confirmationDialog = objectPool.GetObject<GUI_ConfirmationDialog>(confirmationDialogPrefab.gameObject, null);
			confirmationDialog.ShowLocalizedMessage(locKeyConfirmApply, delegate
			{
				Apply();
				activeSelectionService.Select(lastSelection);
				canvasGroup.interactable = true;
				callback?.Invoke(obj: true);
			}, delegate
			{
				activeSelectionService.Select(lastSelection);
				canvasGroup.interactable = true;
				callback?.Invoke(obj: false);
			});
		}

		protected virtual void SubscribeChildren()
		{
		}

		protected virtual void UnsubscribeChildren()
		{
		}

		public abstract void Load();

		public abstract void SetDefault();

		public abstract void Apply();

		protected virtual void SetHasChange(bool value)
		{
			hasChanges = value;
			hasChanged.Invoke(this);
		}

		protected virtual void SetIsDefaultValues(bool value)
		{
			isDefaultValues = value;
			isDefaultValuesChanged.Invoke(this);
		}

		protected abstract void UpdateHasChanges();

		protected abstract void UpdateIsDefaultValues();
	}
}
