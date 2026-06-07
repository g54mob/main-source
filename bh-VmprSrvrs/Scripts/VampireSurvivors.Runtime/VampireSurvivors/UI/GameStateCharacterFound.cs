using VampireSurvivors.Signals;

namespace VampireSurvivors.UI
{
	public class GameStateCharacterFound : GameStateMachineState
	{
		public override void OnEnter()
		{
		}

		public override void OnExit()
		{
		}

		private void CharacterCollected(UISignals.CharacterCollectedSignal sig)
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
