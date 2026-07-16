using System.Collections.Generic;
using System.Linq;

public static class MapHelper
{
	public static List<MapLine> GetLinesFromLevels(List<Level> levels)
	{
		HashSet<int> hashSet = new HashSet<int>(levels.Select((Level n) => n.Index));
		HashSet<MapLine> hashSet2 = new HashSet<MapLine>();
		foreach (Level level in levels)
		{
			foreach (int item in level.Connectivity)
			{
				if (hashSet.Contains(item))
				{
					MapLine line = LevelManager.Instance.Map.GetLine(level.Index, item);
					hashSet2.Add(line);
				}
			}
		}
		return hashSet2.ToList();
	}

	public static List<Level> GetLevelsWithinDistance(Level startLevel, int maxDistance)
	{
		return BFS(startLevel, maxDistance).visitedLevels;
	}

	public static int GetDistanceBetweenLevels(Level startLevel, Level endLevel)
	{
		Dictionary<int, int> item = BFS(startLevel, int.MaxValue).dist;
		if (!item.ContainsKey(endLevel.Index))
		{
			return -1;
		}
		return item[endLevel.Index];
	}

	private static (Dictionary<int, int> dist, List<Level> visitedLevels) BFS(Level startLevel, int maxDistance)
	{
		HashSet<int> hashSet = new HashSet<int>();
		Queue<int> queue = new Queue<int>();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		List<Level> list = new List<Level>();
		queue.Enqueue(startLevel.Index);
		hashSet.Add(startLevel.Index);
		dictionary[startLevel.Index] = 0;
		list.Add(startLevel);
		while (queue.Count > 0)
		{
			int index = queue.Dequeue();
			Level level = LevelManager.Instance.Levels.First((Level level2) => level2.Index == index);
			foreach (int item in level.Connectivity)
			{
				if (!(LevelManager.Instance.Levels[item].MapPosition.x < level.MapPosition.x) && !hashSet.Contains(item))
				{
					hashSet.Add(item);
					queue.Enqueue(item);
					dictionary[item] = dictionary[index] + 1;
					if (dictionary[item] <= maxDistance)
					{
						list.Add(LevelManager.Instance.Levels[item]);
					}
				}
			}
		}
		return (dist: dictionary, visitedLevels: list);
	}
}
