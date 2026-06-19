using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.Server)]
public struct PlayAnimationStateCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	public float duration;

	public int animId;

	public int2 facingDirection;

	public int internalState;

	public ThreadSafeTimerSimple timer;
}
