using Unity.Entities;

public struct WaitingForCastingOpenItemResultCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	public int resultIndex;
}
