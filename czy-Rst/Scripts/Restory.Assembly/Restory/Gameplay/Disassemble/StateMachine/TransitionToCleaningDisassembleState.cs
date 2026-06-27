using System;
using DG.Tweening;
using Restory.Data.Disassemble.StateMachine;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Disassemble.StateMachine
{
	public class TransitionToCleaningDisassembleState : IPayloadedState<ElementBase>, IExitableState, IDisposable
	{
		public class Factory : PlaceholderFactory<TransitionToCleaningDisassembleState>
		{
		}

		private readonly DeviceService deviceService;

		private readonly TweenSequencesService tweenSequences;

		private readonly CleanedElementDestinationHandler destinationHandler;

		private readonly DisassembleStateMachine stateMachine;

		private readonly TransitionToCleaningConfig config;

		private ElementBase selectedElement;

		private PlacementPositionHandler placementHandler;

		private Vector3 cleaningPosition;

		private Sequence transitionSequence;

		[Inject]
		public TransitionToCleaningDisassembleState(DeviceService deviceService, TweenSequencesService tweenSequences, CleanedElementDestinationHandler destinationHandler, DisassembleStateMachine stateMachine, TransitionToCleaningConfig config)
		{
			this.deviceService = deviceService;
			this.tweenSequences = tweenSequences;
			this.destinationHandler = destinationHandler;
			this.stateMachine = stateMachine;
			this.config = config;
		}

		public void Enter(ElementBase selectedElement)
		{
			this.selectedElement = selectedElement;
			placementHandler = selectedElement.PlacementPositionHandler;
			destinationHandler.SetTargetElement(selectedElement);
			cleaningPosition = deviceService.PlacedDeviceContainer.DisassemblePoint.position;
			deviceService.PlacedDeviceContainer.TransferDeviceToPlacementPoint();
			TransferElementToCleaningPosition();
		}

		public void Exit()
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			transitionSequence = null;
			selectedElement = null;
			placementHandler = null;
		}

		public void Dispose()
		{
		}

		private void TransferElementToCleaningPosition()
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(selectedElement.transform.DOMove(cleaningPosition, config.TransitionDuration)).Join(selectedElement.transform.DORotateQuaternion(placementHandler.PlacementPositionData.PlacementRotation, config.TransitionDuration)).SetEase(config.TransitionEase)
				.OnComplete(OnTransferComplete);
		}

		private void OnTransferComplete()
		{
			stateMachine.Enter<CleaningDisassembleState, ElementBase>(selectedElement);
		}
	}
}
