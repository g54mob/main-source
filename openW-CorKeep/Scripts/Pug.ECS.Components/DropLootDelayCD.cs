using Unity.Entities;
using Unity.NetCode;

[GhostEnabledBit]
public struct DropLootDelayCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	public float Value;
}
