using System;
using DG.Tweening;
using Restory.Data.Disassemble.StateMachine;
using Restory.Data.Elements.Condition;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.TextureMasks;
using Restory.Gameplay.UserInterface;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Disassemble.StateMachine
{
	public class TransitionFromCleaningDisassembleState : IPayloadedState<ElementBase>, IExitableState, IDisposable
	{
		public class Factory : PlaceholderFactory<TransitionFromCleaningDisassembleState>
		{
		}

		private readonly TweenSequencesService tweenSequences;

		private readonly DeviceService deviceService;

		private readonly ElementService elementService;

		private readonly GUI_ElementCleanerPanel cleanerPanel;

		private readonly TextureSaveLoadService textureSaveLoadService;

		private readonly TextureCacheService textureCacheService;

		private readonly ElementPlacementController elementPlacementController;

		private readonly CleanedElementDestinationHandler destinationHandler;

		private readonly DisassembleStateMachine stateMachine;

		private readonly TransitionFromCleaningConfig config;

		private ElementBase selectedElement;

		private PlacementPositionHandler placementHandler;

		private Sequence transitionSequence;

		private Vector3 targetPosition;

		[Inject]
		public TransitionFromCleaningDisassembleState(TweenSequencesService tweenSequences, DeviceService deviceService, ElementService elementService, GUI_ElementCleanerPanel cleanerPanel, TextureSaveLoadService textureSaveLoadService, TextureCacheService textureCacheService, ElementPlacementController elementPlacementController, CleanedElementDestinationHandler destinationHandler, DisassembleStateMachine stateMachine, TransitionFromCleaningConfig config)
		{
			this.tweenSequences = tweenSequences;
			this.deviceService = deviceService;
			this.elementService = elementService;
			this.cleanerPanel = cleanerPanel;
			this.textureSaveLoadService = textureSaveLoadService;
			this.textureCacheService = textureCacheService;
			this.elementPlacementController = elementPlacementController;
			this.destinationHandler = destinationHandler;
			this.stateMachine = stateMachine;
			this.config = config;
		}

		public void Enter(ElementBase selectedElement)
		{
			cleanerPanel.Hide();
			this.selectedElement = selectedElement;
			placementHandler = selectedElement.PlacementPositionHandler;
			targetPosition = destinationHandler.GetCleanedElementDestinationPosition(selectedElement);
			TransferElementToPlacementPosition();
			HandleElementConditionChanges();
			deviceService.PlacedDeviceContainer.TransferDeviceToDisassemblePoint();
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

		private void TransferElementToPlacementPosition()
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(selectedElement.transform.DOMove(targetPosition, config.TransitionDuration)).Join(selectedElement.transform.DORotateQuaternion(placementHandler.PlacementPositionData.PlacementRotation, config.TransitionDuration)).SetEase(config.TransitionEase)
				.OnComplete(OnTransferComplete);
		}

		private void HandleElementConditionChanges()
		{
			ElementConditionHandler conditionHandler = selectedElement.ConditionHandler;
			if (conditionHandler.ElementData.Condition is PerfectElementCondition)
			{
				textureCacheService.RemoveTextureData(conditionHandler.ElementData.DirtMaskTextureId);
				conditionHandler.ElementData.DirtMaskTextureId = 0;
				return;
			}
			Texture2D workTexture = conditionHandler.TextureMaskHolder.WorkTexture;
			byte[] textureData = textureSaveLoadService.ConvertTextureToData(workTexture);
			textureCacheService.CacheTextureData(conditionHandler.ElementData, textureData);
			conditionHandler.CaptureCleaningData();
		}

		private void OnTransferComplete()
		{
			elementPlacementController.SetTargetElement(selectedElement, targetPosition);
			if (!elementPlacementController.TrySetPlacementPositionAndDropToSurface())
			{
				elementService.TrySendItemToStorage(selectedElement);
			}
			stateMachine.Enter<DetectionDisassembleState>();
		}
	}
}
