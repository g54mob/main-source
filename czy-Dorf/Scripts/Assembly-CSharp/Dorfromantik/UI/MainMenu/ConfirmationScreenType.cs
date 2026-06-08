namespace Dorfromantik.UI.MainMenu
{
	public enum ConfirmationScreenType
	{
		None = 0,
		DiscardProgressAndStartNew = 1,
		StartNewOrContinuePrevious = 2,
		RestartTutorial = 3,
		SkipTutorial = 4,
		QuitGame = 5,
		ClearProgress = 6,
		NewGame_DifferentGameMode_DiscardOrSaveAutosave = 10,
		LoadGame_DifferentGameMode_DiscardOrSaveAutosave = 11,
		NewGame_SameGameMode_DiscardOrSaveAutosave = 12,
		TransferToCreative_DiscardOrSaveAutosave = 13,
		LoadGame_SameGameMode_DiscardOrSaveAutosave = 14,
		DeleteSaveGame = 20,
		SelectSaveFileToOverwrite = 21,
		ConfirmOverwritingSaveFile = 22,
		EstablishLeaderboardNetworkConnection = 23,
		SteamChina_AgeInfo = 24
	}
}
