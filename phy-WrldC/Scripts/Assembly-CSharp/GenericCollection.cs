using System.Collections.Generic;

public class GenericCollection<T> where T : class, ICollectionItem
{
	private readonly Dictionary<string, T> collection;

	public int Count => collection.Values.Count;

	public GenericCollection()
	{
		collection = new Dictionary<string, T>();
	}

	public void AddItem(T item, bool shouldOverride = false)
	{
		if (collection.ContainsKey(item.GetId()))
		{
			if (shouldOverride)
			{
				collection[item.GetId()] = item;
			}
		}
		else
		{
			collection.Add(item.GetId(), item);
		}
	}

	public void RemoveItem(T item)
	{
		if (collection.ContainsKey(item.GetId()))
		{
			collection.Remove(item.GetId());
		}
	}

	public T GetItem(string id)
	{
		if (!collection.ContainsKey(id))
		{
			return null;
		}
		return collection[id];
	}

	public ICollection<T> GetAllItems()
	{
		return collection.Values;
	}
}
