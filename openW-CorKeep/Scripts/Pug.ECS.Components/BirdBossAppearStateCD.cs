using Pug.UnityExtensions;
using Unity.Entities;

public struct BirdBossAppearStateCD : IComponentData, IQueryTypeParameter
{
	public int internalState;

	public float landDuration;

	public ThreadSafeTimerSimple timer;

	public Entity glimmeringObject;
}
