using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;

namespace NSMedieval.Village.Map.Pathfinding.SiegeTraversalProvider
{
	public class SiegePath : Path
	{
		private Vec3Int end;

		public override IEnumerable<Vec3Int> EndPositions
		{
			get
			{
				yield return end;
			}
		}

		public SiegePath()
			: base(PathType.Siege)
		{
		}

		public static SiegePath Construct(Vec3Int gridStart, Vec3Int gridDestination, VillageMap map, PathTraversalProvider traversalProvider)
		{
			if (gridStart.Equals(Vec3Int.zero))
			{
				throw new Exception("Invalid starting position for SiegePath");
			}
			if (gridDestination.Equals(Vec3Int.zero))
			{
				throw new Exception("Invalid destination position for SiegePath");
			}
			if (map == null)
			{
				throw new Exception("Can not construct path without map.");
			}
			SiegePath obj = (SiegePath)PathPool.Get(PathType.Siege);
			obj.Map = map;
			obj.Start = gridStart;
			obj.end = gridDestination;
			obj.State = PathState.Constructed;
			obj.TraversalProvider = traversalProvider;
			return obj;
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
				Log.Error("Could not find node at start position " + base.Start.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Path\\SiegeTraversalProvider\\SiegePath.cs");
				return false;
			}
			if (node2 == null)
			{
				Vec3Int vec3Int = end;
				Log.Error("Could not find node at start position " + vec3Int.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Path\\SiegeTraversalProvider\\SiegePath.cs");
				return false;
			}
			if (!base.TraversalProvider.CanStandOnNode(node2) || !base.TraversalProvider.CanStandOnNode(node))
			{
				return false;
			}
			SetHTarget(node2);
			PathSearchNode pathSearchNode = ExplorePath(node, processor, isConnectionSearch: false);
			if (pathSearchNode == null)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(73, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Path\\SiegeTraversalProvider\\SiegePath.cs");
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
