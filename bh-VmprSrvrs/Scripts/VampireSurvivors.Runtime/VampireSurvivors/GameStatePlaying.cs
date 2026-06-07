using VampireSurvivors.Signals;

namespace VampireSurvivors
{
	public class GameStatePlaying : GameStateMachineState
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

		private bool ChangePlayerSpectate()
		{
			return false;
		}

		private bool IsSpectateModeActive()
		{
			return false;
		}

		private bool IsPlayerProperTarget()
		{
			return false;
		}

		private void AdvanceFreeRoamCameraTarget()
		{
		}

		private void OnConnectionError(GameplaySignals.ConnectionErrorSignal signal)
		{
		}

		private void PauseGame(GameplaySignals.GamePausedSignal signal)
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

		private void LevelUp()
		{
		}

		private void ShowLevelBonus()
		{
		}

		private void PlayerDied(GameplaySignals.CharacterDiedSignal sig)
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
	}
}
