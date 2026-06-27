using Restory.Gameplay.PlayerInput;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States;
using Zenject;

namespace Restory.Gameplay.GameCursor
{
	public sealed class PauseCursorController : ITickable
	{
		private GlobalStateMachine globalStateMachine;

		private CursorDetectorService cursorDetectorService;

		private CursorSelectionService cursorSelectionService;

		private IPlayerInput playerInput;

		[Inject]
		private void Construct(GlobalStateMachine globalStateMachine, CursorDetectorService cursorDetectorService, CursorSelectionService cursorSelectionService, IPlayerInput playerInput)
		{
			this.globalStateMachine = globalStateMachine;
			this.cursorDetectorService = cursorDetectorService;
			this.cursorSelectionService = cursorSelectionService;
			this.playerInput = playerInput;
		}

		public void Tick()
		{
			if (globalStateMachine.ActiveState is GamePauseState)
			{
				if (cursorDetectorService.UIDetector.TryToDetect(playerInput.GetMousePosition(), out var hitObject))
				{
					cursorSelectionService.SetDetection(hitObject, uiObjectDetected: true);
				}
				else
				{
					cursorSelectionService.ClearDetection();
				}
			}
		}
	}
}
