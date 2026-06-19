using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;

public struct CoreBossBeamCD : IComponentData, IQueryTypeParameter
{
	public float startDuration;

	public float loopDuration;

	public float endDuration;

	public float hiddenEndDuration;

	public int internalState;

	public ThreadSafeTimerSimple timer;

	public ThreadSafeTimerSimple dealDamageTimer;

	public int instructionIndex;

	public ThreadSafeTimerSimple instructionTimer;

	public float3 direction;
}
