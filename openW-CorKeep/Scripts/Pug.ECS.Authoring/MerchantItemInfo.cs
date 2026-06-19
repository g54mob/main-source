using System;

[Serializable]
public struct MerchantItemInfo
{
	public ObjectID objectID;

	public int amount;

	public MerchantItemRequirement requirementToBeAvailable;
}
