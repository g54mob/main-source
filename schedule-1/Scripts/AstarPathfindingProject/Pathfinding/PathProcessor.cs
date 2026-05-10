using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine.Profiling;

namespace Pathfinding
{
	public class PathProcessor
	{
		public struct GraphUpdateLock
		{
			private PathProcessor pathProcessor;

			private int id;

			public bool Held => false;

			public GraphUpdateLock(PathProcessor pathProcessor, bool block)
			{
				this.pathProcessor = null;
				id = 0;
			}

			public void Release()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CCalculatePaths_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PathProcessor _003C_003E4__this;

			public PathHandler pathHandler;

			private long _003CmaxTicks_003E5__2;

			private long _003CtargetTick_003E5__3;

			private Path _003Cp_003E5__4;

			private bool _003CblockedBefore_003E5__5;

			private IPathInternals _003Cip_003E5__6;

			private long _003CtotalTicks_003E5__7;

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
			public _003CCalculatePaths_003Ed__36(int _003C_003E1__state)
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

		internal readonly ThreadControlQueue queue;

		private readonly AstarPath astar;

		private readonly PathReturnQueue returnQueue;

		private readonly PathHandler[] pathHandlers;

		private readonly Thread[] threads;

		private IEnumerator threadCoroutine;

		private int nextNodeIndex;

		private readonly Stack<int> nodeIndexPool;

		private readonly List<int> locks;

		private int nextLockID;

		private CustomSampler profilingSampler;

		public int NumThreads => 0;

		public bool IsUsingMultithreading => false;

		public event Action<Path> OnPathPreSearch
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<Path> OnPathPostSearch
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnQueueUnblocked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		internal PathProcessor(AstarPath astar, PathReturnQueue returnQueue, int processors, bool multithreaded)
		{
		}

		private int Lock(bool block)
		{
			return 0;
		}

		private void Unlock(int id)
		{
		}

		public GraphUpdateLock PausePathfinding(bool block)
		{
			return default(GraphUpdateLock);
		}

		public void TickNonMultithreaded()
		{
		}

		public void JoinThreads()
		{
		}

		public void AbortThreads()
		{
		}

		public int GetNewNodeIndex()
		{
			return 0;
		}

		public void InitializeNode(GraphNode node)
		{
		}

		public void DestroyNode(GraphNode node)
		{
		}

		private void CalculatePathsThreaded(PathHandler pathHandler)
		{
		}

		[IteratorStateMachine(typeof(_003CCalculatePaths_003Ed__36))]
		private IEnumerator CalculatePaths(PathHandler pathHandler)
		{
			return null;
		}
	}
}
