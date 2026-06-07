namespace ModApi.Flight
{
	public enum FlightSceneExitReason
	{
		Unknown = 0,
		SaveAndExit = 1,
		SaveAndRecover = 2,
		SaveAndDestroy = 3,
		UndoAndExit = 4,
		Retry = 5,
		Relaunch = 6,
		CraftNodeChanged = 7,
		QuickLoad = 8,
		ExitLevel = 9,
		LoadScenario = 10
	}
}
