using Unity.Entities;

public struct GrowTimerRefCD : ICleanupComponentData, IComponentData, IQueryTypeParameter
{
	public Entity GrowTimerEntity;

	public Entity CheckForWaterTimerEntity;
}
