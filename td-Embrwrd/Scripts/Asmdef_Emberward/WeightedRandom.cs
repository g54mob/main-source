using System.Collections.Generic;

public class WeightedRandom<T>
{
	private List<T> items;

	private List<int> weights;

	private int totalWeight;

	public void AddItem(T item, int weight)
	{
	}

	public void AddItemByList(List<T> list_Items, int weight)
	{
	}

	public void RemoveItem(T item)
	{
	}

	public bool HasAnyItem()
	{
		return false;
	}

	public T GetRandomResult(bool removeAfterGet = false)
	{
		return default(T);
	}

	public int GetItemCount()
	{
		return 0;
	}

	public void Clear()
	{
	}
}
