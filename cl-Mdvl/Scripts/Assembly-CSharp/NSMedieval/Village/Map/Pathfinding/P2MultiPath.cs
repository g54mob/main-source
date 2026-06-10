using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSMedieval.Goap;
using NSMedieval.Utils.Pool;

namespace NSMedieval.Village.Map.Pathfinding
{
	public class P2MultiPath : Path
	{
		private List<Vec3Int> targets;

		private List<List<MapNode>> pathsFound;

		private int targetEndHitCount;

		private int currentEndHitCount;

		private int currentlyCheckingTarget;

		private bool shouldSort;

		public override IEnumerable<Vec3Int> EndPositions
		{
			get
			{
				if (targets == null)
				{
					yield break;
				}
				foreach (Vec3Int target in targets)
				{
					yield return target;
				}
			}
		}

		public event Action<MapNode> OnTargetHitEvent;

		internal P2MultiPath()
			: base(PathType.P2Multi)
		{
		}

		public static P2MultiPath Construct(IPathfindingAgent agent, int endHitCountTarget, List<Vec3Int> targets, bool shouldSort = true)
		{
			if (agent.Map == null)
			{
				throw new Exception("Can not construct path for agent without map. " + agent);
			}
			P2MultiPath p2MultiPath = (P2MultiPath)PathPool.Get(PathType.P2Multi);
			p2MultiPath.Map = agent.Map;
			p2MultiPath.Start = agent.GetGridPosition();
			p2MultiPath.targets = targets;
			p2MultiPath.pathsFound = ListPool<List<MapNode>>.Get();
			p2MultiPath.targetEndHitCount = endHitCountTarget;
			p2MultiPath.shouldSort = shouldSort;
			Path.SetCoreConstructionParameters(agent, p2MultiPath);
			return p2MultiPath;
		}

		protected override bool Initialize(PathProcessor processor)
		{
			if (shouldSort)
			{
				targets.Sort((Vec3Int item1, Vec3Int item2) => Vec3Int.Distance(base.Start, in item1).CompareTo(Vec3Int.Distance(base.Start, in item2)));
			}
			if (targets.Count == 0)
			{
				throw new Exception("P2MultiPath can not start. 0 targets specified.");
			}
			for (int num = 0; num < targets.Count; num++)
			{
				processor.GetSearchNode(targets[num]).TagA = true;
			}
			return base.Initialize(processor);
		}

		protected override void ResetToDefaultState()
		{
			base.NodePath = null;
			targets = null;
			targetEndHitCount = 0;
			shouldSort = false;
			currentEndHitCount = 0;
			currentlyCheckingTarget = 0;
			if (pathsFound != null)
			{
				for (int i = 0; i < pathsFound.Count; i++)
				{
					ListPool<MapNode>.Return(pathsFound[i]);
				}
				ListPool<List<MapNode>>.Return(pathsFound);
				pathsFound = null;
			}
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
				Log.Error("Could not find P2MultiPath start node! " + base.Start.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Path\\P2MultiPath.cs");
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
				MapNode node2 = base.Map.GetNode(targets[currentlyCheckingTarget]);
				SetHTarget(node2);
				PathSearchNode pathSearchNode = ExplorePath(node, processor);
				if (pathSearchNode == null)
				{
					return currentEndHitCount > 0;
				}
				OnHitTarget(currentlyCheckingTarget, pathSearchNode);
				StepToNextTarget();
			}
			while (currentEndHitCount < targetEndHitCount && currentlyCheckingTarget < targets.Count);
			return currentEndHitCount > 0;
		}

		protected override void OnCalculationsDone(PathProcessor processor)
		{
			for (int i = 0; i < targets.Count; i++)
			{
				processor.GetSearchNode(targets[i]).TagA = false;
			}
			List<List<MapNode>> list = pathsFound;
			if (list != null && list.Count > 0)
			{
				base.NodePath = pathsFound[0];
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
				if (targets[i].Equals(position) && (i >= pathsFound.Count || pathsFound[i] == null))
				{
					return true;
				}
			}
			return false;
		}

		private void OnHitTarget(int index, PathSearchNode node)
		{
			currentEndHitCount++;
			TracePath(node);
			if (index >= pathsFound.Count)
			{
				for (int i = pathsFound.Count - 1; i < index; i++)
				{
					pathsFound.Add(null);
				}
			}
			pathsFound[index] = base.NodePath;
			base.NodePath = null;
			this.OnTargetHitEvent?.Invoke(node.Node);
		}

		private void StepToNextTarget()
		{
			for (int i = 0; i < pathsFound.Count; i++)
			{
				if ((i >= pathsFound.Count || pathsFound[i] == null) && !targets[i].Equals(Vec3Int.zero))
				{
					currentlyCheckingTarget = i;
					return;
				}
			}
			currentlyCheckingTarget++;
		}
	}
}
