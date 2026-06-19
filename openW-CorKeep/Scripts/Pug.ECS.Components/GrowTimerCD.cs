using Unity.Entities;

public struct GrowTimerCD : IComponentData, IQueryTypeParameter
{
	public float Value;

	public float StageTime;
}
