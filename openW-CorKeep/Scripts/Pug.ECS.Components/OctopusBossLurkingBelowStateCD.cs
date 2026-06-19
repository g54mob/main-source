using Pug.UnityExtensions;
using Unity.Entities;

public struct OctopusBossLurkingBelowStateCD : IComponentData, IQueryTypeParameter
{
	public ThreadSafeTimerSimple cooldownTimer;

	public ThreadSafeTimerSimple timer;

	public int internalState;

	public bool hasEnteredStateOnce;
}
