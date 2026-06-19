using Unity.Entities;

public struct VehicleCD : IComponentData, IQueryTypeParameter
{
	public float speedMultiplier;

	public float driftingMultiplier;

	public float accelerationMultiplier;

	public SFXTableIDField honkSound;
}
