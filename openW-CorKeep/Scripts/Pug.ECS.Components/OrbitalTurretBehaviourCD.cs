using Unity.Entities;

public struct OrbitalTurretBehaviourCD : IComponentData, IQueryTypeParameter
{
	public int shieldActivationCounter;

	public bool hasUpdated;
}
