using System.Collections.Generic;
using FullSerializer;

public class GameDataContainer
{
	public int townLevel;

	public string townName;

	public static GameDataContainer GetContainerFromSaveFile(fsData data)
	{
		if (data.TryAsDictionary(out var result) && result.TryGetValue("Towns", out var value) && value.TryAsList(out var result2))
		{
			using List<fsData>.Enumerator enumerator = result2.GetEnumerator();
			if (enumerator.MoveNext())
			{
				return GetContainerFromTownData(enumerator.Current);
			}
		}
		return new GameDataContainer();
	}

	public static GameDataContainer GetContainerFromTownData(fsData townData)
	{
		GameDataContainer gameDataContainer = new GameDataContainer();
		if (townData.TryAsDictionary(out var result))
		{
			if (result.TryGetValue("Stats", out var value))
			{
				gameDataContainer.LoadStatsFromData(value);
			}
			if (result.TryGetValue("name", out var value2) && value2.TryAsString(out var s))
			{
				gameDataContainer.townName = s;
			}
		}
		return gameDataContainer;
	}

	private void LoadStatsFromData(fsData data)
	{
		if (data.TryAsDictionary(out var result))
		{
			SaveFile.TryLoadInt(result, "TownLevel", ref townLevel);
		}
	}
}
