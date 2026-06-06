using System;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class SalvagerPersistentData : BuildableExtendablePersistentData<Salvager>
{
	public PersistentReference<Item>.Reference CurrentItem;

	public float SalvageProgress;

	[OptionalField(VersionAdded = 3)]
	public int[] DisabledSalvageableCategories;

	[OptionalField(VersionAdded = 2)]
	public int DayProduction;

	[OptionalField(VersionAdded = 2)]
	public int DayProductionLimit;

	public SalvagerPersistentData(Salvager salvager)
		: base(salvager)
	{
		SalvageProgress = salvager.SalvageProgress;
		if (salvager.SalvageableCategories == null)
		{
			return;
		}
		using ListPool<int>.List list = ListPool<int>.Get();
		Salvager.SalvageableCategory[] salvageableCategories = salvager.SalvageableCategories;
		foreach (Salvager.SalvageableCategory salvageableCategory in salvageableCategories)
		{
			if (salvageableCategory != null && !salvageableCategory.Enabled)
			{
				list.Add(GameManager.PersistenceManager.ReturnPropertiesIndex(salvageableCategory.MainItemProperties));
			}
		}
		DisabledSalvageableCategories = list.ToArray();
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<Salvager>(out var component))
		{
			base.Instance = component;
			base.Instance.Restore(this);
		}
	}

	public override void RestoreReferences()
	{
		if (base.Instance != null)
		{
			base.Instance.RestoreReferences(this);
		}
	}

	public void RestoreSalvageableCategories(Salvager.SalvageableCategory[] salvageableCategories)
	{
		if (DisabledSalvageableCategories == null)
		{
			return;
		}
		if (salvageableCategories.IsNullOrEmpty())
		{
			Debug.LogException(new NotSupportedException("Salvager.SalvageableItems has not been initialized. Unable to Restore!"));
			return;
		}
		int[] disabledSalvageableCategories = DisabledSalvageableCategories;
		foreach (int index in disabledSalvageableCategories)
		{
			if (GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(index, out var reference))
			{
				DisableSalvageableCategory(salvageableCategories, reference);
			}
		}
	}

	private void DisableSalvageableCategory(Salvager.SalvageableCategory[] salvageableCategories, ItemProperties mainItemProperties)
	{
		foreach (Salvager.SalvageableCategory salvageableCategory in salvageableCategories)
		{
			if (salvageableCategory.MainItemProperties == mainItemProperties)
			{
				salvageableCategory.Enabled = false;
			}
		}
	}

	public override void PopulateReferences()
	{
		base.Instance.PopulateReferences(this);
	}
}
