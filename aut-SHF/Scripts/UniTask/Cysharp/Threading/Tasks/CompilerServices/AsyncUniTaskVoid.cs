using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Cysharp.Threading.Tasks.CompilerServices
{
	internal sealed class AsyncUniTaskVoid<TStateMachine> : IStateMachineRunner, ITaskPoolNode<AsyncUniTaskVoid<TStateMachine>>, IUniTaskSource where TStateMachine : IAsyncStateMachine
	{
		private static TaskPool<AsyncUniTaskVoid<TStateMachine>> pool;

		private TStateMachine stateMachine;

		private AsyncUniTaskVoid<TStateMachine> nextNode;

		public Action ReturnAction { get; }

		public Action MoveNext { get; }

		public ref AsyncUniTaskVoid<TStateMachine> NextNode
		{
			get
			{
				throw null;
			}
		}

		public static void SetStateMachine(ref TStateMachine stateMachine, ref IStateMachineRunner runnerFieldRef)
		{
		}

		static AsyncUniTaskVoid()
		{
		}

		public void Return()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		private void Run()
		{
		}

		UniTaskStatus IUniTaskSource.GetStatus(short token)
		{
			return default(UniTaskStatus);
		}

		UniTaskStatus IUniTaskSource.UnsafeGetStatus()
		{
			return default(UniTaskStatus);
		}

		void IUniTaskSource.OnCompleted(Action<object> continuation, object state, short token)
		{
		}

		void IUniTaskSource.GetResult(short token)
		{
		}
	}
}
