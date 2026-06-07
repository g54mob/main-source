using System.Collections.Generic;

public class GenericCategory<TItem> where TItem : class
{
	private readonly List<TItem> itemList;

	public string Name { get; private set; }

	public GenericCategory(string name)
	{
		Name = name;
		itemList = new List<TItem>();
	}

	public TItem GetItem(int index)
	{
		if (index >= itemList.Count)
		{
			return null;
		}
		return itemList[index];
	}

	public int GetItemIndex(TItem item)
	{
		return itemList.IndexOf(item);
	}

	public void AddItem(TItem item)
	{
		itemList.Add(item);
	}

	public void RemoveItem(TItem item)
	{
		itemList.Remove(item);
	}

	public ICollection<TItem> GetAllItems()
	{
		return itemList.ToArray();
	}

	public int ItemsCount()
	{
		return itemList.Count;
	}
}
