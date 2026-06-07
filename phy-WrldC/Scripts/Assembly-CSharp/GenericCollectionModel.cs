using System.Collections.Generic;

public class GenericCollectionModel<T> : BaseModel where T : class, ICollectionItem
{
	public const string AddItemEvent = "GenericCollectionModel.AddItemEvent";

	public const string OverrideItemEvent = "GenericCollectionModel.OverrideItemEvent";

	public const string RemoveItemEvent = "GenericCollectionModel.RemoveItemEvent";

	public const string CountChangedEvent = "GenericCollectionModel.CountChangedEvent";

	public const string WarningMessageEvent = "GenericCollectionModel.WarningMessageEvent";

	private readonly Dictionary<string, T> collection;

	public int Count => collection.Values.Count;

	public GenericCollectionModel()
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
				NotifyChange("GenericCollectionModel.OverrideItemEvent", item);
			}
			else
			{
				NotifyChange("GenericCollectionModel.WarningMessageEvent", "The collection already has this Item!");
			}
		}
		else
		{
			collection.Add(item.GetId(), item);
			NotifyChange("GenericCollectionModel.AddItemEvent", item);
			NotifyChange("GenericCollectionModel.CountChangedEvent", Count);
		}
	}

	public void AddItems(IEnumerable<T> collection, bool shouldOverride = false)
	{
		foreach (T item in collection)
		{
			AddItem(item, shouldOverride);
		}
	}

	public void RemoveItem(string id)
	{
		if (collection.ContainsKey(id))
		{
			collection.Remove(id);
			NotifyChange("GenericCollectionModel.RemoveItemEvent", id);
			NotifyChange("GenericCollectionModel.CountChangedEvent", Count);
		}
		else
		{
			NotifyChange("GenericCollectionModel.WarningMessageEvent", "Didn't find the item to remove!");
		}
	}

	public void RemoveItem(T item)
	{
		RemoveItem(item.GetId());
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
