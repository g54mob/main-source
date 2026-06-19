using Unity.Entities;

public struct CombatRadiusCD : IComponentData, IQueryTypeParameter
{
	public float radius;

	public float radiusSq;
}
