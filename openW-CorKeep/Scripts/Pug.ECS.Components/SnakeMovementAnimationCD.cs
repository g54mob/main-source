using Unity.Entities;

public struct SnakeMovementAnimationCD : IComponentData, IQueryTypeParameter
{
	public int currentAnimation;
}
