using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Cysharp.Threading.Tasks.CompilerServices
{
	[StructLayout((LayoutKind)3)]
	public struct AsyncUniTaskVoidMethodBuilder
	{
		private IStateMachineRunner runner;

		public UniTaskVoid Task
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[DebuggerHidden]
			get
			{
				return default(UniTaskVoid);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public static AsyncUniTaskVoidMethodBuilder Create()
		{
			return default(AsyncUniTaskVoidMethodBuilder);
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
