using System;
using Restory.Data.Disassemble.StateMachine;
using Restory.Gameplay.GameDialogues;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.TimeSystems;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Disassemble.StateMachine
{
	public class ElementToInventoryConfirmationDialogueDisassembleState : IPayloadedState<ElementToInventoryTransferData>, IExitableState, IDisposable, IConfirmationRequester
	{
		public class Factory : PlaceholderFactory<ElementToInventoryConfirmationDialogueDisassembleState>
		{
		}

		private DisassembleStateMachine stateMachine;

		private ConfirmationService confirmationService;

		private TimeScalingService timeScalingService;

		private ElementToInventoryConfirmationDialogueConfig settings;

		private ElementToInventoryTransferData payload;

		public ElementToInventoryConfirmationDialogueDisassembleState(DisassembleStateMachine stateMachine, ConfirmationService confirmationService, TimeScalingService timeScalingService, ElementToInventoryConfirmationDialogueConfig settings)
		{
			this.timeScalingService = timeScalingService;
			this.settings = settings;
			this.stateMachine = stateMachine;
			this.confirmationService = confirmationService;
		}

		public void Enter(ElementToInventoryTransferData payload)
		{
			this.payload = payload;
			timeScalingService.SetTimeScale(0f);
			confirmationService.RequestConfirmation(this, settings.DialogueTextLocalizationKey);
		}

		public void Exit()
		{
			payload = default(ElementToInventoryTransferData);
			timeScalingService.ResetTimeScaleToDefault();
		}

		public void OnConfirmationResponse(bool isConfirmed)
		{
			if (!payload.ElementInTransfer)
			{
				Debug.LogError("[ElementToInventoryConfirmationDialogueDisassembleState] tried to put the designated element into inventory, but the element was lost!");
			}
			else if (isConfirmed)
			{
				payload.TryToSendElementToInventory(payload.ElementInTransfer);
			}
			else
			{
				payload.CancelElementTransfer?.Invoke();
			}
			stateMachine.Enter<DetectionDisassembleState>();
		}

		public void Dispose()
		{
		}
	}
}
