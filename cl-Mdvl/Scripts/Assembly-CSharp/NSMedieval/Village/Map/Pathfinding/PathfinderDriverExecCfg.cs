using System;

namespace NSMedieval.Village.Map.Pathfinding
{
	public struct PathfinderDriverExecCfg
	{
		public Path Path { get; set; }

		public Action<bool> StatusCb { get; set; }

		public Action<MapNode, MapNode, PathfinderAgentDriver> OnNodeEnter { get; set; }

		public Action<Path, PathfinderAgentDriver> OnStopMoving { get; set; }

		public Func<MapNode, PathfinderAgentDriver, float> CalcDirectYOffset { get; set; }
	}
}
