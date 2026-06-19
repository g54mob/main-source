using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

public struct IsInCombatCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool isInCombat;

	public ThreadSafeTimerSimple leaveCombatTimer;

	public bool justLeftCombat;

	public bool justEnteredCombat;
}
