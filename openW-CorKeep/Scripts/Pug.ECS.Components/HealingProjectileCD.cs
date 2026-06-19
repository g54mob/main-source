using Unity.Entities;

public struct HealingProjectileCD : IComponentData, IQueryTypeParameter
{
	public float sameFactionHealingPercentage;
}
