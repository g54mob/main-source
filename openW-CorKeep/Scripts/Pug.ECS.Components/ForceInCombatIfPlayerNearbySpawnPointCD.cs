using Unity.Entities;

public struct ForceInCombatIfPlayerNearbySpawnPointCD : IComponentData, IQueryTypeParameter
{
	public float distanceToStayInCombatSq;
}
