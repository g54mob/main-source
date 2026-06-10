using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSMedieval.Goap;
using NSMedieval.Utils.Pool;

namespace NSMedieval.Village.Map.Pathfinding
{
	public class P2GoapTargetable : Path
	{
		private List<IGoapTargetable> targets;

		private List<TargetObject> pathsFound;

		private int targetEndHitCount;

		private int currentEndHitCount;

		private List<PathSearchNode> usedNodes;

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

		public override IEnumerable<Vec3Int> EndPositions
		{
			get
			{
				if (targets == null)
				{
					yield break;
				}
				foreach (IGoapTargetable target in targets)
				{
					yield return target.GetGridPosition();
				}
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

		internal P2GoapTargetable(PathType type = PathType.P2GoapTargetable)
			: base(type)
		{
		}

		public static P2GoapTargetable Construct(IPathfindingAgent agent, int endHitCountTarget, List<IGoapTargetable> targets)
		{
			if (agent.Map == null)
			{
				throw new Exception("Can not construct path for agent without map. " + agent);
			}
			P2GoapTargetable p2GoapTargetable = (P2GoapTargetable)PathPool.Get(PathType.P2GoapTargetable);
			p2GoapTargetable.Map = agent.Map;
			p2GoapTargetable.Start = agent.GetGridPosition();
			p2GoapTargetable.targets = targets;
			p2GoapTargetable.pathsFound = ListPool<TargetObject>.Get(targets.Count);
			p2GoapTargetable.targetEndHitCount = endHitCountTarget;
			p2GoapTargetable.usedNodes = ListPool<PathSearchNode>.Get(targets.Count * 3);
			Path.SetCoreConstructionParameters(agent, p2GoapTargetable);
			return p2GoapTargetable;
		}

		protected override bool Initialize(PathProcessor processor)
		{
			if (targets.Count == 0)
			{
				throw new Exception("P2GoapTargetable can not start. 0 targets specified.");
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
				Log.Error("Could not find P2MultiPath start node! " + base.Start.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Path\\Core\\P2GoapTargetable.cs");
				return false;
			}
			int num = 0;
			while (num < targets.Count)
			{
				MapNode node2 = base.Map.GetNode(targets[num].GetGridPosition());
				if (!PathfinderUtil.IsPathPossible(base.Agent, node2))
				{
					targets.RemoveAt(num);
				}
				else
				{
					num++;
				}
			}
			if (targets.Count == 0)
			{
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
				MapNode node3 = base.Map.GetNode(targets[0].GetGridPosition());
				SetHTarget(node3);
				if (ExplorePath(node, processor) == null)
				{
					return currentEndHitCount > 0;
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
				if (targets[i].GetGridPosition().Equals(position))
				{
					OnHitTarget(targets[i], node);
					targets.RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		protected virtual void InitializeWorldObjects(PathProcessor processor)
		{
			for (int i = 0; i < targets.Count; i++)
			{
				PathSearchNode searchNode = processor.GetSearchNode(targets[i].GetGridPosition());
				searchNode.TagA = true;
				usedNodes.Add(searchNode);
			}
		}

		protected void OnHitTarget(IGoapTargetable obj, PathSearchNode node)
		{
			currentEndHitCount++;
			pathsFound.Add(new TargetObject(obj, node.Node.Position));
		}
	}
}
