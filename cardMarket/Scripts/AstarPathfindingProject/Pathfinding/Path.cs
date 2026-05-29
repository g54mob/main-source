using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding
{
	[BurstCompile]
	public abstract class Path : IPathInternals
	{
		public struct OpenCandidateParams
		{
			public UnsafeSpan<PathNode> pathNodes;

			public uint parentPathNode;

			public uint targetPathNode;

			public uint targetNodeIndex;

			public uint candidateG;

			public uint fractionAlongEdge;

			public int3 targetNodePosition;

			public ushort pathID;
		}

		public delegate void OpenCandidateConnectionBurst_000004FE_0024PostfixBurstDelegate(ref OpenCandidateParams pars, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective);

		internal static class OpenCandidateConnectionBurst_000004FE_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(OpenCandidateConnectionBurst_000004FE_0024PostfixBurstDelegate).TypeHandle);
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public static void Constructor()
			{
				DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
			}

			public static void Initialize()
			{
			}

			static OpenCandidateConnectionBurst_000004FE_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static void Invoke(ref OpenCandidateParams pars, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref OpenCandidateParams, ref BinaryHeap, ref HeuristicObjective, void>)functionPointer)(ref pars, ref heap, ref heuristicObjective);
						return;
					}
				}
				OpenCandidateConnectionBurst_0024BurstManaged(ref pars, ref heap, ref heuristicObjective);
			}
		}

		protected PathHandler pathHandler;

		public OnPathDelegate callback;

		public OnPathDelegate immediateCallback;

		public ITraversalProvider traversalProvider;

		protected PathCompleteState completeState;

		public List<GraphNode> path;

		public List<Vector3> vectorPath;

		public float duration;

		protected bool hasBeenReset;

		public NNConstraint nnConstraint = PathNNConstraint.Walkable;

		public Heuristic heuristic;

		public float heuristicScale = 1f;

		protected GraphNode hTargetNode;

		protected HeuristicObjective heuristicObjective;

		public int enabledTags = -1;

		internal static readonly int[] ZeroTagPenalties = new int[32];

		protected int[] internalTagPenalties;

		public static readonly ProfilerMarker MarkerOpenCandidateConnectionsToEnd = new ProfilerMarker("OpenCandidateConnectionsToEnd");

		public static readonly ProfilerMarker MarkerTrace = new ProfilerMarker("Trace");

		private List<object> claimed = new List<object>();

		private bool releasedNotSilent;

		public PathState PipelineState { get; private set; }

		public PathCompleteState CompleteState
		{
			get
			{
				return completeState;
			}
			protected set
			{
				lock (this)
				{
					if (completeState != PathCompleteState.Error)
					{
						completeState = value;
					}
				}
			}
		}

		public bool error => CompleteState == PathCompleteState.Error;

		public string errorLog { get; private set; }

		public int searchedNodes { get; protected set; }

		bool IPathInternals.Pooled { get; set; }

		public ushort pathID { get; private set; }

		internal ref HeuristicObjective heuristicObjectiveInternal => ref heuristicObjective;

		public int[] tagPenalties
		{
			get
			{
				if (internalTagPenalties != ZeroTagPenalties)
				{
					return internalTagPenalties;
				}
				return null;
			}
			set
			{
				if (value == null)
				{
					internalTagPenalties = ZeroTagPenalties;
					return;
				}
				if (value.Length != 32)
				{
					throw new ArgumentException("tagPenalties must have a length of 32");
				}
				internalTagPenalties = value;
			}
		}

		PathHandler IPathInternals.PathHandler => pathHandler;

		public void UseSettings(PathRequestSettings settings)
		{
			nnConstraint.graphMask = settings.graphMask;
			traversalProvider = settings.traversalProvider;
			enabledTags = settings.traversableTags;
			tagPenalties = settings.tagPenalties;
		}

		public float GetTotalLength()
		{
			if (vectorPath == null)
			{
				return float.PositiveInfinity;
			}
			float num = 0f;
			for (int i = 0; i < vectorPath.Count - 1; i++)
			{
				num += Vector3.Distance(vectorPath[i], vectorPath[i + 1]);
			}
			return num;
		}

		public IEnumerator WaitForPath()
		{
			if (PipelineState == PathState.Created)
			{
				throw new InvalidOperationException("This path has not been started yet");
			}
			while (PipelineState != PathState.Returned)
			{
				yield return null;
			}
		}

		public void BlockUntilCalculated()
		{
			AstarPath.BlockUntilCalculated(this);
		}

		public bool ShouldConsiderPathNode(uint pathNodeIndex)
		{
			PathNode pathNode = pathHandler.pathNodes[pathNodeIndex];
			if (pathNode.pathID == pathID)
			{
				return pathNode.heapIndex != ushort.MaxValue;
			}
			return true;
		}

		public void OpenCandidateConnectionsToEndNode(Int3 position, uint parentPathNode, uint parentNodeIndex, uint parentG)
		{
			if (!pathHandler.pathNodes[parentNodeIndex].flag1)
			{
				return;
			}
			for (uint num = 0u; num < pathHandler.numTemporaryNodes; num++)
			{
				uint num2 = pathHandler.temporaryNodeStartIndex + num;
				ref TemporaryNode temporaryNode = ref pathHandler.GetTemporaryNode(num2);
				if (temporaryNode.type == TemporaryNodeType.End && temporaryNode.associatedNode == parentNodeIndex)
				{
					uint costMagnitude = (uint)(position - temporaryNode.position).costMagnitude;
					OpenCandidateConnection(parentPathNode, num2, parentG, costMagnitude, 0u, temporaryNode.position);
				}
			}
		}

		public void OpenCandidateConnection(uint parentPathNode, uint targetPathNode, uint parentG, uint connectionCost, uint fractionAlongEdge, Int3 targetNodePosition)
		{
			if (ShouldConsiderPathNode(targetPathNode))
			{
				uint num;
				uint targetNodeIndex;
				if (pathHandler.IsTemporaryNode(targetPathNode))
				{
					num = 0u;
					targetNodeIndex = 0u;
				}
				else
				{
					GraphNode node = pathHandler.GetNode(targetPathNode);
					num = GetTraversalCost(node);
					targetNodeIndex = node.NodeIndex;
				}
				uint candidateG = parentG + connectionCost + num;
				OpenCandidateParams pars = new OpenCandidateParams
				{
					pathID = pathID,
					parentPathNode = parentPathNode,
					targetPathNode = targetPathNode,
					targetNodeIndex = targetNodeIndex,
					candidateG = candidateG,
					fractionAlongEdge = fractionAlongEdge,
					targetNodePosition = (int3)targetNodePosition,
					pathNodes = pathHandler.pathNodes
				};
				OpenCandidateConnectionBurst(ref pars, ref pathHandler.heap, ref heuristicObjective);
			}
		}

		[BurstCompile]
		public static void OpenCandidateConnectionBurst(ref OpenCandidateParams pars, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective)
		{
			OpenCandidateConnectionBurst_000004FE_0024BurstDirectCall.Invoke(ref pars, ref heap, ref heuristicObjective);
		}

		public uint GetTagPenalty(int tag)
		{
			return (uint)internalTagPenalties[tag];
		}

		public bool CanTraverse(GraphNode node)
		{
			if (traversalProvider != null)
			{
				return traversalProvider.CanTraverse(this, node);
			}
			if (node.Walkable)
			{
				return ((enabledTags >> (int)node.Tag) & 1) != 0;
			}
			return false;
		}

		public bool CanTraverse(GraphNode from, GraphNode to)
		{
			if (traversalProvider != null)
			{
				return traversalProvider.CanTraverse(this, from, to);
			}
			if (to.Walkable)
			{
				return ((enabledTags >> (int)to.Tag) & 1) != 0;
			}
			return false;
		}

		public uint GetTraversalCost(GraphNode node)
		{
			if (traversalProvider != null)
			{
				return traversalProvider.GetTraversalCost(this, node);
			}
			return GetTagPenalty((int)node.Tag) + node.Penalty;
		}

		public bool IsDone()
		{
			return PipelineState > PathState.Processing;
		}

		void IPathInternals.AdvanceState(PathState s)
		{
			lock (this)
			{
				PipelineState = (PathState)Math.Max((int)PipelineState, (int)s);
			}
		}

		public void FailWithError(string msg)
		{
			Error();
			if (errorLog != "")
			{
				errorLog = errorLog + "\n" + msg;
			}
			else
			{
				errorLog = msg;
			}
		}

		public void Error()
		{
			CompleteState = PathCompleteState.Error;
		}

		private void ErrorCheck()
		{
			if (!hasBeenReset)
			{
				FailWithError("Please use the static Construct function for creating paths, do not use the normal constructors.");
			}
			if (((IPathInternals)this).Pooled)
			{
				FailWithError("The path is currently in a path pool. Are you sending the path for calculation twice?");
			}
			if (pathHandler == null)
			{
				FailWithError("Field pathHandler is not set. Please report this bug.");
			}
			if (PipelineState > PathState.Processing)
			{
				FailWithError("This path has already been processed. Do not request a path with the same path object twice.");
			}
		}

		protected virtual void OnEnterPool()
		{
			if (vectorPath != null)
			{
				ListPool<Vector3>.Release(ref vectorPath);
			}
			if (path != null)
			{
				ListPool<GraphNode>.Release(ref path);
			}
			callback = null;
			immediateCallback = null;
			traversalProvider = null;
			pathHandler = null;
		}

		protected virtual void Reset()
		{
			if ((object)AstarPath.active == null)
			{
				throw new NullReferenceException("No AstarPath object found in the scene. Make sure there is one or do not create paths in Awake");
			}
			hasBeenReset = true;
			PipelineState = PathState.Created;
			releasedNotSilent = false;
			pathHandler = null;
			callback = null;
			immediateCallback = null;
			errorLog = "";
			completeState = PathCompleteState.NotCalculated;
			path = ListPool<GraphNode>.Claim();
			vectorPath = ListPool<Vector3>.Claim();
			duration = 0f;
			searchedNodes = 0;
			nnConstraint = PathNNConstraint.Walkable;
			heuristic = AstarPath.active.heuristic;
			heuristicScale = AstarPath.active.heuristicScale;
			enabledTags = -1;
			tagPenalties = null;
			pathID = AstarPath.active.GetNextPathID();
			hTargetNode = null;
			traversalProvider = null;
		}

		public void Claim(object o)
		{
			if (o == null)
			{
				throw new ArgumentNullException("o");
			}
			for (int i = 0; i < claimed.Count; i++)
			{
				if (claimed[i] == o)
				{
					throw new ArgumentException("You have already claimed the path with that object (" + o?.ToString() + "). Are you claiming the path with the same object twice?");
				}
			}
			claimed.Add(o);
		}

		public void Release(object o, bool silent = false)
		{
			if (o == null)
			{
				throw new ArgumentNullException("o");
			}
			for (int i = 0; i < claimed.Count; i++)
			{
				if (claimed[i] == o)
				{
					claimed.RemoveAt(i);
					if (!silent)
					{
						releasedNotSilent = true;
					}
					if (claimed.Count == 0 && releasedNotSilent)
					{
						PathPool.Pool(this);
					}
					return;
				}
			}
			if (claimed.Count == 0)
			{
				throw new ArgumentException("You are releasing a path which is not claimed at all (most likely it has been pooled already). Are you releasing the path with the same object (" + o?.ToString() + ") twice?\nCheck out the documentation on path pooling for help.");
			}
			throw new ArgumentException("You are releasing a path which has not been claimed with this object (" + o?.ToString() + "). Are you releasing the path with the same object twice?\nCheck out the documentation on path pooling for help.");
		}

		protected virtual void Trace(uint fromPathNodeIndex)
		{
			uint num = fromPathNodeIndex;
			int num2 = 0;
			UnsafeSpan<PathNode> pathNodes = pathHandler.pathNodes;
			while (num != 0)
			{
				num = pathNodes[num].parentIndex;
				num2++;
				if (num2 > 16384)
				{
					Debug.LogWarning("Infinite loop? >16384 node path. Remove this message if you really have that long paths (Path.cs, Trace method)");
					break;
				}
			}
			if (path.Capacity < num2)
			{
				path.Capacity = num2;
			}
			num = fromPathNodeIndex;
			GraphNode graphNode = null;
			for (int i = 0; i < num2; i++)
			{
				GraphNode graphNode2 = ((!pathHandler.IsTemporaryNode(num)) ? pathHandler.GetNode(num) : pathHandler.GetNode(pathHandler.GetTemporaryNode(num).associatedNode));
				if (graphNode2 != graphNode)
				{
					path.Add(graphNode2);
					graphNode = graphNode2;
				}
				num = pathNodes[num].parentIndex;
			}
			num2 = path.Count;
			int num3 = num2 / 2;
			for (int j = 0; j < num3; j++)
			{
				GraphNode value = path[j];
				path[j] = path[num2 - j - 1];
				path[num2 - j - 1] = value;
			}
			if (vectorPath.Capacity < num2)
			{
				vectorPath.Capacity = num2;
			}
			for (int k = 0; k < num2; k++)
			{
				vectorPath.Add((Vector3)path[k].position);
			}
		}

		protected void DebugStringPrefix(PathLog logMode, StringBuilder text)
		{
			text.Append(error ? "Path Failed : " : "Path Completed : ");
			text.Append("Computation Time ");
			text.Append(duration.ToString((logMode == PathLog.Heavy) ? "0.000 ms " : "0.00 ms "));
			text.Append("Searched Nodes ").Append(searchedNodes);
			if (!error)
			{
				text.Append(" Path Length ");
				text.Append((path == null) ? "Null" : path.Count.ToString());
			}
		}

		protected void DebugStringSuffix(PathLog logMode, StringBuilder text)
		{
			if (error)
			{
				text.Append("\nError: ").Append(errorLog);
			}
			if (logMode == PathLog.Heavy && !AstarPath.active.IsUsingMultithreading)
			{
				text.Append("\nCallback references ");
				if (callback != null)
				{
					text.Append(callback.Target.GetType().FullName).AppendLine();
				}
				else
				{
					text.AppendLine("NULL");
				}
			}
			text.Append("\nPath Number ").Append(pathID).Append(" (unique id)");
		}

		protected virtual string DebugString(PathLog logMode)
		{
			if (logMode == PathLog.None || (!error && logMode == PathLog.OnlyErrors))
			{
				return "";
			}
			StringBuilder debugStringBuilder = pathHandler.DebugStringBuilder;
			debugStringBuilder.Length = 0;
			DebugStringPrefix(logMode, debugStringBuilder);
			DebugStringSuffix(logMode, debugStringBuilder);
			return debugStringBuilder.ToString();
		}

		protected virtual void ReturnPath()
		{
			if (callback != null)
			{
				callback(this);
			}
		}

		protected void PrepareBase(PathHandler pathHandler)
		{
			this.pathHandler = pathHandler;
			pathHandler.InitializeForPath(this);
			if (internalTagPenalties == null || internalTagPenalties.Length != 32)
			{
				internalTagPenalties = ZeroTagPenalties;
			}
			try
			{
				ErrorCheck();
			}
			catch (Exception ex)
			{
				FailWithError(ex.Message);
			}
		}

		protected abstract void Prepare();

		protected virtual void Cleanup()
		{
			UnsafeSpan<PathNode> pathNodes = pathHandler.pathNodes;
			for (uint num = 0u; num < pathHandler.numTemporaryNodes; num++)
			{
				uint nodeIndex = pathHandler.temporaryNodeStartIndex + num;
				ref TemporaryNode temporaryNode = ref pathHandler.GetTemporaryNode(nodeIndex);
				GraphNode node = pathHandler.GetNode(temporaryNode.associatedNode);
				for (uint num2 = 0u; num2 < node.PathNodeVariants; num2++)
				{
					pathNodes[temporaryNode.associatedNode + num2].flag1 = false;
					pathNodes[temporaryNode.associatedNode + num2].flag2 = false;
				}
			}
		}

		protected int3 FirstTemporaryEndNode()
		{
			for (uint num = 0u; num < pathHandler.numTemporaryNodes; num++)
			{
				uint nodeIndex = pathHandler.temporaryNodeStartIndex + num;
				ref TemporaryNode temporaryNode = ref pathHandler.GetTemporaryNode(nodeIndex);
				if (temporaryNode.type == TemporaryNodeType.End)
				{
					return (int3)temporaryNode.position;
				}
			}
			throw new InvalidOperationException("There are no end nodes in the path");
		}

		protected void TemporaryEndNodesBoundingBox(out int3 mn, out int3 mx)
		{
			mn = int.MaxValue;
			mx = int.MinValue;
			for (uint num = 0u; num < pathHandler.numTemporaryNodes; num++)
			{
				uint nodeIndex = pathHandler.temporaryNodeStartIndex + num;
				ref TemporaryNode temporaryNode = ref pathHandler.GetTemporaryNode(nodeIndex);
				if (temporaryNode.type == TemporaryNodeType.End)
				{
					mn = math.min(mn, (int3)temporaryNode.position);
					mx = math.max(mx, (int3)temporaryNode.position);
				}
			}
		}

		protected void MarkNodesAdjacentToTemporaryEndNodes()
		{
			UnsafeSpan<PathNode> pathNodes = pathHandler.pathNodes;
			for (uint num = 0u; num < pathHandler.numTemporaryNodes; num++)
			{
				uint nodeIndex = pathHandler.temporaryNodeStartIndex + num;
				ref TemporaryNode temporaryNode = ref pathHandler.GetTemporaryNode(nodeIndex);
				if (temporaryNode.type == TemporaryNodeType.End)
				{
					GraphNode node = pathHandler.GetNode(temporaryNode.associatedNode);
					for (uint num2 = 0u; num2 < node.PathNodeVariants; num2++)
					{
						pathNodes[temporaryNode.associatedNode + num2].flag1 = true;
					}
				}
			}
		}

		protected void AddStartNodesToHeap()
		{
			UnsafeSpan<PathNode> pathNodes = pathHandler.pathNodes;
			for (uint num = 0u; num < pathHandler.numTemporaryNodes; num++)
			{
				uint num2 = pathHandler.temporaryNodeStartIndex + num;
				if (pathHandler.GetTemporaryNode(num2).type == TemporaryNodeType.Start)
				{
					pathHandler.heap.Add(pathNodes, num2, 0u, 0u);
				}
			}
		}

		protected abstract void OnHeapExhausted();

		protected abstract void OnFoundEndNode(uint pathNode, uint hScore, uint gScore);

		public virtual void OnVisitNode(uint pathNode, uint hScore, uint gScore)
		{
		}

		protected virtual void CalculateStep(long targetTick)
		{
			int num = 0;
			UnsafeSpan<PathNode> pathNodes = pathHandler.pathNodes;
			uint temporaryNodeStartIndex = pathHandler.temporaryNodeStartIndex;
			while (CompleteState == PathCompleteState.NotCalculated)
			{
				searchedNodes++;
				if (pathHandler.heap.isEmpty)
				{
					OnHeapExhausted();
					break;
				}
				uint g;
				uint f;
				uint num2 = pathHandler.heap.Remove(pathNodes, out g, out f);
				uint num3 = f - g;
				if (num2 >= temporaryNodeStartIndex)
				{
					TemporaryNode temporaryNode = pathHandler.GetTemporaryNode(num2);
					if (temporaryNode.type == TemporaryNodeType.Start)
					{
						pathHandler.GetNode(temporaryNode.associatedNode).OpenAtPoint(this, num2, temporaryNode.position, g);
					}
					else if (temporaryNode.type == TemporaryNodeType.End)
					{
						pathHandler.LogVisitedNode(temporaryNode.associatedNode, num3, g);
						OnFoundEndNode(num2, num3, g);
						if (CompleteState == PathCompleteState.Complete)
						{
							break;
						}
					}
				}
				else
				{
					pathHandler.LogVisitedNode(num2, num3, g);
					OnVisitNode(num2, num3, g);
					pathHandler.GetNode(num2).Open(this, num2, g);
				}
				if (num > 500)
				{
					if (DateTime.UtcNow.Ticks >= targetTick)
					{
						break;
					}
					num = 0;
					if (searchedNodes > 1000000)
					{
						throw new Exception("Probable infinite loop. Over 1,000,000 nodes searched");
					}
				}
				num++;
			}
		}

		void IPathInternals.OnEnterPool()
		{
			OnEnterPool();
		}

		void IPathInternals.Reset()
		{
			Reset();
		}

		void IPathInternals.ReturnPath()
		{
			ReturnPath();
		}

		void IPathInternals.PrepareBase(PathHandler handler)
		{
			PrepareBase(handler);
		}

		void IPathInternals.Prepare()
		{
			Prepare();
		}

		void IPathInternals.Cleanup()
		{
			Cleanup();
		}

		void IPathInternals.CalculateStep(long targetTick)
		{
			CalculateStep(targetTick);
		}

		string IPathInternals.DebugString(PathLog logMode)
		{
			return DebugString(logMode);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void OpenCandidateConnectionBurst_0024BurstManaged(ref OpenCandidateParams pars, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective)
		{
			ushort num = pars.pathID;
			uint parentPathNode = pars.parentPathNode;
			uint targetPathNode = pars.targetPathNode;
			uint candidateG = pars.candidateG;
			uint fractionAlongEdge = pars.fractionAlongEdge;
			int3 targetNodePosition = pars.targetNodePosition;
			UnsafeSpan<PathNode> pathNodes = pars.pathNodes;
			ref PathNode reference = ref pathNodes[targetPathNode];
			if (reference.pathID != num)
			{
				reference.fractionAlongEdge = fractionAlongEdge;
				reference.pathID = num;
				reference.parentIndex = parentPathNode;
				uint num2 = (uint)heuristicObjective.Calculate(targetNodePosition, pars.targetNodeIndex);
				uint f = candidateG + num2;
				heap.Add(pathNodes, targetPathNode, candidateG, f);
				return;
			}
			uint g = heap.GetG(reference.heapIndex);
			uint f2 = heap.GetF(reference.heapIndex);
			uint num3 = f2 - g;
			uint num4 = ((reference.fractionAlongEdge == fractionAlongEdge) ? num3 : ((uint)heuristicObjective.Calculate(targetNodePosition, pars.targetNodeIndex)));
			uint num5 = candidateG + num4;
			if (num5 < f2)
			{
				reference.fractionAlongEdge = fractionAlongEdge;
				reference.parentIndex = parentPathNode;
				heap.Add(pathNodes, targetPathNode, candidateG, num5);
			}
		}
	}
}
