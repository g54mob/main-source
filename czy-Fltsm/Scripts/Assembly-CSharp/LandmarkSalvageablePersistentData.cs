using System;
using System.Runtime.Serialization;

[Serializable]
public class LandmarkSalvageablePersistentData : ILandmarkInteractablePersistentData
{
	private InventoryPersistentData[] _inventories;

	[OptionalField(VersionAdded = 2)]
	private int[] _variationIndices;

	public LandmarkSalvageablePersistentData()
	{
	}

	public LandmarkSalvageablePersistentData(Landmark landmark)
	{
		LandmarkSalvageable[] componentsInChildren = landmark.GetComponentsInChildren<LandmarkSalvageable>();
		int num = componentsInChildren.Length;
		if (componentsInChildren == null || num == 0)
		{
			_inventories = null;
			_variationIndices = null;
			return;
		}
		_inventories = new InventoryPersistentData[num];
		_variationIndices = new int[num];
		for (int i = 0; i < num; i++)
		{
			LandmarkSalvageable landmarkSalvageable = componentsInChildren[i];
			_inventories[i] = new InventoryPersistentData(landmarkSalvageable.Inventory);
			_variationIndices[i] = landmarkSalvageable.VariationIndex;
		}
	}

	public void Restore(Landmark landmark)
	{
		LandmarkSalvageable[] componentsInChildren = landmark.GetComponentsInChildren<LandmarkSalvageable>();
		int i = 0;
		if (_inventories == null)
		{
			return;
		}
		if (_variationIndices != null)
		{
			for (; i < _inventories.Length; i++)
			{
				if (i < componentsInChildren.Length)
				{
					componentsInChildren[i].Restore(_inventories[i], _variationIndices[i]);
				}
			}
			return;
		}
		for (; i < _inventories.Length; i++)
		{
			if (i < componentsInChildren.Length)
			{
				componentsInChildren[i].Restore(_inventories[i], -1);
			}
		}
	}

	public bool TryReturnVariationIndexAndCompositionItems(int index, out int variationIndex, out CountedItemProperty[] compositionItems)
	{
		compositionItems = null;
		variationIndex = -1;
		if (_inventories.IsNullOrEmpty() || _variationIndices.IsNullOrEmpty())
		{
			return false;
		}
		if (0 <= index && index < _inventories.Length && index < _variationIndices.Length)
		{
			compositionItems = _inventories[index].ReturnCountedItems(SubInventoryType.Composition);
			variationIndex = _variationIndices[index];
		}
		return compositionItems != null;
	}
}
