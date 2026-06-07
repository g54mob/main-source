using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

[Serializable]
public class StoragePersistentData : BuildableExtendablePersistentData<Storage>
{
	[OptionalField(VersionAdded = 3)]
	private Item.Tags _acceptedTags;

	[OptionalField(VersionAdded = 2)]
	private int[] _acceptedIndices;

	public int[] AcceptedIndices => _acceptedIndices;

	public StoragePersistentData(Storage storage)
		: base(storage)
	{
		_acceptedTags = storage.Filter.AcceptedTags;
		_acceptedIndices = ReturnAcceptedItemPropertiesIndices(storage.Filter);
	}

	public override void PopulateReferences()
	{
		base.Instance.PopulateReferences(this);
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<Storage>(out var component))
		{
			base.Instance = component;
		}
	}

	public override void RestoreReferences()
	{
		if (!(base.Instance == null))
		{
			if (PersistenceManager.DoesSaveInfoVersionComeBefore(1, 0, 1))
			{
				base.Instance.Filter.Restore(base.Instance.Filter.Tags, _acceptedIndices);
			}
			else
			{
				base.Instance.Filter.Restore(_acceptedTags, _acceptedIndices);
			}
		}
	}

	private int[] ReturnAcceptedItemPropertiesIndices(ItemFilter itemFilter)
	{
		if (itemFilter == null || itemFilter.AcceptedItems == null || itemFilter.AcceptedItems.Count == itemFilter.AllItems.Count)
		{
			return null;
		}
		HashSet<ItemProperties>.Enumerator enumerator = itemFilter.AcceptedItems.GetEnumerator();
		int[] array = new int[itemFilter.AcceptedItems.Count];
		int num = 0;
		while (enumerator.MoveNext())
		{
			array[num++] = GameManager.PersistenceManager.ReturnPropertiesIndex(enumerator.Current);
		}
		return array;
	}
}
