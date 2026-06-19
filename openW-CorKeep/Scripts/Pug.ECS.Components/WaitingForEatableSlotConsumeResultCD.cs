using Unity.Entities;

public struct WaitingForEatableSlotConsumeResultCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	public int consumeResultIndex;
}
