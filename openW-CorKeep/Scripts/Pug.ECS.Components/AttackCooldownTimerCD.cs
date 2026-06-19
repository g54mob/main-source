using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.Server)]
public struct AttackCooldownTimerCD : IComponentData, IQueryTypeParameter
{
	public ThreadSafeTimerSimple Value;
}
