using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using AOT;
using Pathfinding.Collections;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding
{
	[BurstCompile]
	public abstract class Path : IPathInternals
	{
		[BurstCompile]
		public struct SearchContext
		{
			public struct OpenCandidateParams
			{
				public UnsafeSpan<PathNode> pathNodes;

				public uint parentPathNode;

				public uint targetPathNode;

				public uint targetNodeIndex;

				public uint targetG;

				public uint fractionAlongEdge;

				public int3 targetNodePosition;

				public ushort pathID;
			}

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate void OpenCandidateConnectionBurst_00000658_0024PostfixBurstDelegate(ref OpenCandidateParams pars, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective);

			internal static class OpenCandidateConnectionBurst_00000658_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
				}

				private static IntPtr GetFunctionPointer()
				{
					return (IntPtr)0;
				}

				public static void Invoke(ref OpenCandidateParams pars, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective)
				{
				}
			}

			public Path path;

			public PathHandler pathHandler;

			public HeuristicObjective heuristicObjective;

			public TraversalConstraint traversalConstraint;

			public TraversalCosts traversalCosts;

			public ushort pathID;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool ShouldConsiderPathNode(uint pathNodeIndex)
			{
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void SkipOverNode(ref SearchContext ctx, uint pathNodeIndex, uint parentNodeIndex, uint fractionAlongEdge, uint hScore, uint gScore)
			{
			}

			public void OpenCandidateConnectionsToEndNode(Int3 position, uint parentPathNode, uint parentNodeIndex, uint parentG, float traversalCostFactor)
			{
			}

			public void OpenCandidateConnection(uint parentPathNode, uint targetPathNode, uint targetG, uint fractionAlongEdge, Int3 targetNodePosition)
			{
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(OpenCandidateConnectionBurst_00000658_0024PostfixBurstDelegate))]
			public static void OpenCandidateConnectionBurst(ref OpenCandidateParams pars, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective)
			{
			}

			public readonly int3 FirstTemporaryEndNode()
			{
				return default(int3);
			}

			public readonly void TemporaryEndNodesBoundingBox(out int3 mn, out int3 mx)
			{
				mn = default(int3);
				mx = default(int3);
			}

			public void MarkNodesAdjacentToTemporaryEndNodes()
			{
			}

			public void AddStartNodesToHeap()
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			public static void OpenCandidateConnectionBurst_0024BurstManaged(ref OpenCandidateParams pars, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CWaitForPath_003Ed__55 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Path _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitForPath_003Ed__55(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public OnPathDelegate callback;

		public OnPathDelegate immediateCallback;

		protected PathCompleteState completeState;

		public List<GraphNode> path;

		public List<Vector3> vectorPath;

		protected bool hasBeenReset;

		public TraversalCosts traversalCosts;

		public TraversalConstraint traversalConstraint;

		public DistanceMetric nearestNodeDistanceMetric;

		public Heuristic heuristic;

		public float heuristicScale;

		public static readonly ProfilerMarker MarkerOpenCandidateConnectionsToEnd;

		public static readonly ProfilerMarker MarkerTrace;

		private object[] claimed;

		private int claimCount;

		private bool releasedNotSilent;

		public PathState PipelineState { get; private set; }

		[Obsolete("Use path.traversalConstraint.traversalProvider and path.traversalCosts.traversalProvider instead")]
		public ITraversalProvider traversalProvider
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public PathCompleteState CompleteState
		{
			get
			{
				return default(PathCompleteState);
			}
			protected set
			{
			}
		}

		public bool error => false;

		public string errorLog { get; private set; }

		public float duration { get; internal set; }

		public int searchedNodes { get; protected set; }

		bool IPathInternals.Pooled
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		[Obsolete("Use the traversalConstraint field instead. Check the migration guide for version 5.4 for more information.")]
		public NNConstraintPathProxy nnConstraint => null;

		public ushort pathID { get; private set; }

		[Obsolete("Use traversalConstraint.tags instead")]
		public int enabledTags
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Obsolete("Use traversalCosts.tagEntryCosts instead")]
		public uint[] tagPenalties
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public NearestNodeConstraint nearestNodeConstraint => default(NearestNodeConstraint);

		public void UseSettings(PathRequestSettings settings)
		{
		}

		public float GetTotalLength()
		{
			return 0f;
		}

		[IteratorStateMachine(typeof(_003CWaitForPath_003Ed__55))]
		public IEnumerator WaitForPath()
		{
			return null;
		}

		public void BlockUntilCalculated()
		{
		}

		[Obsolete("Use traversalCosts instead")]
		public uint GetTagPenalty(int tag)
		{
			return 0u;
		}

		[Obsolete("Use traversalConstraint.CanTraverse instead")]
		public bool CanTraverse(GraphNode node)
		{
			return false;
		}

		[Obsolete("Use traversalConstraint.CanTraverse instead")]
		public bool CanTraverse(GraphNode from, GraphNode to)
		{
			return false;
		}

		[Obsolete("Use traversalCosts instead", true)]
		public uint GetTraversalCost(GraphNode node)
		{
			return 0u;
		}

		public bool IsDone()
		{
			return false;
		}

		void IPathInternals.AdvanceState(PathState s)
		{
		}

		public void FailWithError(string msg)
		{
		}

		public void Error()
		{
		}

		private void ErrorCheck()
		{
		}

		private void CheckTraversalProviderCompatibility()
		{
		}

		protected virtual void OnEnterPool()
		{
		}

		protected virtual void Reset()
		{
		}

		public void Claim(object o)
		{
		}

		public void Release(object o, bool silent = false)
		{
		}

		protected virtual void Trace(ref SearchContext ctx, uint fromPathNodeIndex)
		{
		}

		protected void Trace(ref SearchContext ctx, uint fromPathNodeIndex, bool reverse)
		{
		}

		protected void DebugStringPrefix(PathLog logMode, StringBuilder text)
		{
		}

		protected void DebugStringSuffix(PathLog logMode, StringBuilder text)
		{
		}

		protected virtual void DebugString(StringBuilder builder, PathLog logMode)
		{
		}

		protected virtual void ReturnPath()
		{
		}

		protected void PrepareBase(PathHandler pathHandler)
		{
		}

		protected abstract void Prepare(ref SearchContext ctx);

		protected virtual void Cleanup(ref SearchContext ctx)
		{
		}

		protected abstract void OnHeapExhausted(ref SearchContext ctx);

		protected abstract void OnFoundEndNode(ref SearchContext ctx, uint pathNode, uint hScore, uint gScore);

		public virtual void OnVisitNode(ref SearchContext ctx, uint pathNode, uint hScore, uint gScore)
		{
		}

		protected virtual void CalculateStep(ref SearchContext ctx, long targetTick)
		{
		}

		void IPathInternals.OnEnterPool()
		{
		}

		void IPathInternals.Reset()
		{
		}

		void IPathInternals.ReturnPath()
		{
		}

		void IPathInternals.PrepareBase(PathHandler handler)
		{
		}

		void IPathInternals.Prepare(ref SearchContext ctx)
		{
		}

		void IPathInternals.Cleanup(ref SearchContext ctx)
		{
		}

		void IPathInternals.CalculateStep(ref SearchContext ctx, long targetTick)
		{
		}

		void IPathInternals.DebugString(StringBuilder builder, PathLog logMode)
		{
		}
	}
}
