public static class LevelFactory
{
	public static Level CreateLevel(LevelData data, Zone zone, int worldIndex)
	{
		ScriptedLevel scriptedLevel = data.scriptedLevel;
		string text = scriptedLevel?.tooltipKey?.GetLocalizedString() ?? string.Empty;
		string text2 = scriptedLevel?.nameKey?.GetLocalizedString() ?? data.name;
		return new Level(zone, text2, data.index, data.position, data.connectivity, data.levelType, data.lootType, data.column, data.difficulty, data.savedModifiers, text, trackTypesOverride: scriptedLevel?.trackTypesOverride, trackCountOverride: scriptedLevel?.trackCountOverride ?? ((zone.Definition.ZoneName == "T0_Tutorial") ? 12 : (-1)))
		{
			ScriptedLevel = scriptedLevel,
			SourceData = data,
			WorldIndex = worldIndex
		};
	}

	public static Level CreateLevel(LevelSaveData savedLevel, Zone zone)
	{
		return new Level(zone, savedLevel.Name, savedLevel.Index, savedLevel.MapPosition, savedLevel.Connectivity, savedLevel.LevelType, savedLevel.LootType, savedLevel.Column, savedLevel.Difficulty, tooltipStringOverride: savedLevel.TooltipString, trackCountOverride: savedLevel.TrackCountOverride, trackTypesOverride: savedLevel.TrackTypesOverride, savedModifiers: savedLevel.SavedModifiers)
		{
			WorldIndex = savedLevel.WorldIndex
		};
	}
}
