using Dorfromantik.UI.MainMenu;
using UnityEngine;

namespace Dorfromantik
{
	public class ConfirmationScreenSaveGameDisplay : MonoBehaviour
	{
		[SerializeField]
		private SaveGameUi saveGameUi;

		[SerializeField]
		private SaveGameTarget saveGameTarget = SaveGameTarget.AutoSaveInSelectedGameMode;

		[SerializeField]
		private SaveGameLoadingInitiator saveGameLoadingInitiator;

		[SerializeField]
		private SaveFileManager saveFileManager;

		private SaveGameData_003 targetSaveGame;

		private void OnEnable()
		{
			switch (saveGameTarget)
			{
			case SaveGameTarget.AutoSaveInSelectedGameMode:
				targetSaveGame = saveFileManager.autoSaveGames[saveGameLoadingInitiator.SelectedGameMode];
				break;
			case SaveGameTarget.SelectedSaveGame:
				targetSaveGame = saveGameLoadingInitiator.SelectedSaveGame;
				break;
			case SaveGameTarget.SelectedSaveGameToOverwrite:
				targetSaveGame = saveGameLoadingInitiator.SelectedSaveGameToOverwrite;
				break;
			}
			if (targetSaveGame != null)
			{
				saveGameUi.Setup(null, targetSaveGame, isAutosaveContainer: false, setupScreenshot: true);
			}
		}
	}
}
