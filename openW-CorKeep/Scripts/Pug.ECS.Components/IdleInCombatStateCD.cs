using Pug.UnityExtensions;
using Unity.Entities;

public struct IdleInCombatStateCD : IComponentData, IQueryTypeParameter
{
	public int internalState;

	public float sqrDistanceToLeaveCombat;

	public bool checkDistanceToPlayerFromSpawnPointInsteadOfSelf;

	public ThreadSafeTimerSimple leaveStateTimer;
}
