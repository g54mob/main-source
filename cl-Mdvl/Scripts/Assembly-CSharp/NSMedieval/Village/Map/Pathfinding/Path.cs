using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Goap;
using NSMedieval.Utils.Pool;

namespace NSMedieval.Village.Map.Pathfinding
{
	public abstract class Path
	{
		private const float Sqrt2 = 1.4142f;

		private const uint StepG = 10u;

		private readonly PathType type;

		private Vec3Int start;

		private List<MapNode> nodePath;

		private PathState state;

		private PathErrorType errorType;

		private VillageMap map;

		private PathTraversalProvider traversalProvider = PathTraversalProvider.DefaultProvider;

		private MapNode heuristicTargetNode;

		private IPathfindingAgent agent;

		private bool isInPool;

		public PathType Type => type;

		public IPathfindingAgent Agent => agent;

		public bool IsInPool => isInPool;

		public Vec3Int Start
		{
			get
			{
				return start;
			}
			protected set
			{
				start = value;
			}
		}

		public abstract IEnumerable<Vec3Int> EndPositions { get; }

		public VillageMap Map
		{
			get
			{
				return map;
			}
			protected set
			{
				map = value;
			}
		}

		public PathTraversalProvider TraversalProvider
		{
			get
			{
				return traversalProvider;
			}
			internal set
			{
				if (value != null)
				{
					traversalProvider = value;
				}
				else
				{
					traversalProvider = PathTraversalProvider.DefaultProvider;
				}
			}
		}

		public PathState State
		{
			get
			{
				return state;
			}
			protected set
			{
				state = value;
			}
		}

		public PathErrorType ErrorType
		{
			get
			{
				return errorType;
			}
			protected set
			{
				errorType = value;
			}
		}

		public List<MapNode> NodePath
		{
			get
			{
				return nodePath;
			}
			protected set
			{
				nodePath = value;
			}
		}

		public event Action<Path> OnCalculationsDoneEvent;

		internal Path(PathType type)
		{
			this.type = type;
			ResetToDefaultState();
		}

		public static void ReleasePath(Path path)
		{
			if (path != null && !path.isInPool)
			{
				path.ResetToDefaultState();
				PathPool.Return(path);
			}
		}

		protected static void SetCoreConstructionParameters(IPathfindingAgent agent, Path path)
		{
			path.agent = agent;
			path.state = PathState.Constructed;
			path.traversalProvider = agent.PathTraversalProvider;
		}

		public virtual void Abort()
		{
			if (state != PathState.Calculated)
			{
				state = PathState.Abort;
			}
		}

		internal void OnRemovedFromPool()
		{
			isInPool = false;
		}

		internal void OnReturnedToPool()
		{
			isInPool = true;
		}

		internal void ExecuteInitialize(PathProcessor processor)
		{
			if (!Initialize(processor))
			{
				Log.Warning("Path initialized with processing error", "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Path\\Core\\Path.cs");
				state = PathState.ProcessingError;
				errorType = PathErrorType.Initialization;
			}
			else
			{
				state = PathState.Initialized;
			}
		}

		internal void ExecutePathCalculations(PathProcessor processor)
		{
			if (state != PathState.Initialized)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(48, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Path\\Core\\Path.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Can not execute path calculations from state: ");
					messageBuilder.AppendFormatted(state);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted(ErrorType);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted(type);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				state = PathState.Processing;
				if (CalculatePath(processor))
				{
					state = PathState.Calculated;
					OnCalculationsDone(processor);
				}
				else if (state == PathState.Abort)
				{
					OnCalculationsDone(processor);
				}
				else
				{
					state = PathState.ProcessingError;
					errorType = PathErrorType.NoPath;
					OnCalculationsDone(processor);
				}
			}
		}

		protected virtual bool Initialize(PathProcessor processor)
		{
			return true;
		}

		protected virtual void ResetToDefaultState()
		{
			start = Vec3Int.zero;
			ListPool<MapNode>.Return(nodePath);
			nodePath = null;
			state = PathState.None;
			errorType = PathErrorType.None;
			map = null;
			traversalProvider = PathTraversalProvider.DefaultProvider;
			heuristicTargetNode = null;
			agent = null;
			this.OnCalculationsDoneEvent = null;
		}

		public void ForceResetToDefaultState()
		{
			ResetToDefaultState();
		}

		protected abstract bool CalculatePath(PathProcessor processor);

		protected virtual void OnCalculationsDone(PathProcessor processor)
		{
			this.OnCalculationsDoneEvent?.Invoke(this);
		}

		protected void SetHTarget(MapNode node)
		{
			heuristicTargetNode = node;
		}

		protected virtual void ForEachConnection(MapNode node, Func<MapNode, bool> callback)
		{
			node.ConnectionsSafeSearch(IterateOperation);
			bool IterateOperation(MapNode connectedNode)
			{
				if (connectedNode == null)
				{
					bool isEnabled;
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(47, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Path\\Core\\Path.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Node: ");
						messageBuilder.AppendFormatted(node.Position);
						messageBuilder.AppendLiteral(" has NULL connection. Index: ");
						messageBuilder.AppendFormatted(node.Index);
						messageBuilder.AppendLiteral(", position: ");
						messageBuilder.AppendFormatted(node.Position);
					}
					Log.Warning(messageBuilder);
					return false;
				}
				if (!TraversalProvider.CanTraverse(connectedNode, node))
				{
					return false;
				}
				if (!callback(connectedNode))
				{
					return true;
				}
				return false;
			}
		}

		protected virtual uint CalculateTravelCost(PathSearchNode start, MapNode end)
		{
			uint num = 10 + traversalProvider.GetTraversalCost(start.Node, end);
			if (start.Parent != null)
			{
				MapNode node = start.Parent.Node;
				if (start.Node.Position - node.Position != end.Position - start.Node.Position && MadeTurnRecently(start, 10u))
				{
					num += 1000;
				}
			}
			if (start.Node.Position.x != end.Position.x && start.Node.Position.z != end.Position.z)
			{
				num = (uint)((float)num * 1.4142f);
			}
			return num;
		}

		private static bool MadeTurnRecently(PathSearchNode currentSearchNode, uint pastNodesCount)
		{
			PathSearchNode pathSearchNode = currentSearchNode.Parent?.Parent;
			PathSearchNode parent = currentSearchNode.Parent;
			PathSearchNode pathSearchNode2 = currentSearchNode;
			for (uint num = 0u; num < pastNodesCount; num++)
			{
				if (pathSearchNode == null || parent == null || pathSearchNode2 == null)
				{
					return false;
				}
				if (parent.Node.Position - pathSearchNode.Node.Position != pathSearchNode2.Node.Position - parent.Node.Position)
				{
					return true;
				}
				pathSearchNode = pathSearchNode.Parent;
				parent = parent.Parent;
				pathSearchNode2 = pathSearchNode2.Parent;
			}
			return false;
		}

		protected virtual uint CalculateHeuristic(MapNode start)
		{
			if (heuristicTargetNode == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(46, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Path\\Core\\Path.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("this.heuristicTargetNode is NULL! Start node: ");
					messageBuilder.AppendFormatted(start?.Position);
				}
				Log.Error(messageBuilder);
			}
			int num = Math.Abs(start.Position.x - heuristicTargetNode.Position.x);
			int num2 = Math.Abs(start.Position.z - heuristicTargetNode.Position.z);
			return (uint)((10 * (num + num2) + -6 * Math.Min(num, num2)) * 100);
		}

		protected PathSearchNode ExplorePath(MapNode startNode, PathProcessor executor, bool isConnectionSearch = true)
		{
			BinaryHeap openList = executor.OpenNodes;
			HashSet<int> closedList = executor.ClosedNodes;
			PathSearchNode searchNode = executor.GetSearchNode(startNode.Index);
			searchNode.HeapIndex = int.MaxValue;
			searchNode.Parent = null;
			searchNode.H = CalculateHeuristic(startNode);
			openList.Add(searchNode);
			PathSearchNode current = null;
			bool flag = false;
			while (!openList.IsEmpty())
			{
				current = openList.Remove();
				closedList.Add(current.Node.Index);
				if (IsTargetFound(current))
				{
					flag = true;
					break;
				}
				if (isConnectionSearch)
				{
					ForEachConnection(current.Node, OpenNewNodes);
				}
				else
				{
					MapNodeUtils.ForEachNeighbour(current.Node, OpenNewNodes);
				}
			}
			if (flag)
			{
				return current;
			}
			return null;
			bool OpenNewNodes(MapNode node)
			{
				if (closedList.Contains(node.Index))
				{
					return true;
				}
				uint num = current.G + CalculateTravelCost(current, node);
				uint num2 = CalculateHeuristic(node);
				PathSearchNode searchNode2 = executor.GetSearchNode(node.Index);
				if (searchNode2.HeapIndex != int.MaxValue)
				{
					uint num3 = num + num2;
					if (searchNode2.F < num3)
					{
						return true;
					}
					if (searchNode2.F == num3 && searchNode2.G < num)
					{
						return true;
					}
				}
				searchNode2.Parent = current;
				searchNode2.G = num;
				searchNode2.H = num2;
				openList.Add(searchNode2);
				return true;
			}
		}

		protected virtual bool IsTargetFound(PathSearchNode node)
		{
			return node.Node == heuristicTargetNode;
		}

		protected void TracePath(PathSearchNode node)
		{
			if (nodePath == null)
			{
				nodePath = ListPool<MapNode>.Get();
			}
			else if (nodePath.Count > 0)
			{
				Log.Error("Aborting path trace. Node path already exist!", "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Path\\Core\\Path.cs");
				return;
			}
			while (node != null)
			{
				nodePath.Add(node.Node);
				node = node.Parent;
			}
		}

		public override string ToString()
		{
			return $"{GetType().Name}, state: {State}";
		}
	}
}
