using System;
using Restory.Data.Elements;
using Restory.Data.Equipment;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.PlayerInput;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Rewired;
using Zenject;

namespace Restory.Gameplay.Disassemble.StateMachine
{
	public class DismantleDisassembleState : IPayloadedState<ElementBase>, IExitableState, IDisposable, IUpdatableState
	{
		public class Factory : PlaceholderFactory<DismantleDisassembleState>
		{
		}

		private readonly IPlayerInput playerInput;

		private readonly SmallElementBin smallElementBin;

		private readonly UnscrewingToolSelectionService unscrewingToolSelectionService;

		private readonly DisassembleRotationController rotationController;

		private readonly DisassembleStateMachine stateMachine;

		private UnscrewingToolInfo unscrewingToolInfo;

		private ElementBase selectedElement;

		[Inject]
		public DismantleDisassembleState(IPlayerInput playerInput, SmallElementBin smallElementBin, UnscrewingToolSelectionService unscrewingToolSelectionService, DisassembleRotationController rotationController, DisassembleStateMachine stateMachine)
		{
			this.playerInput = playerInput;
			this.smallElementBin = smallElementBin;
			this.unscrewingToolSelectionService = unscrewingToolSelectionService;
			this.rotationController = rotationController;
			this.stateMachine = stateMachine;
		}

		public void Enter(ElementBase selectedElement)
		{
			unscrewingToolInfo = unscrewingToolSelectionService.CurrentlySelectedTool;
			if (!playerInput.GetButton(71) || !selectedElement || !selectedElement.CanInteraction(unscrewingToolInfo))
			{
				stateMachine.Enter<DetectionDisassembleState>();
				return;
			}
			SubscribeInputEvents();
			DismantleElement(selectedElement);
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

		private void DismantleElement(ElementBase selectedElement)
		{
			this.selectedElement = selectedElement;
			this.selectedElement.IsSelected = true;
			this.selectedElement.OnDetached.AddListener(ResolveElementDetached);
			this.selectedElement.OnInteractionCanceled.AddListener(ResolveElementInteractionCanceled);
			this.selectedElement.InitInteraction(unscrewingToolInfo);
		}

		private void ResolveButtonJustReleased(InputActionEventData eventData)
		{
			if ((bool)selectedElement)
			{
				if (selectedElement is ThreadedElement threadedElement)
				{
					threadedElement.HoldElementProgress = 0f;
				}
				selectedElement.CancelInteraction();
			}
		}

		private void ResolveElementDetached()
		{
			ElementBase elementBase = selectedElement;
			if (elementBase is InsertableElement || elementBase is ThreadedElement)
			{
				selectedElement.IsSelected = false;
				if ((bool)selectedElement.Info && selectedElement.Info.Category == ElementCategory.Small)
				{
					smallElementBin.PutElement(selectedElement);
					stateMachine.Enter<DetectionDisassembleState>();
				}
				else
				{
					stateMachine.Enter<DraggingDisassembleState, ElementBase>(selectedElement);
				}
			}
			else
			{
				stateMachine.Enter<DetectionDisassembleState>();
			}
		}

		private void ResolveElementInteractionCanceled()
		{
			if ((bool)selectedElement)
			{
				selectedElement.IsSelected = false;
			}
			stateMachine.Enter<DetectionDisassembleState>();
		}

		private void ResetSelectedElement()
		{
			if ((bool)selectedElement)
			{
				selectedElement.OnDetached.RemoveListener(ResolveElementDetached);
				selectedElement.OnInteractionCanceled.RemoveListener(ResolveElementInteractionCanceled);
				selectedElement = null;
			}
		}
	}
}
