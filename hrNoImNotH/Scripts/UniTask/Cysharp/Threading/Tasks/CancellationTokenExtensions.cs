using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks
{
	public static class CancellationTokenExtensions
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CToCancellationTokenCore_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public UniTask task;

			public CancellationTokenSource cts;

			private UniTask.Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private static readonly Action<object> cancellationTokenCallback;

		private static readonly Action<object> disposeCallback;

		public static CancellationToken ToCancellationToken(this UniTask task)
		{
			return default(CancellationToken);
		}

		public static CancellationToken ToCancellationToken(this UniTask task, CancellationToken linkToken)
		{
			return default(CancellationToken);
		}

		public static CancellationToken ToCancellationToken<T>(this UniTask<T> task)
		{
			return default(CancellationToken);
		}

		public static CancellationToken ToCancellationToken<T>(this UniTask<T> task, CancellationToken linkToken)
		{
			return default(CancellationToken);
		}

		[AsyncStateMachine(typeof(_003CToCancellationTokenCore_003Ed__6))]
		private static UniTaskVoid ToCancellationTokenCore(UniTask task, CancellationTokenSource cts)
		{
			return default(UniTaskVoid);
		}

		public static (UniTask, CancellationTokenRegistration) ToUniTask(this CancellationToken cancellationToken)
		{
			return default((UniTask, CancellationTokenRegistration));
		}

		private static void Callback(object state)
		{
		}

		public static CancellationTokenAwaitable WaitUntilCanceled(this CancellationToken cancellationToken)
		{
			return default(CancellationTokenAwaitable);
		}

		public static CancellationTokenRegistration RegisterWithoutCaptureExecutionContext(this CancellationToken cancellationToken, Action callback)
		{
			return default(CancellationTokenRegistration);
		}

		public static CancellationTokenRegistration RegisterWithoutCaptureExecutionContext(this CancellationToken cancellationToken, Action<object> callback, object state)
		{
			return default(CancellationTokenRegistration);
		}

		public static CancellationTokenRegistration AddTo(this IDisposable disposable, CancellationToken cancellationToken)
		{
			return default(CancellationTokenRegistration);
		}

		private static void DisposeCallback(object state)
		{
		}
	}
}
