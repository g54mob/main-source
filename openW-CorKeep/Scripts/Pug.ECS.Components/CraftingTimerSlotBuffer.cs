using Unity.Entities;
using Unity.NetCode;

public struct CraftingTimerSlotBuffer : IBufferElementData
{
	[GhostField(Quantization = 1)]
	public float timeLeftToCraft;
}
