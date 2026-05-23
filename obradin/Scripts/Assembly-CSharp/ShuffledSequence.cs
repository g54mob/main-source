using System.Collections.Generic;
using UnityEngine;

public class ShuffledSequence
{
	private List<int> array;

	private int cur;

	public int next
	{
		get
		{
			if (cur >= array.Count)
			{
				cur = 0;
				List<int> list = new List<int>();
				int num = array.Count / 2 - 1;
				for (int i = 0; i < array.Count; i++)
				{
					int num2 = 0;
					int num3 = Mathf.Min(array.Count, array.Count - num + i);
					List<int> list2 = new List<int>();
					for (int j = num2; j < num3; j++)
					{
						int item = array[j];
						if (list.IndexOf(item) < 0)
						{
							list2.Add(item);
						}
					}
					int index = Random.Range(0, list2.Count);
					list.Add(list2[index]);
				}
				array = list;
			}
			int result = array[cur];
			cur++;
			return result;
		}
	}

	public ShuffledSequence(int count)
	{
		array = MakeShuffledArray(count);
		cur = 0;
	}

	public static List<int> MakeShuffledArray(int count)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < count; i++)
		{
			list.Add(i);
		}
		for (int j = 0; j < count; j++)
		{
			int index = count - j - 1;
			int index2 = Random.Range(0, count - j);
			int value = list[index];
			list[index] = list[index2];
			list[index2] = value;
		}
		return list;
	}
}
