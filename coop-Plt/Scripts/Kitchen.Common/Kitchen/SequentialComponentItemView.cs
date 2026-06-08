using System.Collections.Generic;
using System.Linq;
using KitchenData;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kitchen
{
	public class SequentialComponentItemView : SerializedMonoBehaviour, IItemSpecificView
	{
		public bool UseLinearMode = true;

		public List<(List<Item>, List<Transform>)> Locations = new List<(List<Item>, List<Transform>)>();

		public Transform FirstItem;

		public Transform OffsetItem;

		public GameObject ComponentsContainer;

		public List<(Item, GameObject)> Items = new List<(Item, GameObject)>();

		public List<(Item, GameObject)> ElementPrefabs = new List<(Item, GameObject)>();

		public void PerformUpdate(int item_id, ItemList components, bool is_order)
		{
			HideAll();
			if (is_order)
			{
				DrawAsSequential(components);
			}
			else
			{
				DrawAsWhole(components);
			}
		}

		private void HideAll()
		{
			if (ComponentsContainer != null)
			{
				Object.Destroy(ComponentsContainer);
			}
			ComponentsContainer = new GameObject();
			ComponentsContainer.transform.ParentTo(base.transform);
			foreach (var item in Items)
			{
				item.Item2.SetActive(value: false);
			}
		}

		private void DrawAsWhole(ItemList components)
		{
			if (UseLinearMode)
			{
				int num = 0;
				{
					foreach (int item in components)
					{
						GameObject gameObject = CreatePrefab(item);
						if (!(gameObject == null))
						{
							num++;
							gameObject.transform.position = FirstItem.position + num * OffsetItem.localPosition;
						}
					}
					return;
				}
			}
			ClearLocations();
			foreach (int item2 in components)
			{
				Transform transform = FindLocationForItem(item2);
				if (!(transform == null))
				{
					GameObject gameObject2 = CreatePrefab(item2);
					if (!(gameObject2 == null))
					{
						gameObject2.transform.ParentTo(transform);
					}
				}
			}
		}

		private void ClearLocations()
		{
			foreach (var location in Locations)
			{
				foreach (Transform item in location.Item2)
				{
					if (item.childCount != 0)
					{
						item.RemoveChildren();
						item.DetachChildren();
					}
				}
			}
		}

		private Transform FindLocationForItem(int item)
		{
			foreach (var location in Locations)
			{
				if (!location.Item1.Select((Item i) => i.ID).Contains(item))
				{
					continue;
				}
				foreach (Transform item2 in location.Item2)
				{
					if (item2.childCount <= 0)
					{
						return item2;
					}
				}
			}
			return null;
		}

		private void DrawAsSequential(ItemList components)
		{
			foreach (var item in Items)
			{
				item.Item2.SetActive(value: false);
			}
			foreach (int item2 in components)
			{
				foreach (var item3 in Items)
				{
					if (item3.Item1.ID == item2)
					{
						item3.Item2.SetActive(value: true);
						return;
					}
				}
			}
		}

		private GameObject CreatePrefab(int item)
		{
			foreach (var elementPrefab in ElementPrefabs)
			{
				if (elementPrefab.Item1.ID == item)
				{
					GameObject obj = Object.Instantiate(elementPrefab.Item2);
					obj.transform.ParentTo(ComponentsContainer);
					obj.SetActive(value: true);
					return obj;
				}
			}
			return null;
		}
	}
}
