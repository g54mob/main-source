using Rewired;
using VampireSurvivors.Signals;

namespace VampireSurvivors
{
	public class GameStatePaused : GameStateMachineState
	{
		private bool _enteredThisFrame;

		public override void OnEnter()
		{
		}

		public override void OnExit()
		{
		}

		public void Update()
		{
		}

		private bool IsButtonPressed(Player pausingPlayer)
		{
			return false;
		}

		private void OnConnectionError(GameplaySignals.ConnectionErrorSignal signal)
		{
		}

		private void ReturnToGame()
		{
		}

		public void QuitGame()
		{
		}

		private void PlayerDied(GameplaySignals.CharacterDiedSignal sig)
		{
		}

		private void LevelUp()
		{
		}

		private void UnfreezePlayer()
		{
		}

		private void ShowLevelBonus()
		{
		}

		private void FoundNewItem()
		{
		}

		private void FoundNewCharacter()
		{
		}

		private void OpenPiano()
		{
		}

		private void ShowInitialArcanaSelection()
		{
		}

		private void ShowSurvarotsSelection()
		{
		}

		private void ShowMerchant()
		{
		}

		private void ShowWeaponSelection()
		{
		}

		private void ShowHealer()
		{
		}

		private void ShowDirector()
		{
		}

		private static void FadeAudioDown(float volume = 0.2f)
		{
		}

		private void OpenTPWeaponSelection()
		{
		}

		private void OpenTreasure()
		{
		}

		private void ShowGameoverino()
		{
		}

		private void ShowFinalFireworks()
		{
		}

		private void ShowEndCredits()
		{
		}
	}
}
