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

		[CompilerGenerated]
		private sealed class _003CWaitForPath_003Ed__49 : IEnumerator<object>, IEnumerator, IDisposable
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
			public _003CWaitForPath_003Ed__49(int _003C_003E1__state)
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

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void OpenCandidateConnectionBurst_000004FA_0024PostfixBurstDelegate(ref OpenCandidateParams pars, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective);

		internal static class OpenCandidateConnectionBurst_000004FA_0024BurstDirectCall
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

		protected PathHandler pathHandler;

		public OnPathDelegate callback;

		public OnPathDelegate immediateCallback;

		public ITraversalProvider traversalProvider;

		protected PathCompleteState completeState;

		public List<GraphNode> path;

		public List<Vector3> vectorPath;

		public float duration;

		protected bool hasBeenReset;

		public NNConstraint nnConstraint;

		public Heuristic heuristic;

		public float heuristicScale;

		protected GraphNode hTargetNode;

		protected HeuristicObjective heuristicObjective;

		public int enabledTags;

		internal static readonly int[] ZeroTagPenalties;

		protected int[] internalTagPenalties;

		public static readonly ProfilerMarker MarkerOpenCandidateConnectionsToEnd;

		public static readonly ProfilerMarker MarkerTrace;

		private List<object> claimed;

		private bool releasedNotSilent;

		public PathState PipelineState { get; private set; }

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

		public ushort pathID { get; private set; }

		internal ref HeuristicObjective heuristicObjectiveInternal
		{
			get
			{
				throw null;
			}
		}

		public int[] tagPenalties
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		PathHandler IPathInternals.PathHandler => null;

		public void UseSettings(PathRequestSettings settings)
		{
		}

		public float GetTotalLength()
		{
			return 0f;
		}

		[IteratorStateMachine(typeof(_003CWaitForPath_003Ed__49))]
		public IEnumerator WaitForPath()
		{
			return null;
		}

		public void BlockUntilCalculated()
		{
		}

		public bool ShouldConsiderPathNode(uint pathNodeIndex)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SkipOverNode(uint pathNodeIndex, uint parentNodeIndex, uint fractionAlongEdge, uint hScore, uint gScore)
		{
		}

		public void OpenCandidateConnectionsToEndNode(Int3 position, uint parentPathNode, uint parentNodeIndex, uint parentG)
		{
		}

		public void OpenCandidateConnection(uint parentPathNode, uint targetPathNode, uint parentG, uint connectionCost, uint fractionAlongEdge, Int3 targetNodePosition)
		{
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(OpenCandidateConnectionBurst_000004FA_0024PostfixBurstDelegate))]
		public static void OpenCandidateConnectionBurst(ref OpenCandidateParams pars, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective)
		{
		}

		public uint GetTagPenalty(int tag)
		{
			return 0u;
		}

		public bool CanTraverse(GraphNode node)
		{
			return false;
		}

		public bool CanTraverse(GraphNode from, GraphNode to)
		{
			return false;
		}

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

		protected virtual void Trace(uint fromPathNodeIndex)
		{
		}

		protected void Trace(uint fromPathNodeIndex, bool reverse)
		{
		}

		protected void DebugStringPrefix(PathLog logMode, StringBuilder text)
		{
		}

		protected void DebugStringSuffix(PathLog logMode, StringBuilder text)
		{
		}

		protected virtual string DebugString(PathLog logMode)
		{
			return null;
		}

		protected virtual void ReturnPath()
		{
		}

		private void InitializeNNConstraint()
		{
		}

		protected NNInfo GetNearest(Vector3 point)
		{
			return default(NNInfo);
		}

		protected void PrepareBase(PathHandler pathHandler)
		{
		}

		protected abstract void Prepare();

		protected virtual void Cleanup()
		{
		}

		protected int3 FirstTemporaryEndNode()
		{
			return default(int3);
		}

		protected void TemporaryEndNodesBoundingBox(out int3 mn, out int3 mx)
		{
			mn = default(int3);
			mx = default(int3);
		}

		protected void MarkNodesAdjacentToTemporaryEndNodes()
		{
		}

		protected void AddStartNodesToHeap()
		{
		}

		protected abstract void OnHeapExhausted();

		protected abstract void OnFoundEndNode(uint pathNode, uint hScore, uint gScore);

		public virtual void OnVisitNode(uint pathNode, uint hScore, uint gScore)
		{
		}

		protected virtual void CalculateStep(long targetTick)
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

		void IPathInternals.Prepare()
		{
		}

		void IPathInternals.Cleanup()
		{
		}

		void IPathInternals.CalculateStep(long targetTick)
		{
		}

		string IPathInternals.DebugString(PathLog logMode)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void OpenCandidateConnectionBurst_0024BurstManaged(ref OpenCandidateParams pars, ref BinaryHeap heap, ref HeuristicObjective heuristicObjective)
		{
		}
	}
}
