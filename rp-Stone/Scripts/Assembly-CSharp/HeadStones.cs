using System.Collections.Generic;

public class HeadStones
{
	private static Dictionary<string, List<IntPosition>> headLocations = new Dictionary<string, List<IntPosition>>();

	private static List<IntPosition> emptyList = new List<IntPosition>();

	public static void AddAt(string questId, int difficulty, int positionX, int positionZ)
	{
		string key = CreateKey(questId, difficulty);
		IntPosition intPosition = new IntPosition();
		intPosition.x = positionX;
		intPosition.z = positionZ;
		if (headLocations.ContainsKey(key))
		{
			headLocations[key].Add(intPosition);
			return;
		}
		List<IntPosition> list = new List<IntPosition>();
		list.Add(intPosition);
		headLocations.Add(key, list);
	}

	public static void RemoveAt(string questId, int difficulty, int positionX, int positionY)
	{
		string key = CreateKey(questId, difficulty);
		if (!headLocations.ContainsKey(key))
		{
			return;
		}
		List<IntPosition> list = headLocations[key];
		if (list.Count == 0)
		{
			return;
		}
		int index = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].x == positionX && list[i].y == positionY)
			{
				index = i;
				break;
			}
		}
		list.RemoveAt(index);
	}

	public static List<IntPosition> GetStonesForQuest(string questId, int difficulty)
	{
		string key = CreateKey(questId, difficulty);
		if (headLocations.ContainsKey(key))
		{
			return headLocations[key];
		}
		return emptyList;
	}

	private static string CreateKey(string questId, int difficulty)
	{
		return questId + difficulty;
	}
}
