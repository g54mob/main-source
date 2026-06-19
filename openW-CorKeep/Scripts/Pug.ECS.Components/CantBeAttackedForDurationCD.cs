using Unity.Entities;

public struct CantBeAttackedForDurationCD : IComponentData, IQueryTypeParameter
{
	public float Timer;
}
