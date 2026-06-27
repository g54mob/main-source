using Restory.Data.Tutorials;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.Tutorials.Settings;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UI.Presenters.Inventory;
using Zenject;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class InventoryOpenTutorialHandler : TutorialHandlerBase
	{
		private readonly DisassembleStateMachine disassembleStateMachine;

		private readonly DeviceService deviceService;

		private readonly InventoryPanel inventoryPanel;

		private readonly InventoryBox inventoryBox;

		private readonly InventoryOpenTutorialSettings settings;

		[Inject]
		public InventoryOpenTutorialHandler(DisassembleStateMachine disassembleStateMachine, DeviceService deviceService, InventoryPanel inventoryPanel, InventoryBox inventoryBox, InventoryOpenTutorial tutorial)
			: base(tutorial)
		{
			this.disassembleStateMachine = disassembleStateMachine;
			this.deviceService = deviceService;
			this.inventoryPanel = inventoryPanel;
			this.inventoryBox = inventoryBox;
			settings = tutorial.Settings;
		}

		public override void Init()
		{
			disassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
			inventoryPanel.OnIsVisibleChanged += ResolveInventoryPanelVisibilityChanged;
		}

		public override void Cleanup()
		{
			disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
			inventoryPanel.OnIsVisibleChanged -= ResolveInventoryPanelVisibilityChanged;
			HideTooltip();
		}

		private void ResolveDisassembleStateChanged()
		{
			if (!base.IsCompleted && (bool)deviceService.PlacedDeviceContainer && !(deviceService.PlacedDeviceContainer.Device.Info != settings.TargetDeviceInfo) && !inventoryPanel.IsVisible)
			{
				IExitableState activeState = disassembleStateMachine.ActiveState;
				if (activeState is DisabledDisassembleState || activeState is TransitionToCleaningDisassembleState || activeState is CleaningDisassembleState || activeState is TransitionFromCleaningDisassembleState || activeState is CheckDeviceDisassembleState)
				{
					HideTooltip();
				}
				else
				{
					ShowTooltip();
				}
			}
		}

		private void ResolveInventoryPanelVisibilityChanged()
		{
			if (!base.IsCompleted && (bool)deviceService.PlacedDeviceContainer && !(deviceService.PlacedDeviceContainer.Device.Info != settings.TargetDeviceInfo) && !(disassembleStateMachine.ActiveState is DisabledDisassembleState))
			{
				if (!inventoryPanel.IsVisible)
				{
					ShowTooltip();
					return;
				}
				HideTooltip();
				Complete();
			}
		}

		private void ShowTooltip()
		{
			inventoryBox.ToggleIndicator(isActive: true);
		}

		private void HideTooltip()
		{
			inventoryBox.ToggleIndicator(isActive: false);
		}

		private void Complete()
		{
			if (!base.IsCompleted)
			{
				CompleteTutorial();
			}
		}
	}
}
