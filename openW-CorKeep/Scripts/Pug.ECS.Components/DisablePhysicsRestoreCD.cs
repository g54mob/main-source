using Unity.Entities;

public struct DisablePhysicsRestoreCD : IComponentData, IQueryTypeParameter
{
	public bool restoreSimulate;
}
