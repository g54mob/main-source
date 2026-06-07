using System.Collections.Generic;
using UnityEngine;

public class WorkshopTrendsModel : BaseModel
{
	public struct ItemData
	{
		public ulong itemId;

		public string itemName;

		public Texture2D itemTexture;
	}

	public const string SelectedIndexChangedEvent = "WorkshopWeekModel.SelectedIndexChangedEvent";

	private List<ItemData> items;

	private int selectedIndex;

	public int SelectedIndex
	{
		get
		{
			return selectedIndex;
		}
		set
		{
			selectedIndex = Mathf.Clamp(value, 0, items.Count - 1);
			NotifyChange("WorkshopWeekModel.SelectedIndexChangedEvent", (items.Count != 0) ? items[selectedIndex] : new ItemData
			{
				itemId = 0uL
			});
		}
	}

	public int ItemCount => items.Count;

	public WorkshopTrendsModel()
	{
		items = new List<ItemData>();
	}

	public void AddItem(ulong itemId, string itemName, Texture2D itemTexture)
	{
		items.Add(new ItemData
		{
			itemId = itemId,
			itemName = itemName,
			itemTexture = itemTexture
		});
	}
}
