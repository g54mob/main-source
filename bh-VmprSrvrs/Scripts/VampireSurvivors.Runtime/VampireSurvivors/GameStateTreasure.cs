using VampireSurvivors.Signals;

namespace VampireSurvivors
{
	public class GameStateTreasure : GameStateMachineState
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

		private void ReturnToGame(GameplaySignals.OpenTreasureCompletedSignal sig)
		{
		}

		private void ForceReturnToGame()
		{
		}
	}
}
