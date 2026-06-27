using System;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.PlayerInput;
using Restory.UI.Presenters.Inventory;
using Restory.UI.Presenters.PauseMenu;
using Rewired;
using Zenject;

namespace Restory.Gameplay.OverlayActivators
{
	public class InventoryActivator : WindowActivatorBase, IInitializable, IDisposable
	{
		private IPlayerInput playerInput;

		private InventoryBox inventoryBox;

		private InventoryPanel inventoryPanel;

		private GUI_PauseMenu pauseMenu;

		public override bool IsActivated => inventoryPanel.IsVisible;

		[Inject]
		private void Construct(IPlayerInput playerInput, InventoryBox inventoryBox, InventoryPanel inventoryPanel, GUI_PauseMenu pauseMenu)
		{
			this.playerInput = playerInput;
			this.inventoryBox = inventoryBox;
			this.inventoryPanel = inventoryPanel;
			this.pauseMenu = pauseMenu;
		}

		public void Initialize()
		{
			playerInput.AddInputEventDelegate(ResolveInventoryButtonJustPressed, InputActionEventType.ButtonJustReleased, 67);
			inventoryBox.Trigger.OnClick += ResolveInventoryTriggerClick;
		}

		public void Dispose()
		{
			playerInput?.RemoveInputEventDelegate(ResolveInventoryButtonJustPressed, InputActionEventType.ButtonJustReleased, 67);
			inventoryBox.Trigger.OnClick -= ResolveInventoryTriggerClick;
		}

		public void ShowWindow()
		{
			if (!inventoryPanel.IsVisible)
			{
				inventoryPanel.Show();
			}
		}

		public void HideWindow()
		{
			if (inventoryPanel.IsVisible)
			{
				inventoryPanel.Hide();
			}
		}

		protected override void ResolveOnIsBlockedChanged(bool isBlocked)
		{
			inventoryBox.Trigger.Toggle(!isBlocked);
		}

		private void ResolveInventoryTriggerClick()
		{
			ActivateInventory();
		}

		private void ResolveInventoryButtonJustPressed(InputActionEventData eventData)
		{
			ActivateInventory();
		}

		private void ActivateInventory()
		{
			if (!base.IsBlocked)
			{
				if (inventoryPanel.IsVisible)
				{
					inventoryPanel.Hide();
				}
				else if (!pauseMenu.IsShown)
				{
					inventoryPanel.Show();
				}
			}
		}
	}
}
