using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Pathfinding.Sync;
using Unity.Profiling;

namespace Pathfinding
{
	public class PathProcessor
	{
		public struct GraphUpdateLock : IDisposable
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

			void IDisposable.Dispose()
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

		internal BlockableChannel<Path> queue;

		private readonly AstarPath astar;

		private readonly PathReturnQueue returnQueue;

		private PathHandler[] pathHandlers;

		private Thread[] threads;

		private bool multithreaded;

		private IEnumerator threadCoroutine;

		private BlockableChannel<Path>.Receiver coroutineReceiver;

		private readonly List<int> locks;

		private int nextLockID;

		private static readonly ProfilerMarker MarkerCalculatePath;

		private static readonly ProfilerMarker MarkerPreparePath;

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

		public void SetThreadCount(int processors, bool multithreaded)
		{
		}

		private void StartThreads()
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

		public void StopThreads()
		{
		}

		public void Dispose()
		{
		}

		private void CalculatePathsThreaded(PathHandler pathHandler, BlockableChannel<Path>.Receiver receiver)
		{
		}

		[IteratorStateMachine(typeof(_003CCalculatePaths_003Ed__36))]
		private IEnumerator CalculatePaths(PathHandler pathHandler)
		{
			return null;
		}
	}
}
