using System.Collections.Generic;

public static class ItemHelper
{
	public static ListPool<Item>.List ReturnUniqueItems(List<Item> items)
	{
		ListPool<Item>.List list = ListPool<Item>.Get();
		foreach (Item item in items)
		{
			bool flag = true;
			foreach (Item item2 in list)
			{
				if (item.Properties == item2.Properties)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				list.Add(item);
			}
		}
		return list;
	}
}
