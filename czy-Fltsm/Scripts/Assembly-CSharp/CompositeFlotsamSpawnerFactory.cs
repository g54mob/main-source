using System.Collections.Generic;
using UnityEngine;

public class CompositeFlotsamSpawnerFactory : MonoBehaviour
{
	public static FlotsamSpawnerGroup RestoreCompositeFlotsamSpawnerGroup(CountedItemPersistentData[] itemsToRestore, PointOfInterestSpawner spawner)
	{
		if (itemsToRestore == null)
		{
			return null;
		}
		using ListPool<CountedItemProperty>.List list = ListPool<CountedItemProperty>.Get(itemsToRestore.Length);
		for (int i = 0; i < itemsToRestore.Length; i++)
		{
			CountedItemPersistentData countedItemPersistentData = itemsToRestore[i];
			if (countedItemPersistentData.TryRestoreItemProperties(out var itemProperties))
			{
				list.Add(new CountedItemProperty(itemProperties, countedItemPersistentData.Count));
			}
		}
		FlotsamSpawnerGroup flotsamSpawnerGroup = new FlotsamSpawnerGroup(50);
		FlotsamSpawner flotsamSpawner;
		while (TryReturnCompositeFlotsamSpawner(out flotsamSpawner, list, spawner))
		{
			flotsamSpawnerGroup.AddSpawner(flotsamSpawner);
		}
		return flotsamSpawnerGroup;
	}

	private static bool TryReturnCompositeFlotsamSpawner(out FlotsamSpawner flotsamSpawner, List<CountedItemProperty> composition, PointOfInterestSpawner spawner)
	{
		ListPool<CompositedFlotsamProperties>.List list = spawner.Properties.ReturnAllCompositedFlotsamProperties();
		ListPool<CompositedFlotsamProperties>.List list2 = ListPool<CompositedFlotsamProperties>.Get();
		float num = 0f;
		foreach (CompositedFlotsamProperties item in list)
		{
			float num2 = item.ReturnCompositionMatch(composition);
			if (num2 != 0f && !(num2 < num))
			{
				if (num < num2)
				{
					num = num2;
					list2.Clear();
				}
				list2.Add(item);
			}
		}
		if (list2.Count == 0)
		{
			flotsamSpawner = null;
			return false;
		}
		CompositedFlotsamProperties compositedFlotsamProperties = list2[Random.Range(0, list2.Count)];
		IEnumerable<CountedItemProperty> enumerable = ((!(num < 1f)) ? ((IEnumerable<CountedItemProperty>)compositedFlotsamProperties.Composition) : ((IEnumerable<CountedItemProperty>)composition));
		flotsamSpawner = FlotsamSpawner.CreateFromCompositeFlotsamProperties(compositedFlotsamProperties, enumerable, spawner);
		foreach (CountedItemProperty item2 in enumerable)
		{
			SubtractCountedItemProperty(composition, item2);
		}
		return true;
	}

	private static void SubtractCountedItemProperty(IEnumerable<CountedItemProperty> composition, CountedItemProperty propertyToSubtract)
	{
		foreach (CountedItemProperty item in composition)
		{
			if (item.ItemProperties == propertyToSubtract.ItemProperties)
			{
				item.Amount -= propertyToSubtract.Amount;
			}
		}
	}
}
