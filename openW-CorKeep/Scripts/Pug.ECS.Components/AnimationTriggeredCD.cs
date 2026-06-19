using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.Client)]
public struct AnimationTriggeredCD : IComponentData, IQueryTypeParameter
{
	public uint lastTriggerCount;
}
