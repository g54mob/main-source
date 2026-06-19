using System;
using System.Collections.Generic;
using UnityEngine;

namespace UniversalInventorySystem
{
	[Serializable]
	[AddComponentMenu("UniversalInventorySystem/ItemGroup")]
	[CreateAssetMenu(fileName = "ItemGroup", menuName = "UniversalInventorySystem/ItemGroup", order = 1)]
	public class ItemGroup : ScriptableObject
	{
		public List<Item> itemsList = new List<Item>();

		public string strId;

		public int id;

		public Item GetItemAtIndex(int index)
		{
			return itemsList[index];
		}

		public Item GetItemWithName(string name)
		{
			foreach (Item items in itemsList)
			{
				if (items.name == name)
				{
					return items;
				}
			}
			return null;
		}

		public Item GetItemWithID(int id)
		{
			foreach (Item items in itemsList)
			{
				if (items.id == id)
				{
					return items;
				}
			}
			return null;
		}

		public List<Item> OrderItemsById()
		{
			return InsertionSort(itemsList);
		}

		private static List<Item> InsertionSort(List<Item> inputArray)
		{
			for (int i = 0; i < inputArray.Count - 1; i++)
			{
				for (int num = i + 1; num > 0; num--)
				{
					if (inputArray[num - 1].id > inputArray[num].id)
					{
						int num2 = inputArray[num - 1].id;
						inputArray[num - 1].id = inputArray[num].id;
						inputArray[num].id = num2;
					}
				}
			}
			return inputArray;
		}
	}
}
