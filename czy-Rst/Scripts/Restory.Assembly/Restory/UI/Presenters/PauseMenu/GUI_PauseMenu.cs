using System;
using Restory.AssetManagement.References;
using Restory.Gameplay.SaveLoad.Services;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States.InitializationStates;
using Restory.UI.Presenters.ConfirmationDialog;
using Restory.UI.Presenters.SettingsMenu;
using Restory.UI.Views.PauseMenu;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.PauseMenu
{
	public class GUI_PauseMenu : MonoBehaviour
	{
		[SerializeField]
		private GUI_PauseMenuView view;

		[SerializeField]
		private GUI_SettingsMenu settingsMenu;

		[SerializeField]
		private GUI_ConfirmationDialog confirmationDialog;

		[SerializeField]
		private string confirmationDialogReturnToMainMenuLocID = "UI_CONFIRMATION_DIALOGUE_EXIT";

		[SerializeField]
		private GameScenesAssetRef mainMenuPresetToLoadRef;

		[SerializeField]
		private bool isShown;

		[SerializeField]
		private GUI_PanelStack panelStack;

		private GlobalStateMachine stateMachine;

		private GameplaySaveLoadService saveSystemSaveData;

		public bool IsShown => isShown;

		public event Action<GUI_PauseMenu, bool> OnIsShownChanged;

		[Inject]
		private void Construct(GlobalStateMachine stateMachine, GameplaySaveLoadService saveSystemSaveData)
		{
			this.stateMachine = stateMachine;
			this.saveSystemSaveData = saveSystemSaveData;
			if (isShown)
			{
				saveSystemSaveData.OnSaveCompleted -= ResolveOnSaveCompleted;
				saveSystemSaveData.OnSaveCompleted += ResolveOnSaveCompleted;
				SubscribeView();
				view.SetSaveInfo(saveSystemSaveData.LastSaveDateTime);
			}
		}

		private void OnEnable()
		{
			if (isShown)
			{
				saveSystemSaveData.OnSaveCompleted += ResolveOnSaveCompleted;
				SubscribeView();
			}
		}

		private void OnDisable()
		{
			if (isShown)
			{
				saveSystemSaveData.OnSaveCompleted -= ResolveOnSaveCompleted;
				UnsubscribeView();
			}
		}

		public void Show()
		{
			if (!isShown)
			{
				isShown = true;
				panelStack?.AddPanel(base.gameObject);
				saveSystemSaveData.OnSaveCompleted += ResolveOnSaveCompleted;
				SubscribeView();
				view.SetSaveInfo(saveSystemSaveData.LastSaveDateTime);
				view.Show();
				this.OnIsShownChanged?.Invoke(this, isShown);
			}
		}

		public void Hide()
		{
			if (isShown)
			{
				isShown = false;
				panelStack?.RemovePanel(base.gameObject);
				saveSystemSaveData.OnSaveCompleted -= ResolveOnSaveCompleted;
				UnsubscribeView();
				view.Hide();
				this.OnIsShownChanged?.Invoke(this, isShown);
			}
		}

		private void SubscribeView()
		{
			UnsubscribeView();
			view.OnContinueClick += ResolveOnContinueClick;
			view.OnSaveGameClick += ResolveOnSaveGameClick;
			view.OnSettingsClick += ResolveOnSettingsClick;
			view.OnMainMenuClick += ResolveOnMainMenuClick;
		}

		private void UnsubscribeView()
		{
			view.OnContinueClick -= ResolveOnContinueClick;
			view.OnSaveGameClick -= ResolveOnSaveGameClick;
			view.OnSettingsClick -= ResolveOnSettingsClick;
			view.OnMainMenuClick -= ResolveOnMainMenuClick;
		}

		private void ResolveOnContinueClick()
		{
			Hide();
		}

		private void ResolveOnSaveGameClick()
		{
			saveSystemSaveData.SaveProgressAsync();
		}

		private void ResolveOnSettingsClick()
		{
			settingsMenu.Show();
		}

		private void ResolveOnMainMenuClick()
		{
			confirmationDialog.Show(confirmationDialogReturnToMainMenuLocID, delegate
			{
				UnsubscribeView();
				confirmationDialog.Hide();
				stateMachine.Enter<StartLoadingPresetListState, GameScenesAssetRef>(mainMenuPresetToLoadRef);
			}, confirmationDialog.Hide);
		}

		private void ResolveOnSaveCompleted()
		{
			view.SetSaveInfo(saveSystemSaveData.LastSaveDateTime);
		}
	}
}
