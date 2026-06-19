using Unity.Entities;

public struct PugTimerUserCD : IComponentData, IQueryTypeParameter
{
	public ComponentType triggerType;
}
