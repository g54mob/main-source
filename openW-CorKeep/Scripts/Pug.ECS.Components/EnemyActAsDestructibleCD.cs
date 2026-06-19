using Unity.Entities;

public struct EnemyActAsDestructibleCD : IComponentData, IQueryTypeParameter
{
	public float healthThreshold;

	public DamageReductionCD damageReductionBackup;
}
