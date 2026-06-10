using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Goap;

namespace NSMedieval.Village.Map.Pathfinding
{
	public class P2PPath : Path
	{
		private Vec3Int end;

		public Vec3Int End => end;

		public override IEnumerable<Vec3Int> EndPositions
		{
			get
			{
				yield return end;
			}
		}

		internal P2PPath()
			: base(PathType.P2P)
		{
		}

		public static P2PPath Construct(IPathfindingAgent agent, Vec3Int gridDestination)
		{
			if (agent == null)
			{
				return null;
			}
			if (gridDestination.Equals(Vec3Int.zero))
			{
				throw new Exception("Invalid destination");
			}
			if (agent.Map == null)
			{
				throw new Exception("Can not construct path for agent without map. " + agent);
			}
			P2PPath p2PPath = (P2PPath)PathPool.Get(PathType.P2P);
			p2PPath.Map = agent.Map;
			p2PPath.Start = agent.GetGridPosition();
			p2PPath.end = gridDestination;
			Path.SetCoreConstructionParameters(agent, p2PPath);
			return p2PPath;
		}

		protected override void ResetToDefaultState()
		{
			base.Start = (end = Vec3Int.zero);
			base.ResetToDefaultState();
		}

		protected override bool CalculatePath(PathProcessor processor)
		{
			if (base.Start.Equals(Vec3Int.zero) || end.Equals(Vec3Int.zero))
			{
				return false;
			}
			MapNode node = base.Map.GetNode(base.Start);
			MapNode node2 = base.Map.GetNode(end);
			if (node == null)
			{
				Log.Error("Could not find node at start position " + base.Start.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Path\\P2PPath.cs");
				return false;
			}
			if (node2 == null)
			{
				Vec3Int vec3Int = end;
				Log.Error("Could not find node at start position " + vec3Int.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Path\\P2PPath.cs");
				return false;
			}
			if (!base.TraversalProvider.CanTraverse(node2, node))
			{
				return false;
			}
			SetHTarget(node2);
			PathSearchNode pathSearchNode = ExplorePath(node, processor);
			if (pathSearchNode == null)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(73, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Path\\P2PPath.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("IsPathPossible is true but wasn't able to find path, startPos: ");
					messageBuilder.AppendFormatted(node.Position);
					messageBuilder.AppendLiteral(", endPos: ");
					messageBuilder.AppendFormatted(node2.Position);
				}
				Log.Warning(messageBuilder);
				return false;
			}
			TracePath(pathSearchNode);
			return base.NodePath.Count > 0;
		}
	}
}
