using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSMedieval.Goap;
using NSMedieval.Utils.Pool;

namespace NSMedieval.Village.Map.Pathfinding
{
	public class P2WorldObjectPath : Path
	{
		private List<WorldObject> targets;

		private List<TargetObject> pathsFound;

		private int targetEndHitCount;

		private int currentEndHitCount;

		private List<PathSearchNode> usedNodes;

		private bool shouldSort;

		public override IEnumerable<Vec3Int> EndPositions
		{
			get
			{
				if (targets == null)
				{
					yield break;
				}
				foreach (WorldObject target in targets)
				{
					yield return target.GetGridPosition();
				}
			}
		}

		public List<TargetObject> PathsFound
		{
			get
			{
				return pathsFound;
			}
			protected set
			{
				pathsFound = value;
			}
		}

		public List<WorldObject> Targets
		{
			get
			{
				return targets;
			}
			protected set
			{
				targets = value;
			}
		}

		protected int TargetEndHitCount
		{
			get
			{
				return targetEndHitCount;
			}
			set
			{
				targetEndHitCount = value;
			}
		}

		protected int CurrentEndHitCount
		{
			get
			{
				return currentEndHitCount;
			}
			set
			{
				currentEndHitCount = value;
			}
		}

		protected List<PathSearchNode> UsedNodes
		{
			get
			{
				return usedNodes;
			}
			set
			{
				usedNodes = value;
			}
		}

		internal P2WorldObjectPath(PathType type = PathType.P2WorldObject)
			: base(type)
		{
		}

		public static P2WorldObjectPath Construct(IPathfindingAgent agent, int endHitCountTarget, List<WorldObject> targets, bool shouldSort = false)
		{
			if (agent.Map == null)
			{
				throw new Exception("Can not construct path for agent without map. " + agent);
			}
			P2WorldObjectPath p2WorldObjectPath = (P2WorldObjectPath)PathPool.Get(PathType.P2WorldObject);
			p2WorldObjectPath.Map = agent.Map;
			p2WorldObjectPath.Start = agent.GetGridPosition();
			p2WorldObjectPath.targets = targets;
			p2WorldObjectPath.pathsFound = ListPool<TargetObject>.Get(targets.Count);
			p2WorldObjectPath.targetEndHitCount = endHitCountTarget;
			p2WorldObjectPath.usedNodes = ListPool<PathSearchNode>.Get(targets.Count * 3);
			p2WorldObjectPath.shouldSort = shouldSort;
			Path.SetCoreConstructionParameters(agent, p2WorldObjectPath);
			return p2WorldObjectPath;
		}

		protected override bool Initialize(PathProcessor processor)
		{
			if (targets.Count == 0)
			{
				throw new Exception("P2WorldObjectPath can not start. 0 targets specified.");
			}
			if (shouldSort)
			{
				targets.Sort((WorldObject item1, WorldObject item2) => Vec3Int.Distance(base.Start, item1.GetGridPosition()).CompareTo(Vec3Int.Distance(base.Start, item2.GetGridPosition())));
			}
			InitializeWorldObjects(processor);
			return base.Initialize(processor);
		}

		protected override void ResetToDefaultState()
		{
			targets = null;
			ListPool<TargetObject>.Return(pathsFound);
			pathsFound = null;
			targetEndHitCount = 0;
			currentEndHitCount = 0;
			ListPool<PathSearchNode>.Return(usedNodes);
			usedNodes = null;
			shouldSort = false;
			base.ResetToDefaultState();
		}

		protected override bool CalculatePath(PathProcessor processor)
		{
			if (base.State != PathState.Processing)
			{
				return false;
			}
			MapNode node = base.Map.GetNode(base.Start);
			if (node == null)
			{
				Log.Error("Could not find P2MultiPath start node! " + base.Start.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Path\\P2WorldObjectPath.cs");
				return false;
			}
			if (targetEndHitCount <= 0)
			{
				targetEndHitCount = targets.Count;
			}
			do
			{
				if (base.State != PathState.Processing)
				{
					return false;
				}
				WorldObject worldObject = targets[0];
				switch (ExploreWorldObjectPath(processor, node))
				{
				case -1:
					return false;
				case 1:
					return true;
				case 0:
					if (targets.Count > 0 && targets[0] == worldObject)
					{
						targets.RemoveAt(0);
					}
					break;
				}
			}
			while (currentEndHitCount < targetEndHitCount && targets.Count > 0);
			return currentEndHitCount > 0;
		}

		protected override void OnCalculationsDone(PathProcessor processor)
		{
			for (int i = 0; i < usedNodes.Count; i++)
			{
				usedNodes[i].TagA = false;
			}
			base.OnCalculationsDone(processor);
		}

		protected override bool IsTargetFound(PathSearchNode node)
		{
			if (!node.TagA)
			{
				return false;
			}
			Vec3Int position = node.Node.Position;
			for (int i = 0; i < targets.Count; i++)
			{
				if (targets[i] != null && !targets[i].HasDisposed && targets[i].ReachablePositions != null && targets[i].ReachablePositions.Contains(position))
				{
					OnHitTarget(targets[i], node);
					targets.RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		protected virtual int ExploreWorldObjectPath(PathProcessor processor, MapNode startNode)
		{
			WorldObject worldObject = targets[0];
			if (worldObject.ReachablePositions == null || worldObject.ReachablePositions.Count == 0)
			{
				return 0;
			}
			using (IEnumerator<Vec3Int> enumerator = worldObject.ReachablePositions.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					Vec3Int current = enumerator.Current;
					MapNode node = base.Map.GetNode(current);
					SetHTarget(node);
					if (ExplorePath(startNode, processor) == null)
					{
						return (currentEndHitCount > 0) ? 1 : (-1);
					}
					return 0;
				}
			}
			if (currentEndHitCount <= 0)
			{
				return -1;
			}
			return 1;
		}

		protected virtual void InitializeWorldObjects(PathProcessor processor)
		{
			for (int i = 0; i < targets.Count; i++)
			{
				if (targets[i] == null || targets[i].HasDisposed || targets[i].ReachablePositions == null)
				{
					continue;
				}
				foreach (Vec3Int reachablePosition in targets[i].ReachablePositions)
				{
					PathSearchNode searchNode = processor.GetSearchNode(reachablePosition);
					searchNode.TagA = true;
					usedNodes.Add(searchNode);
				}
			}
		}

		protected void OnHitTarget(WorldObject obj, PathSearchNode node)
		{
			currentEndHitCount++;
			pathsFound.Add(new TargetObject(obj, node.Node.Position));
		}
	}
}
