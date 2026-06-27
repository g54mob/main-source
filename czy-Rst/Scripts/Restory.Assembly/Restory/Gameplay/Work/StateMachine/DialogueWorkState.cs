using System;
using Restory.Gameplay.Common;
using Restory.Gameplay.GameCursor;
using Restory.Gameplay.GameView;
using Restory.Gameplay.OverlayActivators;
using Restory.Gameplay.PlayerInput;
using Restory.Gameplay.TimeSystems;
using Restory.Gameplay.Tooltips;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UserInterface.Dialogue;
using Restory.UserInterface.GameplayOverlay;
using Zenject;

namespace Restory.Gameplay.Work.StateMachine
{
	public class DialogueWorkState : IState, IExitableState, IDisposable, IUpdatableState, IActiveStateSwitchRequester
	{
		public class Factory : PlaceholderFactory<DialogueWorkState>
		{
		}

		private readonly TimeSystem timeSystem;

		private readonly CameraDirectionSwitcher cameraDirectionSwitcher;

		private readonly WindowActivatorsController windowActivatorsController;

		private readonly TooltipIndicatorsService tooltipIndicatorsService;

		private readonly GUI_TooltipsLayerCanvas tooltipsLayerCanvas;

		private readonly CursorSelectionService cursorSelectionService;

		private readonly CursorDetectorService cursorDetectorService;

		private readonly IPlayerInput playerInput;

		public DialogueWorkState(TimeSystem timeSystem, CameraDirectionSwitcher cameraDirectionSwitcher, WindowActivatorsController windowActivatorsController, TooltipIndicatorsService tooltipIndicatorsService, GUI_TooltipsLayerCanvas tooltipsLayerCanvas, CursorDetectorService cursorDetectorService, CursorSelectionService cursorSelectionService, IPlayerInput playerInput)
		{
			this.playerInput = playerInput;
			this.timeSystem = timeSystem;
			this.cameraDirectionSwitcher = cameraDirectionSwitcher;
			this.windowActivatorsController = windowActivatorsController;
			this.tooltipIndicatorsService = tooltipIndicatorsService;
			this.tooltipsLayerCanvas = tooltipsLayerCanvas;
			this.cursorDetectorService = cursorDetectorService;
			this.cursorSelectionService = cursorSelectionService;
		}

		public void Enter()
		{
			timeSystem.BlockTimeSystem(this);
			cameraDirectionSwitcher.AddBlocker(this);
			windowActivatorsController.ChangeActivatorsBlockingState(isBlocked: true);
			tooltipIndicatorsService.BlockAllIndicators(this);
			tooltipsLayerCanvas.SwitchLayerActiveState(shouldBeActive: false);
		}

		public void Exit()
		{
			timeSystem.StopBlockingTimeSystem(this);
			cameraDirectionSwitcher.RemoveBlocker(this);
			windowActivatorsController.ChangeActivatorsBlockingState(isBlocked: false);
			tooltipIndicatorsService.UnBlockAllIndicators(this);
			tooltipsLayerCanvas.SwitchLayerActiveState(shouldBeActive: true);
			cursorSelectionService.ClearDetection();
		}

		public void OnUpdate(float deltaTime)
		{
			if (cursorDetectorService.UIDetector.TryToDetect(playerInput.GetMousePosition(), out var hitObject) && hitObject.TryGetComponent<GUI_RestoryDialogueResponseButton>(out var _))
			{
				cursorSelectionService.SetDetection(hitObject);
			}
			else
			{
				cursorSelectionService.ClearDetection();
			}
		}

		public void Dispose()
		{
		}
	}
}
