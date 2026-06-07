namespace Pathfinding.ECS
{
	public struct MovementTarget
	{
		internal bool isReached;

		public bool reached => false;

		public MovementTarget(bool isReached)
		{
			this.isReached = false;
		}
	}
}
