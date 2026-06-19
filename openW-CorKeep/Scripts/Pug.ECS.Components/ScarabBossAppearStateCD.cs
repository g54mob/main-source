using Pug.UnityExtensions;
using Unity.Entities;

public struct ScarabBossAppearStateCD : IComponentData, IQueryTypeParameter
{
	public Entity thumperEntity;

	public int internalState;

	public float appearDuration;

	public ThreadSafeTimerSimple timer;
}
