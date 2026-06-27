using System;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.Equipment.PersonalComputers;
using Restory.Gameplay.PlayerInput;
using Restory.UI.Presenters;
using Restory.UI.Presenters.PauseMenu;
using Rewired;
using Zenject;

namespace Restory.Gameplay.OverlayActivators
{
	public class PcActivator : WindowActivatorBase, IInitializable, IDisposable
	{
		private IPlayerInput playerInput;

		private PcInteractiveWorkplaceItem pcInteractiveWorkplaceItem;

		private PcKeyboardInteractiveWorkplaceItem pcKeyboardInteractiveWorkplaceItem;

		private GUI_PcWindowsXpScreen pcScreenPresenter;

		private GUI_PauseMenu pauseMenu;

		public bool IsPcWindowVisible => pcScreenPresenter.IsVisible;

		public override bool IsActivated => pcScreenPresenter.IsVisible;

		public event Action OnPcWindowVisibilityChanged;

		[Inject]
		private void Construct(IPlayerInput playerInput, PcInteractiveWorkplaceItem pcInteractiveWorkplaceItem, PcKeyboardInteractiveWorkplaceItem pcKeyboardInteractiveWorkplaceItem, GUI_PcWindowsXpScreen pcScreenPresenter, GUI_PauseMenu pauseMenu)
		{
			this.playerInput = playerInput;
			this.pcInteractiveWorkplaceItem = pcInteractiveWorkplaceItem;
			this.pcKeyboardInteractiveWorkplaceItem = pcKeyboardInteractiveWorkplaceItem;
			this.pcScreenPresenter = pcScreenPresenter;
			this.pauseMenu = pauseMenu;
		}

		public void Initialize()
		{
			playerInput.AddInputEventDelegate(ResolveInputButtonJustPressed, InputActionEventType.ButtonJustReleased, 97);
			pcInteractiveWorkplaceItem.OnPcOpened += ResolvePcTriggerClick;
			pcScreenPresenter.OnIsVisibleChanged += ResolvePcScreenVisibilityChanged;
		}

		public void Dispose()
		{
			playerInput?.RemoveInputEventDelegate(ResolveInputButtonJustPressed, InputActionEventType.ButtonJustReleased, 97);
			pcInteractiveWorkplaceItem.OnPcOpened -= ResolvePcTriggerClick;
			pcScreenPresenter.OnIsVisibleChanged -= ResolvePcScreenVisibilityChanged;
		}

		public void ShowWindow()
		{
			if (!pcScreenPresenter.IsVisible)
			{
				pcScreenPresenter.Show();
			}
		}

		public void HideWindow()
		{
			if (pcScreenPresenter.IsVisible)
			{
				pcScreenPresenter.Hide();
			}
		}

		protected override void ResolveOnIsBlockedChanged(bool isBlocked)
		{
			pcInteractiveWorkplaceItem.Trigger.Toggle(!isBlocked);
			pcKeyboardInteractiveWorkplaceItem.Trigger.Toggle(!isBlocked);
		}

		private void ResolvePcTriggerClick()
		{
			SwitchPC();
		}

		private void ResolveInputButtonJustPressed(InputActionEventData eventData)
		{
			SwitchPC();
		}

		private void SwitchPC()
		{
			if (!base.IsBlocked && pcInteractiveWorkplaceItem.IsOn && pcInteractiveWorkplaceItem.IsInternetOn)
			{
				if (pcScreenPresenter.IsVisible)
				{
					pcScreenPresenter.Hide();
				}
				else if (!pauseMenu.IsShown)
				{
					pcScreenPresenter.Show();
				}
			}
		}

		private void ResolvePcScreenVisibilityChanged()
		{
			this.OnPcWindowVisibilityChanged?.Invoke();
		}
	}
}
