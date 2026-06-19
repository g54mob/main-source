using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;

public struct ClientInputHistoryCD : IComponentData, IQueryTypeParameter
{
	public float2 targetingDirection;

	public float2 aimDirection;

	public float2 joystickDirection;

	public Direction facingDirection;

	public bool interactBlockedUntilRelease;

	public bool secondInteractBlockedUntilRelease;

	public bool useOffHandBlockedUntilRelease;

	public bool secondInteractUITriggered;
}
