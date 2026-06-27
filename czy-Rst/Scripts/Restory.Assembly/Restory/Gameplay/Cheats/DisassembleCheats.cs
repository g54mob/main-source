using System.ComponentModel;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.PlayerInput;
using Restory.Gameplay.Soldering;
using Rewired;
using UnityEngine.Scripting;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	[Preserve]
	public class DisassembleCheats : SRDebugCheatBase
	{
		private readonly DeviceService deviceService;

		private readonly ElementCleaner elementCleaner;

		private readonly SolderingService solderingService;

		private readonly DisassembleStateMachine disassembleStateMachine;

		private readonly CleaningToolSelectionService cleaningToolSelectionService;

		private readonly IPlayerInput playerInput;

		private const string COMMON_CATEGORY = "Disassemble Cheats";

		[Category("Disassemble Cheats")]
		[DisplayName("Complete Cleaning")]
		public void CompleteCleaning()
		{
			if (disassembleStateMachine.ActiveState is CleaningDisassembleState cleaningDisassembleState)
			{
				cleaningDisassembleState.ForceCleaningComplete();
			}
		}

		[Category("Disassemble Cheats")]
		[DisplayName("Force Check Device")]
		public void ForceCheckDevice()
		{
			if (disassembleStateMachine.ActiveState is DetectionDisassembleState)
			{
				disassembleStateMachine.Enter<CheckDeviceDisassembleState>();
			}
		}

		[Category("Disassemble Cheats")]
		[DisplayName("Complete Cleaning Device")]
		public void CompleteCleaningDevice()
		{
			if (!deviceService.PlacedDeviceContainer)
			{
				return;
			}
			foreach (ElementSocket elementSocket in deviceService.PlacedDeviceContainer.Device.ElementSockets)
			{
				ElementBase nestedElement = elementSocket.NestedElement;
				if ((bool)nestedElement)
				{
					if (elementCleaner.IsElementNeedsCleaning(nestedElement, out var _, out var _))
					{
						CompleteCleaning(nestedElement);
					}
					if (elementCleaner.IsElementNeedsSoldering(nestedElement, out var _, out var _))
					{
						CompleteSoldering(nestedElement);
					}
				}
			}
			deviceService.PlacedDeviceContainer.ForceCheckQuality();
			void CompleteCleaning(ElementBase selectedElement)
			{
				elementCleaner.SetCleaningTool(cleaningToolSelectionService.CurrentlySelectedTool);
				elementCleaner.SetTarget(selectedElement);
				elementCleaner.CompleteCleaning();
				elementCleaner.ResetTarget();
			}
			void CompleteSoldering(ElementBase selectedElement)
			{
				if (selectedElement.ConditionHandler.ElementData.AdditionalProperty is ScorchedCircuitProperty { IsResoldered: false })
				{
					ContactLinesHandler componentInChildren = selectedElement.GetComponentInChildren<ContactLinesHandler>();
					if ((bool)componentInChildren && componentInChildren.AllPoints.Count != 0)
					{
						solderingService.Init(componentInChildren, isElementCleaned: true);
						solderingService.ForceCompleteSoldering();
						solderingService.Clear();
					}
				}
			}
		}

		[Inject]
		public DisassembleCheats(DisassembleStateMachine disassembleStateMachine, IPlayerInput playerInput, DeviceService deviceService, ElementCleaner elementCleaner, SolderingService solderingService, CleaningToolSelectionService cleaningToolSelectionService)
		{
			this.disassembleStateMachine = disassembleStateMachine;
			this.playerInput = playerInput;
			this.deviceService = deviceService;
			this.elementCleaner = elementCleaner;
			this.solderingService = solderingService;
			this.cleaningToolSelectionService = cleaningToolSelectionService;
		}

		protected override void Init()
		{
			SubscribeToHotkeys();
		}

		protected override void CleanUp()
		{
			UnsubscribeFromHotkeys();
		}

		private void SubscribeToHotkeys()
		{
			playerInput.AddInputEventDelegate(ResolveOnInventoryItemButtonJustReleased, InputActionEventType.ButtonJustReleased, 66);
		}

		private void UnsubscribeFromHotkeys()
		{
			if (playerInput != null)
			{
				playerInput.RemoveInputEventDelegate(ResolveOnInventoryItemButtonJustReleased, InputActionEventType.ButtonJustReleased, 66);
			}
		}

		private void ResolveOnInventoryItemButtonJustReleased(InputActionEventData eventData)
		{
			CompleteCleaning();
			ForceCheckDevice();
		}
	}
}
