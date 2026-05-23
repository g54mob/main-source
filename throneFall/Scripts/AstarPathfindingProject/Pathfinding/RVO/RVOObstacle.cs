namespace Pathfinding.RVO
{
	public abstract class RVOObstacle : VersionedMonoBehaviour
	{
		public enum ObstacleVertexWinding
		{
			KeepOut = 0,
			KeepIn = 1
		}

		public ObstacleVertexWinding obstacleMode;

		public RVOLayer layer = RVOLayer.DefaultObstacle;

		protected abstract bool ExecuteInEditor { get; }

		protected abstract bool LocalCoordinates { get; }

		protected abstract bool StaticObstacle { get; }

		protected abstract float Height { get; }
	}
}
