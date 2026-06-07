using VampireSurvivors.Signals;

namespace VampireSurvivors
{
	public class GameStateInitializing : GameStateMachineState
	{
		public override void OnEnter()
		{
		}

		public override void OnExit()
		{
		}

		private void OnConnectionError(GameplaySignals.ConnectionErrorSignal signal)
		{
		}

		private void OnGameSessionInitialized()
		{
		}
	}
}
