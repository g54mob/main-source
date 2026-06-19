using Unity.Entities;

public struct SlimeBossCD : IComponentData, IQueryTypeParameter
{
	public bool shouldSetupNewRangeAttack;

	public int rangeAttacksTracker;
}
