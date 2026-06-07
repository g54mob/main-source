using VampireSurvivors.Signals;

namespace VampireSurvivors.UI
{
	public class GameStatePiano : GameStateMachineState
	{
		public override void OnEnter()
		{
		}

		public override void OnExit()
		{
		}

		private void ResumeGame(UISignals.ClosePianoSignal signal)
		{
		}

		private void ReturnToGame()
		{
		}

		private void OnConnectionError(GameplaySignals.ConnectionErrorSignal signal)
		{
		}
	}
}
