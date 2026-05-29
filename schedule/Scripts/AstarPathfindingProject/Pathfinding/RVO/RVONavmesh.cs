using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding.RVO
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_r_v_o_1_1_r_v_o_navmesh.php")]
	[AddComponentMenu("Pathfinding/Local Avoidance/RVO Navmesh")]
	public class RVONavmesh : GraphModifier
	{
		public float wallHeight;

		private readonly List<ObstacleVertex> obstacles;

		private Simulator lastSim;

		public override void OnPostCacheLoad()
		{
		}

		public override void OnGraphsPostUpdate()
		{
		}

		public override void OnLatePostScan()
		{
		}

		protected override void OnDisable()
		{
		}

		public void RemoveObstacles()
		{
		}

		private void AddGraphObstacles(Simulator sim, GridGraph grid)
		{
		}

		private void AddGraphObstacles(Simulator simulator, INavmesh navmesh)
		{
		}
	}
}
