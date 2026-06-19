using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct IndirectProjectileCD : IComponentData, IQueryTypeParameter
{
	public float delayTime;

	public bool seeking;

	public float speed;

	public ThreadSafeTimerSimple internalTimer;
}
