public class ShipsLogsWindow
{
	public void LoadShipsLogsForCurrentDungeon(Room revealedRoom, RevealedRoomType revealedRoomType, string infestationCount)
	{
		string rawText = LoadActualLogText(revealedRoom, revealedRoomType, infestationCount);
		LogUI.Instance.ShowWindow(">\n> Unknown derelict: Accessing records", rawText, GlobalSettings.Constants.LOG_DEFAULT_COLOR, 1);
	}

	private string LoadActualLogText(Room revealedRoom, RevealedRoomType revealedRoomType, string infestationCount)
	{
		string text = string.Empty;
		if (GlobalSettings.gameMode == GameModeEnum.Normal)
		{
			bool isCorrupted = false;
			if (ObjectiveManual.IsObjectiveActive("pandemic") && (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost || GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Derelict))
			{
				if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.StartsWith("Medical"))
				{
					text = LogManager.GetNextMedicalLog(revealedRoom, revealedRoomType, infestationCount, out isCorrupted);
				}
				else if (ObjectiveManual.IsObjectiveStepActive("pandemic", "stepD") && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name == "Private")
				{
					text = LogManager.GetNextMedicalLog(revealedRoom, revealedRoomType, infestationCount, out isCorrupted);
				}
			}
			if (!isCorrupted && ObjectiveManual.IsObjectiveActive("greygoo") && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Station && (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.StartsWith("Space") || GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.StartsWith("Fuel")))
			{
				text = LogManager.GetNextGreyGooLog(revealedRoom, revealedRoomType, infestationCount, out isCorrupted);
			}
			if (!isCorrupted && ObjectiveManual.IsObjectiveActive("cosmic"))
			{
				if (ObjectiveManual.IsObjectiveStepActive("cosmic", "stepA"))
				{
					text = LogManager.GetNextMilitaryLog(revealedRoom, revealedRoomType, infestationCount, out isCorrupted);
				}
				else if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.StartsWith("Research"))
				{
					text = LogManager.GetNextCosmicEventLog(revealedRoom, revealedRoomType, infestationCount, out isCorrupted);
				}
			}
			if (!isCorrupted && ObjectiveManual.IsObjectiveActive("singularity") && (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost || GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Derelict) && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.StartsWith("MUTEKI"))
			{
				text = LogManager.GetNextSingularityLog(revealedRoom, revealedRoomType, infestationCount, out isCorrupted);
			}
			if ((isCorrupted || string.IsNullOrEmpty(text)) && (ObjectiveManual.IsObjectiveActive("cosmic") || ObjectiveManual.IsObjectiveActive("superpredator")) && (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost || GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Derelict) && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.StartsWith("Military"))
			{
				text = LogManager.GetNextMilitaryLog(revealedRoom, revealedRoomType, infestationCount, out isCorrupted);
			}
			if (string.IsNullOrEmpty(text))
			{
				text = LogManager.GetNextShipLog(revealedRoom, revealedRoomType, infestationCount);
			}
		}
		else
		{
			text = LogManager.GetCorruptedLog(revealedRoom, revealedRoomType, infestationCount);
		}
		return text;
	}
}
