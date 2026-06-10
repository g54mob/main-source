using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSMedieval.Goap;
using NSMedieval.Model;

namespace NSMedieval.Village.Map.Pathfinding
{
	public class FleePath : Path
	{
		private const int FleePathBestNodeSearchLimitAtCount = 15;

		private List<Vec3Int> avoidPositions;

		private float minFleeDistance;

		private PathSearchNode bestNode;

		private int bestNodeFoundCount;

		private PathSearchNode secondBestNode;

		private float secondBestNodeDistance;

		private PathfindingPenalty agentPenaltyModelCache;

		public override IEnumerable<Vec3Int> EndPositions
		{
			get
			{
				yield return default(Vec3Int);
			}
		}

		internal FleePath()
			: base(PathType.Flee)
		{
		}

		public static FleePath Construct(IPathfindingAgent agent, List<Vec3Int> avoidPositions, float minFleeDistance)
		{
			if (avoidPositions == null || avoidPositions.Count == 0)
			{
				throw new Exception("No positions to avoid specified");
			}
			if (agent.Map == null)
			{
				throw new Exception("Can not construct path for agent without map. " + agent);
			}
			FleePath fleePath = (FleePath)PathPool.Get(PathType.Flee);
			fleePath.Map = agent.Map;
			fleePath.Start = agent.GetGridPosition();
			fleePath.avoidPositions = avoidPositions;
			fleePath.minFleeDistance = minFleeDistance;
			fleePath.agentPenaltyModelCache = agent.WalkableModel.PathfindingPenalty;
			Path.SetCoreConstructionParameters(agent, fleePath);
			return fleePath;
		}

		protected override void ResetToDefaultState()
		{
			avoidPositions = null;
			bestNodeFoundCount = 0;
			bestNode = null;
			secondBestNode = null;
			secondBestNodeDistance = float.MinValue;
			agentPenaltyModelCache = null;
			base.ResetToDefaultState();
		}

		protected override uint CalculateHeuristic(MapNode start)
		{
			int index = -1;
			float num = 2.1474836E+09f;
			for (int i = 0; i < avoidPositions.Count; i++)
			{
				float num2 = Vec3Int.Distance(avoidPositions[i], start.Position);
				if (num2 < num)
				{
					num = num2;
					index = i;
				}
			}
			Vec3Int vec3Int = avoidPositions[index];
			int num3 = Math.Abs(start.Position.x - vec3Int.x);
			int num4 = Math.Abs(start.Position.z - vec3Int.z);
			return (uint)((25 - (10 * (num3 + num4) + -6 * Math.Min(num3, num4))) * 100 + start.GetPenalty(agentPenaltyModelCache));
		}

		protected override bool IsTargetFound(PathSearchNode node)
		{
			float num = Vec3Int.Distance(base.Start, node.Node.Position);
			if (num < minFleeDistance)
			{
				if (bestNode != null)
				{
					return false;
				}
				if (secondBestNode == null || (secondBestNodeDistance < num && secondBestNode.F < node.F))
				{
					secondBestNodeDistance = num;
					secondBestNode = node;
				}
				return false;
			}
			if (bestNode == null)
			{
				bestNode = node;
				bestNodeFoundCount++;
				return false;
			}
			if (node.F < bestNode.F)
			{
				bestNode = node;
			}
			bestNodeFoundCount++;
			return bestNodeFoundCount >= 15;
		}

		protected override bool CalculatePath(PathProcessor processor)
		{
			if (base.Start.Equals(Vec3Int.zero))
			{
				return false;
			}
			MapNode node = base.Map.GetNode(base.Start);
			if (node == null)
			{
				Log.Error("Could not find node at start position " + base.Start.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Path\\FleePath.cs");
				return false;
			}
			if (!base.TraversalProvider.CanStandOnNode(node))
			{
				return false;
			}
			ExplorePath(node, processor);
			if (bestNode != null)
			{
				TracePath(bestNode);
				return base.NodePath.Count > 0;
			}
			if (secondBestNode != null)
			{
				TracePath(secondBestNode);
				return base.NodePath.Count > 0;
			}
			int num = -1;
			float num2 = float.MinValue;
			foreach (int closedNode in processor.ClosedNodes)
			{
				MapNode mapNode = base.Map.GridSpaceData[closedNode];
				Region region = mapNode.Region;
				if (region == null || !region.Attribute.HasFlag(RegionAttribute.Danger))
				{
					float num3 = Vec3Int.Distance(mapNode.Position, base.Agent.GetGridPosition());
					if (num3 > num2)
					{
						num2 = num3;
						num = closedNode;
					}
				}
			}
			if (num > -1)
			{
				TracePath(processor.GetSearchNode(num));
				return base.NodePath.Count > 0;
			}
			return false;
		}
	}
}
