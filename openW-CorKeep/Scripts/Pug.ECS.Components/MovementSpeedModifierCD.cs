using Unity.Entities;

public struct MovementSpeedModifierCD : IComponentData, IQueryTypeParameter
{
	public float Value;
}
