using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveGenUtility
{
	public static List<T> GetRandomElements<T>(List<T> list, int n, System.Random random)
	{
		return list.OrderBy((T x) => random.Next()).Take(n).ToList();
	}

	public static List<int> DistributeEnemies(int totalEnemies, int spawnLineCount)
	{
		List<float> list = new List<float>();
		List<int> list2 = new List<int>();
		float num = 0f;
		for (int i = 0; i < spawnLineCount; i++)
		{
			float num2 = UnityEngine.Random.Range(0.2f, 1f);
			list.Add(num2);
			num += num2;
		}
		list.Sort((float a, float b) => b.CompareTo(a));
		int num3 = 0;
		for (int num4 = 0; num4 < spawnLineCount; num4++)
		{
			float num5 = list[num4] / num;
			int num6 = Mathf.FloorToInt((float)totalEnemies * num5);
			list2.Add(num6);
			num3 += num6;
		}
		for (; num3 < totalEnemies; num3++)
		{
			list2[0]++;
		}
		return list2;
	}
}
