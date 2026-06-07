using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Cysharp.Threading.Tasks.CompilerServices
{
	[StructLayout((LayoutKind)3)]
	public struct AsyncUniTaskMethodBuilder
	{
		private IStateMachineRunnerPromise runnerPromise;

		private Exception ex;

		public UniTask Task
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[DebuggerHidden]
			get
			{
				return default(UniTask);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public static AsyncUniTaskMethodBuilder Create()
		{
			return default(AsyncUniTaskMethodBuilder);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public void SetException(Exception exception)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public void SetResult()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
		{
		}

		[DebuggerHidden]
		public void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}
	[StructLayout((LayoutKind)3)]
	public struct AsyncUniTaskMethodBuilder<T>
	{
		private IStateMachineRunnerPromise<T> runnerPromise;

		private Exception ex;

		private T result;

		public UniTask<T> Task
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[DebuggerHidden]
			get
			{
				return default(UniTask<T>);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public static AsyncUniTaskMethodBuilder<T> Create()
		{
			return default(AsyncUniTaskMethodBuilder<T>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public void SetException(Exception exception)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public void SetResult(T result)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
		{
		}

		[DebuggerHidden]
		public void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}
}
