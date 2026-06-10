using System;
using System.Collections.Generic;
using NSMedieval.BuildingComponents;
using NSMedieval.Goap;
using NSMedieval.Utils.Pool;

namespace NSMedieval.Village.Map.Pathfinding
{
	public class P2ProductionPlacePath : P2WorldObjectPath
	{
		internal P2ProductionPlacePath()
			: base(PathType.P2Production)
		{
		}

		public static P2ProductionPlacePath Construct(IPathfindingAgent agent, int endHitCountTarget, List<WorldObject> targets)
		{
			if (agent.Map == null)
			{
				throw new Exception("Can not construct path for agent without map. " + agent);
			}
			P2ProductionPlacePath p2ProductionPlacePath = (P2ProductionPlacePath)PathPool.Get(PathType.P2Production);
			p2ProductionPlacePath.Map = agent.Map;
			p2ProductionPlacePath.Start = agent.GetGridPosition();
			p2ProductionPlacePath.Targets = targets;
			p2ProductionPlacePath.PathsFound = ListPool<TargetObject>.Get(targets.Count);
			p2ProductionPlacePath.TargetEndHitCount = endHitCountTarget;
			p2ProductionPlacePath.UsedNodes = ListPool<PathSearchNode>.Get(targets.Count * 3);
			Path.SetCoreConstructionParameters(agent, p2ProductionPlacePath);
			return p2ProductionPlacePath;
		}

		protected override void InitializeWorldObjects(PathProcessor processor)
		{
			for (int i = 0; i < base.Targets.Count; i++)
			{
				if (base.Targets[i] == null || base.Targets[i].HasDisposed)
				{
					continue;
				}
				ProductionComponentInstance componentInstance = base.Targets[i].Map.ProductionComponentBuildingManager.GetComponentInstance(base.Targets[i]);
				if (componentInstance == null)
				{
					continue;
				}
				foreach (Vec3Int workplacePosition in componentInstance.WorkplacePositions)
				{
					PathSearchNode searchNode = processor.GetSearchNode(workplacePosition);
					searchNode.TagA = true;
					base.UsedNodes.Add(searchNode);
				}
			}
		}

		protected override int ExploreWorldObjectPath(PathProcessor processor, MapNode startNode)
		{
			using (HashSet<Vec3Int>.Enumerator enumerator = base.Targets[0].Map.ProductionComponentBuildingManager.GetComponentInstance(base.Targets[0]).WorkplacePositions.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					Vec3Int current = enumerator.Current;
					MapNode node = base.Map.GetNode(current);
					SetHTarget(node);
					if (ExplorePath(startNode, processor) == null)
					{
						return (base.CurrentEndHitCount > 0) ? 1 : (-1);
					}
					return 0;
				}
			}
			if (base.CurrentEndHitCount <= 0)
			{
				return -1;
			}
			return 1;
		}

		protected override bool IsTargetFound(PathSearchNode node)
		{
			if (!node.TagA)
			{
				return false;
			}
			Vec3Int position = node.Node.Position;
			for (int i = 0; i < base.Targets.Count; i++)
			{
				if (base.Targets[i].Map.ProductionComponentBuildingManager.GetComponentInstance(base.Targets[i]).WorkplacePositions.Contains(position))
				{
					OnHitTarget(base.Targets[i], node);
					base.Targets.RemoveAt(i);
					return true;
				}
			}
			return false;
		}
	}
}
