using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct LarvaHiveEggHatchStateCD : IComponentData, IQueryTypeParameter
{
	public float stateTransitionDuration;

	public float hatchDuration;

	[GhostField]
	public int internalState;

	public ThreadSafeTimerSimple internalTimer;

	public int colliderState;
}
