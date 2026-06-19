using Unity.Entities;

public struct IdleStateCD : IComponentData, IQueryTypeParameter
{
	public bool playIdleAnimation;
}
