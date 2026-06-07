using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DV.WeatherSystem
{
	public static class WeatherGrid
	{
		public static List<Weather24hPresetSO>[,] GetGrid(WeatherPackSO pack, int presetsPerAxis = 5)
		{
			List<(Weather24hPresetSO, float, float)> list = pack.presets.Where((Weather24hPresetSO p) => p != null).Select(GetAverages).ToList();
			float a = list.Min<(Weather24hPresetSO, float, float)>(((Weather24hPresetSO preset, float fogginess, float cloudiness) tup) => tup.fogginess);
			float num = list.Max<(Weather24hPresetSO, float, float)>(((Weather24hPresetSO preset, float fogginess, float cloudiness) tup) => tup.fogginess);
			float a2 = list.Min<(Weather24hPresetSO, float, float)>(((Weather24hPresetSO preset, float fogginess, float cloudiness) tup) => tup.cloudiness);
			float num2 = list.Max<(Weather24hPresetSO, float, float)>(((Weather24hPresetSO preset, float fogginess, float cloudiness) tup) => tup.cloudiness);
			List<Weather24hPresetSO>[,] array = new List<Weather24hPresetSO>[presetsPerAxis, presetsPerAxis];
			for (int num3 = 0; num3 < presetsPerAxis; num3++)
			{
				for (int num4 = 0; num4 < presetsPerAxis; num4++)
				{
					List<Weather24hPresetSO> list2 = (array[num3, num4] = new List<Weather24hPresetSO>());
					float num5 = Mathf.Lerp(a, num, (float)num4 / (float)presetsPerAxis);
					float num6 = Mathf.Lerp(a, num, (float)(num4 + 1) / (float)presetsPerAxis);
					float num7 = Mathf.Lerp(a2, num2, (float)num3 / (float)presetsPerAxis);
					float num8 = Mathf.Lerp(a2, num2, (float)(num3 + 1) / (float)presetsPerAxis);
					foreach (var item2 in list)
					{
						var (item, num9, num10) = item2;
						if (num9 == num)
						{
							num9 = Mathf.Lerp(a, num, 0.9999f);
						}
						if (num10 == num2)
						{
							num10 = Mathf.Lerp(a2, num2, 0.9999f);
						}
						if (num9 >= num5 && num9 < num6 && num10 >= num7 && num10 < num8)
						{
							list2.Add(item);
						}
					}
				}
			}
			return array;
		}

		private static (Weather24hPresetSO preset, float fogginess, float cloudiness) GetAverages(Weather24hPresetSO preset)
		{
			float num = preset.snapshots.Select((WeatherSnapshot s) => s.fogDensity).Average();
			float num2 = preset.snapshots.Select((WeatherSnapshot s) => s.cloudCoverage).Average();
			if (num < 0f || num > 0.1f)
			{
				Debug.LogWarning($"Average fogginess of preset '{preset.name}' ({num}) is out of expected range {0f}-{0.1f}", preset);
				num = Mathf.Clamp(num, 0f, 0.1f);
			}
			if (num2 < 0.2f || num2 > 1f)
			{
				Debug.LogWarning($"Average cloudiness of preset '{preset.name}' ({num2}) is out of expected range {0.2f}-{1f}k", preset);
				num2 = Mathf.Clamp(num2, 0.2f, 1f);
			}
			return (preset: preset, fogginess: num, cloudiness: num2);
		}

		public static List<(float distance, Vector2Int toCoord)>[,] GetDistanceGrid<T>(List<T>[,] sourceGrid, int maxResults = 2)
		{
			List<(float, Vector2Int)>[,] array = new List<(float, Vector2Int)>[sourceGrid.GetLength(0), sourceGrid.GetLength(1)];
			for (int i = 0; i < sourceGrid.GetLength(0); i++)
			{
				for (int j = 0; j < sourceGrid.GetLength(1); j++)
				{
					List<(float, Vector2Int)> list = new List<(float, Vector2Int)>();
					for (int k = 0; k < sourceGrid.GetLength(0); k++)
					{
						for (int l = 0; l < sourceGrid.GetLength(1); l++)
						{
							if (sourceGrid[l, k].Count != 0)
							{
								float item = Vector2.Distance(new Vector2(i, j), new Vector2(k, l));
								Vector2Int item2 = new Vector2Int(k, l);
								list.Add((item, item2));
							}
						}
					}
					array[j, i] = list.OrderBy<(float, Vector2Int), float>(((float distance, Vector2Int toCoord) c) => c.distance).Take(maxResults).ToList();
				}
			}
			return array;
		}

		public static List<T>[,] FilledWithClosest<T>(List<T>[,] sourceGrid, int maxResults = 2)
		{
			List<T>[,] array = new List<T>[sourceGrid.GetLength(0), sourceGrid.GetLength(1)];
			List<(float, Vector2Int)>[,] distanceGrid = GetDistanceGrid(sourceGrid, maxResults);
			for (int i = 0; i < distanceGrid.GetLength(0); i++)
			{
				for (int j = 0; j < distanceGrid.GetLength(1); j++)
				{
					List<T> list = (array[j, i] = new List<T>());
					foreach (var item2 in distanceGrid[j, i])
					{
						Vector2Int item = item2.Item2;
						foreach (T item3 in sourceGrid[item.y, item.x])
						{
							if (list.Count < maxResults)
							{
								list.Add(item3);
							}
						}
					}
				}
			}
			return array;
		}
	}
}
