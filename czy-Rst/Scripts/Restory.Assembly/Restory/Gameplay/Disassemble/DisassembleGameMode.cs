using System;
using Restory.Constants;
using Restory.Data.Identifications;
using Restory.EventSystems.ExitEvents;
using Restory.Gameplay.Competitions;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.GameView;
using Restory.Gameplay.UserInterface;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UI.Presenters.DevicePaintingTool;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Disassemble
{
	public sealed class DisassembleGameMode : MonoBehaviour, IInitializable, IDisposable, IExitEventHandler
	{
		private bool isActive;

		[SerializeField]
		private UniqueIdentificator identificator;

		private DisassembleStateMachine disassembleStateMachine;

		private GameViewController gameViewController;

		private DeviceService deviceService;

		private GUI_DisassembleObjectGameModeCanvas disassembleCanvas;

		private GUI_DevicePainterPanel devicePainterPanel;

		private DisassembleRotationController rotationController;

		private PlacedElementsHandler placedElementsHandler;

		private NotepadInteractiveWorkplaceItem notepadWorkplaceItem;

		private ExitEventDispatcher exitEventDispatcher;

		private CompetitionGameMode competitionMode;

		private bool isTransitioningFromPaintingState;

		private bool startFromPaintingMode;

		public string ID => identificator.ID;

		public bool IsInCompetition => competitionMode.HasDeviceInCompetition;

		[Inject]
		private void Construct(DisassembleStateMachine disassembleStateMachine, GameViewController gameViewController, DeviceService deviceService, GUI_DisassembleObjectGameModeCanvas disassembleCanvas, GUI_DevicePainterPanel devicePainterPanel, DisassembleRotationController rotationController, PlacedElementsHandler placedElementsHandler, NotepadInteractiveWorkplaceItem notepadWorkplaceItem, ExitEventDispatcher exitEventDispatcher, CompetitionGameMode competitionMode)
		{
			this.competitionMode = competitionMode;
			this.disassembleStateMachine = disassembleStateMachine;
			this.gameViewController = gameViewController;
			this.deviceService = deviceService;
			this.disassembleCanvas = disassembleCanvas;
			this.devicePainterPanel = devicePainterPanel;
			this.rotationController = rotationController;
			this.placedElementsHandler = placedElementsHandler;
			this.notepadWorkplaceItem = notepadWorkplaceItem;
			this.exitEventDispatcher = exitEventDispatcher;
		}

		public void Initialize()
		{
			disassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
			disassembleCanvas.OnExitAction += ResolveExitAction;
			devicePainterPanel.OnExitRequested += ResolveExitAction;
			gameViewController.OnViewPresetSwitchingProcessStarted += ResolveGameViewTransitionStarted;
			gameViewController.OnViewPresetSwitchingProcessComplete += ResolveGameViewTransitionComplete;
		}

		public void Dispose()
		{
			disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
			disassembleCanvas.OnExitAction -= ResolveExitAction;
			devicePainterPanel.OnExitRequested -= ResolveExitAction;
			gameViewController.OnViewPresetSwitchingProcessComplete -= ResolveGameViewTransitionStarted;
			gameViewController.OnViewPresetSwitchingProcessComplete -= ResolveGameViewTransitionComplete;
		}

		public void ExecuteExit()
		{
			ResolveExitAction();
		}

		public void ConfirmExitExecution()
		{
			if (isActive && !(disassembleStateMachine.ActiveState is TransitionFromCleaningDisassembleState))
			{
				if (isTransitioningFromPaintingState)
				{
					isTransitioningFromPaintingState = false;
					return;
				}
				Debug.LogError("DisassembleGameMode still active");
				ResolveExitAction();
			}
		}

		public bool TryCreateEmptyDevice(string deviceNameKey)
		{
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (!(activeState is EmptyDisassembleState) && !(activeState is DraggingDisassembleState))
			{
				Debug.LogError("Failed to create empty device: " + deviceNameKey + "," + $" active state is {disassembleStateMachine.ActiveState.GetType()}");
				return false;
			}
			if ((bool)deviceService.PlacedDeviceContainer)
			{
				Debug.LogError("Failed to create empty device: " + deviceNameKey + ", another device " + deviceService.PlacedDeviceContainer.Device.Info.ID + " placed already");
				return false;
			}
			DeviceContainer deviceContainer = deviceService.CreateEmptyDeviceContainer(deviceNameKey);
			deviceContainer.Activate();
			disassembleCanvas.SetDevice(deviceContainer);
			rotationController.TargetTransform = deviceContainer.DisassemblePoint;
			return true;
		}

		public void PrepareEnteringStraightToPaintingMode()
		{
			startFromPaintingMode = true;
		}

		private void ResolveDisassembleStateChanged()
		{
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (activeState is DetectionDisassembleState || activeState is EmptyDisassembleState || activeState is CleaningDisassembleState || activeState is PaintingDisassembleState)
			{
				exitEventDispatcher.Register(this);
			}
			else
			{
				exitEventDispatcher.Unregister(this);
			}
		}

		private void ResolveExitAction()
		{
			startFromPaintingMode = false;
			if (!isActive)
			{
				disassembleCanvas.Hide();
				return;
			}
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (activeState is TransitionToCleaningDisassembleState || activeState is TransitionFromCleaningDisassembleState)
			{
				return;
			}
			if (!(activeState is CleaningDisassembleState cleaningDisassembleState))
			{
				if (activeState is PaintingDisassembleState paintingDisassembleState)
				{
					paintingDisassembleState.Stop();
					isTransitioningFromPaintingState = true;
					return;
				}
				disassembleCanvas.Hide();
				Deactivate();
				if (!notepadWorkplaceItem.IsActive)
				{
					notepadWorkplaceItem.gameObject.layer = ProjectConstants.Layers.Equipment;
				}
			}
			else
			{
				cleaningDisassembleState.Stop();
			}
		}

		private void ResolveGameViewTransitionStarted()
		{
			if (!(disassembleStateMachine.ActiveState is DisabledDisassembleState) && !gameViewController.IsCurrentViewPresetDisassemblePreset)
			{
				disassembleStateMachine.Enter<DisabledDisassembleState>();
			}
		}

		private void ResolveGameViewTransitionComplete()
		{
			if (disassembleStateMachine.ActiveState is DisabledDisassembleState && gameViewController.IsCurrentViewPresetDisassemblePreset)
			{
				Activate();
			}
		}

		private void Activate()
		{
			if (isActive)
			{
				return;
			}
			isActive = true;
			if (!placedElementsHandler.ValidatePlacedElementsPosition())
			{
				placedElementsHandler.ResolveElementsInvalidPosition();
			}
			disassembleCanvas.Show();
			DeviceContainer placedDeviceContainer = deviceService.PlacedDeviceContainer;
			if ((bool)placedDeviceContainer)
			{
				PrepareDeviceForDisassembleMode(placedDeviceContainer);
				if (startFromPaintingMode)
				{
					startFromPaintingMode = false;
					EnterPaintingState();
				}
				else
				{
					EnterDetectionState();
					competitionMode.TryStartCompetition();
				}
				disassembleCanvas.SetDevice(placedDeviceContainer);
			}
			else
			{
				EnterEmptyState();
			}
			if (!notepadWorkplaceItem.IsActive)
			{
				notepadWorkplaceItem.gameObject.layer = ProjectConstants.Layers.Obstacles;
			}
		}

		private void Deactivate()
		{
			if (isActive)
			{
				isActive = false;
				if (!placedElementsHandler.ValidatePlacedElementsPosition())
				{
					placedElementsHandler.ResolveElementsInvalidPosition();
				}
				rotationController.TargetTransform = null;
				DeviceContainer placedDeviceContainer = deviceService.PlacedDeviceContainer;
				if ((bool)placedDeviceContainer)
				{
					placedDeviceContainer.Device.ThrowLooseElements();
					placedDeviceContainer.Device.ResetElements();
					placedDeviceContainer.QuitDisassemblyMode();
				}
				competitionMode.StopCompetition();
				disassembleStateMachine.ExitToDefaultState();
				gameViewController.ApplyDefaultViewPreset();
			}
		}

		private void EnterDetectionState()
		{
			disassembleStateMachine.Enter<DetectionDisassembleState>();
		}

		private void EnterPaintingState()
		{
			disassembleStateMachine.Enter<PaintingDisassembleState>();
		}

		private void EnterEmptyState()
		{
			disassembleStateMachine.Enter<EmptyDisassembleState>();
		}

		private void PrepareDeviceForDisassembleMode(DeviceContainer deviceContainer)
		{
			deviceContainer.Device.InitElements();
			rotationController.TargetTransform = deviceContainer.DisassemblePoint;
		}
	}
}
