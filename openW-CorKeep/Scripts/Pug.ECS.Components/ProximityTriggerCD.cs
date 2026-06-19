using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct ProximityTriggerCD : IComponentData, IQueryTypeParameter
{
	public float radius;

	public float delayTime;

	public ThreadSafeTimerSimple internalTimer;

	public bool explodedFromTrigger;
}
