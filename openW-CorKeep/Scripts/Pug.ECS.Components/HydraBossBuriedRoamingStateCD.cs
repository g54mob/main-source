using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct HydraBossBuriedRoamingStateCD : IComponentData, IQueryTypeParameter
{
	public float buryDuration;

	public float unearthDuration;

	public int damage;

	public ThreadSafeTimerSimple timer;

	[GhostField]
	public int internalState;

	public float3 startLocation;

	public float3 targetLocation;

	public int currentLocationIndex;

	public bool disabled;
}
