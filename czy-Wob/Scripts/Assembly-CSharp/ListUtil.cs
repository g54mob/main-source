using System.Collections.Generic;
using UnityEngine;

public static class ListUtil
{
	public static void DeleteAndClearListElements(ref List<GameObject> listToClear)
	{
		for (int i = 0; i < listToClear.Count; i++)
		{
			Object.Destroy(listToClear[i]);
		}
		listToClear.Clear();
	}

	public static void FillWithDefaultValues<T>(ref List<T> listTarget, T defaultVal)
	{
		for (int i = 0; i < listTarget.Count; i++)
		{
			listTarget[i] = defaultVal;
		}
	}

	public static void ShuffleList<T>(ref List<T> objects, int cutoff = -1)
	{
		List<T> list = new List<T>();
		while (objects.Count > 0)
		{
			T randomElement = GetRandomElement(objects);
			list.Add(randomElement);
			int index = objects.IndexOf(randomElement);
			objects.RemoveAt(index);
			if (cutoff > 0 && list.Count >= cutoff)
			{
				break;
			}
		}
		objects = list;
	}

	public static List<T> GetWeightedShuffle<T>(List<T> objects, List<float> weights)
	{
		List<T> list = new List<T>();
		while (objects.Count > 0)
		{
			T weightedRandom = GetWeightedRandom(objects, weights);
			list.Add(weightedRandom);
			int index = objects.IndexOf(weightedRandom);
			objects.RemoveAt(index);
			weights.RemoveAt(index);
		}
		return list;
	}

	public static T GetWeightedRandom<T>(List<T> objects, List<float> weights, ref int index)
	{
		index = -1;
		if (objects.Count == 0)
		{
			return default(T);
		}
		float num = 0f;
		for (int i = 0; i < weights.Count; i++)
		{
			num += weights[i];
		}
		index = 0;
		T result = objects[0];
		float num2 = Random.Range(0f, num);
		for (int j = 0; j < objects.Count; j++)
		{
			if (num2 < weights[j])
			{
				index = j;
				result = objects[j];
				break;
			}
			num2 -= weights[j];
		}
		return result;
	}

	public static T GetWeightedRandom<T>(List<T> objects, List<float> weights)
	{
		int index = 0;
		return GetWeightedRandom(objects, weights, ref index);
	}

	public static T GetRandomElement<T>(List<T> objects, ref int index)
	{
		if (objects.Count == 0)
		{
			index = -1;
			return default(T);
		}
		index = Random.Range(0, objects.Count);
		return objects[index];
	}

	public static T GetRandomElement<T>(List<T> objects)
	{
		int index = 0;
		return GetRandomElement(objects, ref index);
	}
}
