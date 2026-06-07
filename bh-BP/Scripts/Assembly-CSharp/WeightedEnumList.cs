using System;
using System.Collections.Generic;

[Serializable]
public class WeightedEnumList<T>
{
	private List<T> _enumList;

	private List<float> _weightList;

	private float _totalWeight;

	public T this[int i]
	{
		get
		{
			return default(T);
		}
		set
		{
		}
	}

	public int Count => 0;

	public void Add(T item, float weight)
	{
	}

	public void Remove(T item)
	{
	}

	public void RemoveAt(int idx)
	{
	}

	public void SetWeight(T item, float weight)
	{
	}

	public int PickRandomIdx(Random rnd)
	{
		return 0;
	}

	public T PickRandomItem(Random rnd)
	{
		return default(T);
	}
}
