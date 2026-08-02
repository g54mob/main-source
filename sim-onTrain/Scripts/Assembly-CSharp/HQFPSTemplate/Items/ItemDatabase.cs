using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace HQFPSTemplate.Items
{
	[CreateAssetMenu(menuName = "HQ FPS Template/Item Database")]
	public class ItemDatabase : AssetSingleton<ItemDatabase>
	{
		[SerializeField]
		private ItemCategory[] m_Categories;

		[SerializeField]
		[Reorderable]
		private ItemPropertyDefinitionList m_ItemProperties;

		private List<ItemInfo> m_Items = new List<ItemInfo>();

		private Dictionary<int, ItemInfo> m_ItemsById = new Dictionary<int, ItemInfo>();

		private Dictionary<string, ItemInfo> m_ItemsByName = new Dictionary<string, ItemInfo>();

		public static bool AssetExists => AssetSingleton<ItemDatabase>.Instance != null;

		public ItemCategory[] Categories => m_Categories;

		public static ItemInfo GetItemAtIndex(int index)
		{
			List<ItemInfo> items = AssetSingleton<ItemDatabase>.Instance.m_Items;
			if (items != null && items.Count > 0)
			{
				return items[Mathf.Clamp(index, 0, items.Count - 1)];
			}
			return null;
		}

		public static int IndexOfItem(int itemId)
		{
			List<ItemInfo> items = AssetSingleton<ItemDatabase>.Instance.m_Items;
			for (int i = 0; i < items.Count; i++)
			{
				if (items[i].Id == itemId)
				{
					return i;
				}
			}
			return -1;
		}

		public static bool TryGetItemByName(string name, out ItemInfo itemInfo)
		{
			itemInfo = GetItemByName(name);
			return itemInfo != null;
		}

		public static bool TryGetItemById(int id, out ItemInfo itemInfo)
		{
			itemInfo = GetItemById(id);
			return itemInfo != null;
		}

		public static ItemInfo GetItemByName(string name)
		{
			if (AssetSingleton<ItemDatabase>.Instance == null)
			{
				Debug.LogError("No item database asset found in the Resources folder!");
				return null;
			}
			if (AssetSingleton<ItemDatabase>.Instance.m_ItemsByName.TryGetValue(name, out var value))
			{
				return value;
			}
			return null;
		}

		public static ItemInfo GetItemById(int id)
		{
			if (AssetSingleton<ItemDatabase>.Instance == null)
			{
				Debug.LogError("No item database asset found in the Resources folder!");
				return null;
			}
			if (AssetSingleton<ItemDatabase>.Instance.m_ItemsById.TryGetValue(id, out var value))
			{
				return value;
			}
			return null;
		}

		public static List<string> GetItemNames()
		{
			List<string> list = new List<string>();
			for (int i = 0; i < AssetSingleton<ItemDatabase>.Instance.m_Categories.Length; i++)
			{
				ItemCategory itemCategory = AssetSingleton<ItemDatabase>.Instance.m_Categories[i];
				for (int j = 0; j < itemCategory.Items.Length; j++)
				{
					list.Add(itemCategory.Items[j].Name);
				}
			}
			return list;
		}

		public static List<string> GetItemNamesFull()
		{
			List<string> list = new List<string>();
			for (int i = 0; i < AssetSingleton<ItemDatabase>.Instance.m_Categories.Length; i++)
			{
				ItemCategory itemCategory = AssetSingleton<ItemDatabase>.Instance.m_Categories[i];
				for (int j = 0; j < itemCategory.Items.Length; j++)
				{
					list.Add(AssetSingleton<ItemDatabase>.Instance.m_Categories[i].Name + "/" + itemCategory.Items[j].Name);
				}
			}
			return list;
		}

		public static List<string> GetCategoryNames()
		{
			List<string> list = new List<string>();
			for (int i = 0; i < AssetSingleton<ItemDatabase>.Instance.m_Categories.Length; i++)
			{
				list.Add(AssetSingleton<ItemDatabase>.Instance.m_Categories[i].Name);
			}
			return list;
		}

		public static string[] GetPropertyNames()
		{
			string[] array = new string[AssetSingleton<ItemDatabase>.Instance.m_ItemProperties.Length];
			for (int i = 0; i < AssetSingleton<ItemDatabase>.Instance.m_ItemProperties.Length; i++)
			{
				array[i] = AssetSingleton<ItemDatabase>.Instance.m_ItemProperties[i].Name;
			}
			return array;
		}

		public static ItemPropertyDefinition[] GetProperties()
		{
			return AssetSingleton<ItemDatabase>.Instance.m_ItemProperties.ToArray();
		}

		public static ItemPropertyDefinition GetPropertyByName(string name)
		{
			foreach (ItemPropertyDefinition itemProperty in AssetSingleton<ItemDatabase>.Instance.m_ItemProperties)
			{
				if (itemProperty.Name == name)
				{
					return itemProperty;
				}
			}
			return null;
		}

		public static ItemPropertyDefinition GetPropertyAtIndex(int index)
		{
			if (index >= AssetSingleton<ItemDatabase>.Instance.m_ItemProperties.Length)
			{
				return null;
			}
			return AssetSingleton<ItemDatabase>.Instance.m_ItemProperties[index];
		}

		public static ItemCategory GetCategoryByName(string name)
		{
			for (int i = 0; i < AssetSingleton<ItemDatabase>.Instance.m_Categories.Length; i++)
			{
				if (AssetSingleton<ItemDatabase>.Instance.m_Categories[i].Name == name)
				{
					return AssetSingleton<ItemDatabase>.Instance.m_Categories[i];
				}
			}
			return null;
		}

		public static ItemCategory GetRandomCategory()
		{
			return AssetSingleton<ItemDatabase>.Instance.m_Categories[Random.Range(0, AssetSingleton<ItemDatabase>.Instance.m_Categories.Length)];
		}

		public static ItemInfo GetRandomItemFromCategory(string categoryName)
		{
			ItemCategory categoryByName = GetCategoryByName(categoryName);
			if (categoryByName != null && categoryByName.Items.Length != 0)
			{
				return categoryByName.Items[Random.Range(0, categoryByName.Items.Length)];
			}
			return null;
		}

		public static int GetItemCount()
		{
			int num = 0;
			for (int i = 0; i < AssetSingleton<ItemDatabase>.Instance.m_Categories.Length; i++)
			{
				num += AssetSingleton<ItemDatabase>.Instance.m_Categories[i].Items.Length;
			}
			return num;
		}

		private void OnEnable()
		{
			GenerateDictionaries();
			RefreshItemIDs();
		}

		private void OnValidate()
		{
			int num = 0;
			ItemCategory[] categories = m_Categories;
			foreach (ItemCategory itemCategory in categories)
			{
				for (int j = 0; j < itemCategory.Items.Length; j++)
				{
					itemCategory.Items[j].Category = itemCategory.Name;
					num++;
				}
			}
			GenerateDictionaries();
			RefreshItemIDs();
		}

		private void GenerateDictionaries()
		{
			m_Items = new List<ItemInfo>();
			m_ItemsByName = new Dictionary<string, ItemInfo>();
			m_ItemsById = new Dictionary<int, ItemInfo>();
			for (int i = 0; i < m_Categories.Length; i++)
			{
				ItemCategory itemCategory = m_Categories[i];
				for (int j = 0; j < itemCategory.Items.Length; j++)
				{
					ItemInfo itemInfo = itemCategory.Items[j];
					m_Items.Add(itemInfo);
					if (!m_ItemsByName.ContainsKey(itemInfo.Name))
					{
						m_ItemsByName.Add(itemInfo.Name, itemInfo);
					}
					if (!m_ItemsById.ContainsKey(itemInfo.Id))
					{
						m_ItemsById.Add(itemInfo.Id, itemInfo);
					}
				}
			}
		}

		private void RefreshItemIDs()
		{
			int num = 50;
			List<int> list = new List<int>();
			int num2 = 0;
			ItemCategory[] categories = m_Categories;
			for (int i = 0; i < categories.Length; i++)
			{
				ItemInfo[] items = categories[i].Items;
				foreach (ItemInfo itemInfo in items)
				{
					list.Add(itemInfo.Id);
				}
			}
			categories = m_Categories;
			for (int i = 0; i < categories.Length; i++)
			{
				ItemInfo[] items = categories[i].Items;
				foreach (ItemInfo itemInfo2 in items)
				{
					int num3 = 0;
					int num4 = list[num2];
					while ((num4 == 0 || (list.Contains(num4) && list.IndexOf(num4) != num2)) && num3 < num)
					{
						num4 = IdGenerator.GenerateIntegerId();
						num3++;
					}
					if (num3 == num)
					{
						Debug.LogError("Couldn't generate an unique id for item: " + itemInfo2.Name);
						return;
					}
					list[num2] = num4;
					AssignIdToItem(itemInfo2, num4);
					num2++;
				}
			}
		}

		private int AssignIdToItem(ItemInfo itemInfo, int id)
		{
			typeof(ItemInfo).GetField("m_Id", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(itemInfo, id);
			return id;
		}

		public ItemInfo GetItemWithName(string name)
		{
			ItemCategory[] categories = Categories;
			for (int i = 0; i < categories.Length; i++)
			{
				ItemInfo[] items = categories[i].Items;
				foreach (ItemInfo itemInfo in items)
				{
					if (itemInfo.Name == name)
					{
						return itemInfo;
					}
				}
			}
			return null;
		}
	}
}
