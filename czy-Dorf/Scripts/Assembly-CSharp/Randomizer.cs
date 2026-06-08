using System;
using System.Collections.Generic;
using UnityEngine;

public static class Randomizer
{
	private static int counter;

	public static T SelectWeightedRandom<T>(Dictionary<T, float> objectByProbability)
	{
		float num = TotalProbability(objectByProbability);
		float num2 = UnityEngine.Random.Range(0f, num);
		foreach (KeyValuePair<T, float> item in objectByProbability)
		{
			num2 -= item.Value;
			if (num2 <= 0.0001f)
			{
				return item.Key;
			}
		}
		Debug.LogError($"no {typeof(T)} was selected - {objectByProbability.Count} options, totalProbability: {num}, randomNumber: {num2}");
		return default(T);
	}

	public static T SelectWeightedRandom<T>(List<T> selection, float overwriteAlpha = -1f) where T : IWeightedRandomizable
	{
		float num = TotalProbability(selection);
		float num2 = ((overwriteAlpha < 0f) ? UnityEngine.Random.Range(0f, num) : (overwriteAlpha * num));
		foreach (T item in selection)
		{
			num2 -= item.Probability;
			if (num2 <= 0f)
			{
				return item;
			}
		}
		Debug.LogError($"no {typeof(T)} was selected - {selection.Count} options, totalProbability: {num}");
		return default(T);
	}

	public static float TotalProbability<T>(List<T> selection) where T : IWeightedRandomizable
	{
		float num = 0f;
		foreach (T item in selection)
		{
			num += item.Probability;
		}
		return num;
	}

	private static float TotalProbability<T>(Dictionary<T, float> probabilities)
	{
		float num = 0f;
		foreach (KeyValuePair<T, float> probability in probabilities)
		{
			num += probability.Value;
		}
		return num;
	}

	public static void RandomizeSeed()
	{
		counter++;
		UnityEngine.Random.InitState((int)DateTime.Now.Ticks + counter);
	}

	public static int GetRandomSeed()
	{
		counter++;
		int num = (int)DateTime.Now.Ticks + counter;
		if (num == -1)
		{
			num++;
		}
		return num;
	}
}
