using System;
using Restory.Data.Equipment;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.PlayerInput;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Rewired;
using Zenject;

namespace Restory.Gameplay.Disassemble.StateMachine
{
	public class InstallingDisassembleState : IPayloadedState<ElementBase>, IExitableState, IDisposable, IUpdatableState
	{
		public class Factory : PlaceholderFactory<InstallingDisassembleState>
		{
		}

		private readonly IPlayerInput playerInput;

		private readonly DeviceService deviceService;

		private readonly UnscrewingToolSelectionService unscrewingToolSelectionService;

		private readonly DisassembleRotationController rotationController;

		private readonly DisassembleStateMachine stateMachine;

		private UnscrewingToolInfo unscrewingToolInfo;

		private ElementBase selectedElement;

		[Inject]
		public InstallingDisassembleState(IPlayerInput playerInput, DeviceService deviceService, UnscrewingToolSelectionService unscrewingToolSelectionService, DisassembleRotationController rotationController, DisassembleStateMachine stateMachine)
		{
			this.playerInput = playerInput;
			this.deviceService = deviceService;
			this.unscrewingToolSelectionService = unscrewingToolSelectionService;
			this.rotationController = rotationController;
			this.stateMachine = stateMachine;
		}

		public void Enter(ElementBase selectedElement)
		{
			SubscribeInputEvents();
			unscrewingToolInfo = unscrewingToolSelectionService.CurrentlySelectedTool;
			if (!playerInput.GetButton(71) || !selectedElement || !selectedElement.CanInteraction(unscrewingToolInfo))
			{
				stateMachine.Enter<DetectionDisassembleState>();
			}
			else
			{
				InstallElement(selectedElement);
			}
		}

		public void OnUpdate(float deltaTime)
		{
			rotationController.OnUpdate();
		}

		public void Exit()
		{
			unscrewingToolInfo = null;
			ResetSelectedElement();
			UnsubscribeInputEvents();
		}

		public void Dispose()
		{
		}

		private void SubscribeInputEvents()
		{
			playerInput.AddInputEventDelegate(ResolveButtonJustReleased, InputActionEventType.ButtonJustReleased, 71);
		}

		private void UnsubscribeInputEvents()
		{
			playerInput?.RemoveInputEventDelegate(ResolveButtonJustReleased, InputActionEventType.ButtonJustReleased, 71);
		}

		private void InstallElement(ElementBase selectedElement)
		{
			this.selectedElement = selectedElement;
			this.selectedElement.IsSelected = true;
			this.selectedElement.OnInstalled.AddListener(ResolveElementInstalled);
			this.selectedElement.InitInteraction(unscrewingToolInfo);
		}

		private void ResolveButtonJustReleased(InputActionEventData eventData)
		{
			if ((bool)selectedElement && selectedElement.IsInstalling)
			{
				selectedElement.CancelInteraction();
				if (selectedElement is ThreadedElement)
				{
					deviceService.PlacedDeviceContainer.Device.ThrowLooseElements();
				}
			}
			ResolveElementInstalled();
		}

		private void ResetSelectedElement()
		{
			if ((bool)selectedElement)
			{
				selectedElement.OnInstalled.RemoveListener(ResolveElementInstalled);
				selectedElement = null;
			}
		}

		private void ResolveElementInstalled()
		{
			if (deviceService.PlacedDeviceContainer.Device.CheckIntegrityAndIsInstalling())
			{
				stateMachine.Enter<CheckDeviceDisassembleState>();
			}
			else
			{
				stateMachine.Enter<DetectionDisassembleState>();
			}
		}
	}
}
