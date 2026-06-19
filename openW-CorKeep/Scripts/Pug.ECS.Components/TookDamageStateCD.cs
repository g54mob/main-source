using Pug.UnityExtensions;
using Unity.Entities;

public struct TookDamageStateCD : IComponentData, IQueryTypeParameter
{
	public ThreadSafeTimerSimple timer;

	public float duration;

	public int internalState;

	public bool refreshStateOnNewDamageTaken;
}
