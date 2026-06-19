using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
public struct CraftingSlotTimerSerialized : IBufferElementData
{
	public float TimeLeftToCraft;
}
