using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.Items
{
	[CreateAssetMenu(menuName = "DV/Starting Items")]
	public class StartingItems : ScriptableObject
	{
		[Serializable]
		public struct StartingItem
		{
			public InventoryItemSpec item;

			public int preferredRelativeSlot;

			public bool backpackPriority;

			public bool allowDuplicates;

			public string ItemPrefabName => item.ItemPrefabName;
		}

		public GameParams.StartingItemsType startingItemsType;

		[SerializeField]
		private List<StartingItem> items;

		[SerializeField]
		private bool includesOtherStartingItems;

		[SerializeField]
		private List<StartingItems> includedOtherStartingItems;

		public List<StartingItem> GetStartingItems()
		{
			if (!includesOtherStartingItems)
			{
				return items;
			}
			List<StartingItem> list = new List<StartingItem>(items);
			foreach (StartingItems includedOtherStartingItem in includedOtherStartingItems)
			{
				list.AddRange(includedOtherStartingItem.GetStartingItemsWithoutIncludes());
			}
			return list;
		}

		private List<StartingItem> GetStartingItemsWithoutIncludes()
		{
			return items;
		}
	}
}
