using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReserveFillInventory : TaskBase
{
	public enum SortingMethod
	{
		None = 0,
		Range = 1,
		UnityNavMeshPath = 2
	}

	internal struct SortedItem<T>
	{
		internal T Item;

		internal float Value;

		public SortedItem(T item, float value)
		{
			Item = item;
			Value = value;
		}
	}

	[SerializeField]
	private SortingMethod _sortingMethod;

	public override TaskType Type => TaskType.ReserveFillInventory;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		ListPool<Item>.List list = ListPool<Item>.Get(project.GeneralItems);
		using (list)
		{
			switch (_sortingMethod)
			{
			case SortingMethod.Range:
				ItemDistanceComparer.SortByShortestDistance(agent.transform.position, list);
				break;
			case SortingMethod.UnityNavMeshPath:
				SortedItemsByDistanceFromMooringpoint(agent, project, list);
				break;
			}
			foreach (Item item in list)
			{
				if (!_assignment.AddGeneralItemToHaul(item))
				{
					break;
				}
			}
		}
		yield break;
	}

	protected override void OnGUI()
	{
		Header("Reserve and fill inventory", 1, ReturnTypeColor());
		_sortingMethod = (SortingMethod)(object)EditorGUI_EnumField("Sorting Methods", _sortingMethod);
		EditorGUI_HelpBox("Reserve the amount of items that fit the assignments transit inventory from this projects general list and add them as items to haul.");
	}

	public static void SortedItemsByDistanceFromMooringpoint(Agent agent, Project project, List<Item> items)
	{
		MooringPointBase mooringPointBase = project.NavigationTarget.ReturnReservedMooringPoint(agent);
		if (mooringPointBase == null)
		{
			mooringPointBase = project.NavigationTarget.ReturnClosestMooringPoint(agent);
		}
		ListPool<InventoryBase>.List list = ListPool<InventoryBase>.Get();
		ListPool<SortedItem<InventoryBase>>.List list2 = ListPool<SortedItem<InventoryBase>>.Get();
		for (int i = 0; i < items.Count; i++)
		{
			InventoryBase inventory = items[i].Inventory;
			if (!list.Contains(inventory))
			{
				list.Add(inventory);
				Target target = inventory.Target;
				float num = PathfindingHelper.ReturnUnityNavMeshPathDistance(mooringPointBase.EmbarkTarget, target);
				int j;
				for (j = 0; j < list2.Count && list2[j].Value < num; j++)
				{
				}
				list2.Insert(j, new SortedItem<InventoryBase>(inventory, num));
			}
		}
		int num2 = items.Count;
		foreach (SortedItem<InventoryBase> item2 in list2)
		{
			for (int k = 0; k < num2; k++)
			{
				Item item = items[k];
				if (item.Inventory == item2.Item)
				{
					items.RemoveAt(k--);
					items.Add(item);
					num2--;
				}
			}
		}
		list.Dispose();
		list2.Dispose();
	}
}
