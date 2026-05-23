using System;

[Serializable]
public class TechTreeSaveDataNode : IComparable<TechTreeSaveDataNode>
{
	public int ID;

	public int UnlockIndex;

	public ResourceCostSaveData PaidCosts;

	public TechTreeSaveDataNode(int id, int unlockIndex, ResourceCost resourceCost)
	{
		ID = id;
		UnlockIndex = unlockIndex;
		PaidCosts = resourceCost.ToSaveData();
	}

	public int CompareTo(TechTreeSaveDataNode other)
	{
		return UnlockIndex.CompareTo(other.UnlockIndex);
	}
}
