using System;
using Restory.EventSystems.ExitEvents;
using Restory.Gameplay.Common;
using Restory.Gameplay.GameView;
using Restory.UI.Presenters.PC.Apps;
using Restory.UI.Presenters.PC.Notifications;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters
{
	public sealed class GUI_PcWindowsXpScreen : MonoBehaviour, IActiveStateSwitchRequester, IExitablePanel
	{
		[SerializeField]
		private GUI_PcWindowsXpScreenView view;

		[SerializeField]
		private GUI_PcWindowsXpStartMenu startMenu;

		[SerializeField]
		private GUI_PcWindowsXpToolbar toolbar;

		[SerializeField]
		private GUI_PcScreenBlocker screenBlocker;

		[SerializeField]
		private GUI_PcNotificationPanel notificationPanel;

		[SerializeField]
		private GUI_PcAppInstallationPanel installationPanel;

		[SerializeField]
		private GUI_PcAppIconsPanel iconsPanel;

		[SerializeField]
		private Transform appContainer;

		private CameraDirectionSwitcher cameraDirectionSwitcher;

		private PcScreenStates currentState;

		public bool IsVisible => view.IsVisible;

		public GUI_PcNotificationPanel NotificationPanel => notificationPanel;

		public GUI_PcAppInstallationPanel InstallationPanel => installationPanel;

		public GUI_PcAppIconsPanel IconsPanel => iconsPanel;

		public GUI_PcWindowsXpToolbar Toolbar => toolbar;

		public GUI_PcWindowsXpStartMenu StartMenu => startMenu;

		public Transform AppContainer => appContainer;

		public PcScreenStates CurrentState
		{
			get
			{
				return currentState;
			}
			set
			{
				if (value != currentState)
				{
					Debug.Log($"PC is exiting state {currentState}.");
					HideCurrentWindows();
					currentState = value;
					ShowCurrentWindow();
					Debug.Log($"PC entered state {currentState}.");
					this.OnStateChanged?.Invoke();
				}
			}
		}

		public event Action OnStateChanged;

		public event Action OnIsVisibleChanged;

		[Inject]
		private void Construct(CameraDirectionSwitcher cameraDirectionSwitcher)
		{
			this.cameraDirectionSwitcher = cameraDirectionSwitcher;
		}

		private void OnDisable()
		{
			if (view.MonoShellExists())
			{
				view.OnExitButtonClicked -= ResolveExitButtonClicked;
			}
			if (toolbar.MonoShellExists())
			{
				toolbar.OnStartMenuToggleRequested -= ResolveToggleStartMenuRequested;
			}
			if (cameraDirectionSwitcher.MonoShellExists())
			{
				cameraDirectionSwitcher.RemoveBlocker(this);
			}
		}

		public void Show()
		{
			toolbar.Activate();
			view.Show();
			cameraDirectionSwitcher.AddBlocker(this);
			if (CurrentState == PcScreenStates.None)
			{
				CurrentState = PcScreenStates.Desktop;
			}
			else
			{
				ShowCurrentWindow();
			}
			view.OnExitButtonClicked += ResolveExitButtonClicked;
			toolbar.OnStartMenuToggleRequested += ResolveToggleStartMenuRequested;
			this.OnIsVisibleChanged?.Invoke();
		}

		public void Hide()
		{
			if (view.MonoShellExists())
			{
				view.OnExitButtonClicked -= ResolveExitButtonClicked;
			}
			if (toolbar.MonoShellExists())
			{
				toolbar.OnStartMenuToggleRequested -= ResolveToggleStartMenuRequested;
			}
			HideCurrentWindows();
			view.Hide();
			toolbar.Deactivate();
			cameraDirectionSwitcher.RemoveBlocker(this);
			this.OnIsVisibleChanged?.Invoke();
		}

		public void SetFirstMailClientPreviouslyOpenedState(bool wasOpened)
		{
			toolbar.SetFirstMailClientPreviouslyOpenedState(wasOpened);
		}

		public void OnExitEvent()
		{
			Hide();
		}

		private void CloseAllWindows()
		{
			startMenu.Hide();
			toolbar.ChangeStartButtonState(isStartMenuOpen: false);
		}

		private void HideCurrentWindows()
		{
			switch (currentState)
			{
			case PcScreenStates.None:
			case PcScreenStates.InstallingApp:
				CloseAllWindows();
				break;
			case PcScreenStates.InStartMenu:
				startMenu.Hide();
				toolbar.ChangeStartButtonState(isStartMenuOpen: false);
				break;
			}
		}

		private void ShowCurrentWindow()
		{
			switch (currentState)
			{
			case PcScreenStates.Desktop:
				screenBlocker.Deactivate();
				break;
			case PcScreenStates.InStartMenu:
				startMenu.Show();
				toolbar.ChangeStartButtonState(isStartMenuOpen: true);
				break;
			case PcScreenStates.InstallingApp:
				screenBlocker.Activate();
				break;
			}
		}

		private void ResolveExitButtonClicked()
		{
			Hide();
		}

		private void ResolveToggleStartMenuRequested()
		{
			Debug.Log("Start Button Pressed");
			if (CurrentState == PcScreenStates.InStartMenu)
			{
				CurrentState = PcScreenStates.Desktop;
			}
			else
			{
				CurrentState = PcScreenStates.InStartMenu;
			}
		}
	}
}
