using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct CraftingCD : IComponentData, IQueryTypeParameter
{
	public int outputSlotIndex;

	public CraftingType craftingType;

	public bool craftingConsumesEntityAmount => DoesCraftingConsumeEntityAmount(craftingType);

	public bool craftingOutputsInInputSlot
	{
		get
		{
			CraftingType craftingType = this.craftingType;
			return craftingType == CraftingType.Fishing || craftingType == CraftingType.CritterCatching;
		}
	}

	public static bool IsProcessAutoCrafter(CraftingType craftingType)
	{
		if (craftingType != CraftingType.ProcessResources && craftingType != CraftingType.Cooking && craftingType != CraftingType.Extract && craftingType != CraftingType.Incinerate && craftingType != CraftingType.Fishing)
		{
			return craftingType == CraftingType.CritterCatching;
		}
		return true;
	}

	public static bool IsRecipeCrafter(CraftingType craftingType)
	{
		if (craftingType != CraftingType.ProcessResources && craftingType != CraftingType.Cooking)
		{
			return craftingType == CraftingType.Cattle;
		}
		return true;
	}

	public static bool DoesCraftingConsumeEntityAmount(CraftingType craftingType)
	{
		return craftingType == CraftingType.Cattle;
	}
}
