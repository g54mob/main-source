using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

[Serializable]
public class BirdHousePersistentData : BuildableExtendablePersistentData<BirdHouse>
{
	[Serializable]
	public struct ItemGroup
	{
		public int ItemIndex;

		public bool Enabled;
	}

	public PersistentReference<Project>.Reference ImportProject;

	public bool SalvageWood;

	public bool SalvagePlastic;

	public bool RefillFood;

	[OptionalField(VersionAdded = 2)]
	public bool ExportItems = true;

	public BirdHouse.BirdHouseState State;

	public PersistentReference<Bird>.Reference[] Birds;

	[OptionalField(VersionAdded = 3)]
	public int[] DisabledItemGroups;

	public int FoodStore;

	[NonSerialized]
	private List<ItemProperties> _disabledItemGroups;

	public BirdHousePersistentData(BirdHouse birdHouse)
		: base(birdHouse)
	{
		base.Instance = birdHouse;
		DisabledItemGroups = ReturnDisabledItemGroups(birdHouse.ItemGroups);
		RefillFood = birdHouse.RefillFood;
		ExportItems = birdHouse.ExportItems;
		State = birdHouse.State;
		FoodStore = birdHouse.FoodStore;
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<BirdHouse>(out var component))
		{
			base.Instance = component;
			base.Instance.Restore(this);
		}
	}

	public override void RestoreReferences()
	{
		if (!DisabledItemGroups.IsNullOrEmpty())
		{
			_disabledItemGroups = new List<ItemProperties>();
			int[] disabledItemGroups = DisabledItemGroups;
			foreach (int index in disabledItemGroups)
			{
				if (GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(index, out var reference))
				{
					_disabledItemGroups.Add(reference);
				}
			}
		}
		if (base.Instance != null)
		{
			base.Instance.RestoreReferences(this);
		}
	}

	public override void PopulateReferences()
	{
		base.Instance.PopulateReferences(this);
	}

	private int[] ReturnDisabledItemGroups(ItemPropertiesGroup[] itemGroups)
	{
		if (itemGroups.IsNullOrEmpty())
		{
			return null;
		}
		using ListPool<int>.List list = ListPool<int>.Get();
		foreach (ItemPropertiesGroup itemPropertiesGroup in itemGroups)
		{
			if (!itemPropertiesGroup.Enabled)
			{
				list.Add(GameManager.PersistenceManager.ReturnPropertiesIndex(itemPropertiesGroup.UIProperties));
			}
		}
		if (list.IsNullOrEmpty())
		{
			return null;
		}
		return list.ToArray();
	}

	public bool IsItemGroupEnabled(ItemPropertiesGroup itemGroup)
	{
		if (!_disabledItemGroups.IsNullOrEmpty())
		{
			return !_disabledItemGroups.Contains(itemGroup.UIProperties);
		}
		return true;
	}
}
