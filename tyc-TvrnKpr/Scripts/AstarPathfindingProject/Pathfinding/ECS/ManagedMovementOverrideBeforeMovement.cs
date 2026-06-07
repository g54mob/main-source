namespace Pathfinding.ECS
{
	public class ManagedMovementOverrideBeforeMovement : ManagedMovementOverride<BeforeMovementDelegate>
	{
		public object Clone()
		{
			return null;
		}
	}
}
