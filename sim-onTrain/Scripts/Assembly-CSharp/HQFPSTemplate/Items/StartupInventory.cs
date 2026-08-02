using System;
using UnityEngine;

namespace HQFPSTemplate.Items
{
	[RequireComponent(typeof(Inventory))]
	public class StartupInventory : EntityComponent
	{
		[Serializable]
		public class ItemContainerStartupItems
		{
			public string Name;

			[Space]
			[Reorderable]
			public ItemGeneratorList StartupItems;
		}

		[SerializeField]
		private ItemContainerStartupItems[] m_ItemContainersStartupItems;

		public override void OnEntityStart()
		{
			AddItemsToInventory();
		}

		private void AddItemsToInventory()
		{
			Inventory component = GetComponent<Inventory>();
			if (!(component != null))
			{
				return;
			}
			ItemContainerStartupItems[] itemContainersStartupItems = m_ItemContainersStartupItems;
			foreach (ItemContainerStartupItems itemContainerStartupItems in itemContainersStartupItems)
			{
				ItemContainer containerWithName = component.GetContainerWithName(itemContainerStartupItems.Name);
				if (containerWithName == null)
				{
					continue;
				}
				foreach (ItemGenerator startupItem in itemContainerStartupItems.StartupItems)
				{
					if (startupItem.GenerateMethod == ItemGenerator.Method.Specific)
					{
						containerWithName.AddItem(startupItem.Name, startupItem.GetRandomCount());
					}
					else if (startupItem.GenerateMethod == ItemGenerator.Method.RandomFromCategory)
					{
						ItemInfo randomItemFromCategory = ItemDatabase.GetRandomItemFromCategory(startupItem.Category);
						if (randomItemFromCategory != null)
						{
							containerWithName.AddItem(randomItemFromCategory.Id, startupItem.GetRandomCount());
						}
					}
					else
					{
						if (startupItem.GenerateMethod != ItemGenerator.Method.Random)
						{
							continue;
						}
						ItemCategory randomCategory = ItemDatabase.GetRandomCategory();
						if (randomCategory != null)
						{
							ItemInfo randomItemFromCategory2 = ItemDatabase.GetRandomItemFromCategory(randomCategory.Name);
							if (randomItemFromCategory2 != null)
							{
								containerWithName.AddItem(randomItemFromCategory2.Id, startupItem.GetRandomCount());
							}
						}
					}
				}
			}
		}
	}
}
