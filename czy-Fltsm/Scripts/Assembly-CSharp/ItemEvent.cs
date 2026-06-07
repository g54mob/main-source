using System.Collections.Generic;

public class ItemEvent : GameEvent
{
	private static readonly ItemEvent _instance = new ItemEvent();

	public Item Item { get; private set; }

	public ItemProperties ItemProperties { get; private set; }

	public List<ItemProperties> ProducedItems { get; private set; }

	public int Amount { get; private set; }

	private ItemEvent()
		: base(GameEventType.None)
	{
	}

	public static void Dispatch(GameEventType eventType, Item item)
	{
		GetInstance(eventType, item, item.Properties).Dispatch();
	}

	public static void Dispatch(GameEventType eventType, ItemProperties properties)
	{
		GetInstance(eventType, null, properties).Dispatch();
	}

	public static void Dispatch(GameEventType eventType, CountedItemProperty countedItem)
	{
		GetInstance(eventType, null, countedItem.ItemProperties, countedItem.Amount).Dispatch();
	}

	public static void DispatchItemsProduced(params Item[] items)
	{
		DispatchItemsProduced(items);
	}

	public static void DispatchItemsProduced(IEnumerable<Item> items)
	{
		ItemEvent instance = GetInstance(GameEventType.ItemsProduced);
		if (instance.ProducedItems == null)
		{
			instance.ProducedItems = new List<ItemProperties>();
		}
		foreach (Item item in items)
		{
			instance.ProducedItems.AddUnique(item.Properties);
		}
		instance.Dispatch();
		instance.ProducedItems.Clear();
	}

	private static ItemEvent GetInstance(GameEventType eventType, Item item = null, ItemProperties properties = null, int amount = 1)
	{
		_instance.EventType = eventType;
		_instance.Item = item;
		_instance.ItemProperties = ((item == null) ? properties : item.Properties);
		_instance.Amount = amount;
		return _instance;
	}
}
