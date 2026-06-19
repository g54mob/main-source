using Unity.Entities;

public struct AnimationSpeedCD : IComponentData, IQueryTypeParameter
{
	public float speed;

	public float movementX;

	public float movementY;
}
