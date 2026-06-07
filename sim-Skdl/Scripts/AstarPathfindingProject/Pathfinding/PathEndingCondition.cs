namespace Pathfinding
{
	public abstract class PathEndingCondition
	{
		protected Path path;

		protected PathEndingCondition()
		{
		}

		public PathEndingCondition(Path p)
		{
		}

		public abstract bool TargetFound(PathNode node);
	}
}
