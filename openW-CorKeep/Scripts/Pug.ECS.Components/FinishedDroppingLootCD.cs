using Unity.Entities;
using Unity.NetCode;

[GhostEnabledBit]
public struct FinishedDroppingLootCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	public byte dummyData;
}
