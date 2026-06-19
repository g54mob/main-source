using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
public struct CraftingSlotByRecipesSerialized : IBufferElementData
{
	public int CurrentlyCrafting;
}
