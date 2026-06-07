using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks
{
	public static class UniTaskExtensions
	{
		private sealed class AttachExternalCancellationSource : IUniTaskSource, IValueTaskSource
		{
			[StructLayout((LayoutKind)3)]
			[CompilerGenerated]
			private struct _003CRunTask_003Ed__5 : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

				public UniTask task;

				public AttachExternalCancellationSource _003C_003E4__this;

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

			private static readonly Action<object> cancellationCallbackDelegate;

			private CancellationToken cancellationToken;

			private CancellationTokenRegistration tokenRegistration;

			private UniTaskCompletionSourceCore<AsyncUnit> core;

			public AttachExternalCancellationSource(UniTask task, CancellationToken cancellationToken)
			{
			}

			[AsyncStateMachine(typeof(_003CRunTask_003Ed__5))]
			private UniTaskVoid RunTask(UniTask task)
			{
				return default(UniTaskVoid);
			}

			private static void CancellationCallback(object state)
			{
			}

			public void GetResult(short token)
			{
			}

			public UniTaskStatus GetStatus(short token)
			{
				return default(UniTaskStatus);
			}

			public void OnCompleted(Action<object> continuation, object state, short token)
			{
			}

			public UniTaskStatus UnsafeGetStatus()
			{
				return default(UniTaskStatus);
			}
		}

		private sealed class AttachExternalCancellationSource<T> : IUniTaskSource<T>, IUniTaskSource, IValueTaskSource, IValueTaskSource<T>
		{
			[StructLayout((LayoutKind)3)]
			[CompilerGenerated]
			private struct _003CRunTask_003Ed__5 : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

				public UniTask<T> task;

				public AttachExternalCancellationSource<T> _003C_003E4__this;

				private UniTask<T>.Awaiter _003C_003Eu__1;

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

			private static readonly Action<object> cancellationCallbackDelegate;

			private CancellationToken cancellationToken;

			private CancellationTokenRegistration tokenRegistration;

			private UniTaskCompletionSourceCore<T> core;

			public AttachExternalCancellationSource(UniTask<T> task, CancellationToken cancellationToken)
			{
			}

			[AsyncStateMachine(typeof(AttachExternalCancellationSource<>._003CRunTask_003Ed__5))]
			private UniTaskVoid RunTask(UniTask<T> task)
			{
				return default(UniTaskVoid);
			}

			private static void CancellationCallback(object state)
			{
			}

			void IUniTaskSource.GetResult(short token)
			{
			}

			public T GetResult(short token)
			{
				return default(T);
			}

			public UniTaskStatus GetStatus(short token)
			{
				return default(UniTaskStatus);
			}

			public void OnCompleted(Action<object> continuation, object state, short token)
			{
			}

			public UniTaskStatus UnsafeGetStatus()
			{
				return default(UniTaskStatus);
			}
		}

		private sealed class ToCoroutineEnumerator : IEnumerator
		{
			[StructLayout((LayoutKind)3)]
			[CompilerGenerated]
			private struct _003CRunTask_003Ed__6 : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

				public UniTask task;

				public ToCoroutineEnumerator _003C_003E4__this;

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

			private bool completed;

			private UniTask task;

			private Action<Exception> exceptionHandler;

			private bool isStarted;

			private ExceptionDispatchInfo exception;

			public object Current => null;

			public ToCoroutineEnumerator(UniTask task, Action<Exception> exceptionHandler)
			{
			}

			[AsyncStateMachine(typeof(_003CRunTask_003Ed__6))]
			private UniTaskVoid RunTask(UniTask task)
			{
				return default(UniTaskVoid);
			}

			public bool MoveNext()
			{
				return false;
			}

			void IEnumerator.Reset()
			{
			}
		}

		private sealed class ToCoroutineEnumerator<T> : IEnumerator
		{
			[StructLayout((LayoutKind)3)]
			[CompilerGenerated]
			private struct _003CRunTask_003Ed__8 : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

				public UniTask<T> task;

				public ToCoroutineEnumerator<T> _003C_003E4__this;

				private UniTask<T>.Awaiter _003C_003Eu__1;

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

			private bool completed;

			private Action<T> resultHandler;

			private Action<Exception> exceptionHandler;

			private bool isStarted;

			private UniTask<T> task;

			private object current;

			private ExceptionDispatchInfo exception;

			public object Current => null;

			public ToCoroutineEnumerator(UniTask<T> task, Action<T> resultHandler, Action<Exception> exceptionHandler)
			{
			}

			[AsyncStateMachine(typeof(ToCoroutineEnumerator<>._003CRunTask_003Ed__8))]
			private UniTaskVoid RunTask(UniTask<T> task)
			{
				return default(UniTaskVoid);
			}

			public bool MoveNext()
			{
				return false;
			}

			void IEnumerator.Reset()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CContinueWith_003Ed__22<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public Action<T> continuationFunction;

			public UniTask<T> task;

			private Action<T> _003C_003E7__wrap1;

			private UniTask<T>.Awaiter _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CContinueWith_003Ed__23<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public Func<T, UniTask> continuationFunction;

			public UniTask<T> task;

			private Func<T, UniTask> _003C_003E7__wrap1;

			private UniTask<T>.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CContinueWith_003Ed__24<T, TR> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<TR> _003C_003Et__builder;

			public Func<T, TR> continuationFunction;

			public UniTask<T> task;

			private Func<T, TR> _003C_003E7__wrap1;

			private UniTask<T>.Awaiter _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CContinueWith_003Ed__25<T, TR> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<TR> _003C_003Et__builder;

			public Func<T, UniTask<TR>> continuationFunction;

			public UniTask<T> task;

			private Func<T, UniTask<TR>> _003C_003E7__wrap1;

			private UniTask<T>.Awaiter _003C_003Eu__1;

			private UniTask<TR>.Awaiter _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CContinueWith_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public UniTask task;

			public Action continuationFunction;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CContinueWith_003Ed__27 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public UniTask task;

			public Func<UniTask> continuationFunction;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CContinueWith_003Ed__28<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<T> _003C_003Et__builder;

			public UniTask task;

			public Func<T> continuationFunction;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CContinueWith_003Ed__29<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<T> _003C_003Et__builder;

			public UniTask task;

			public Func<UniTask<T>> continuationFunction;

			private UniTask.Awaiter _003C_003Eu__1;

			private UniTask<T>.Awaiter _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CForgetCoreWithCatch_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public UniTask task;

			public bool handleExceptionOnMainThread;

			public Action<Exception> exceptionHandler;

			private object _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			private UniTask.Awaiter _003C_003Eu__1;

			private Exception _003Cex_003E5__4;

			private SwitchToMainThreadAwaitable.Awaiter _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CForgetCoreWithCatch_003Ed__21<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public UniTask<T> task;

			public bool handleExceptionOnMainThread;

			public Action<Exception> exceptionHandler;

			private object _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			private UniTask<T>.Awaiter _003C_003Eu__1;

			private Exception _003Cex_003E5__4;

			private SwitchToMainThreadAwaitable.Awaiter _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CTimeout_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public TimeSpan timeout;

			public DelayType delayType;

			public PlayerLoopTiming timeoutCheckTiming;

			public UniTask task;

			public CancellationTokenSource taskCancellationTokenSource;

			private CancellationTokenSource _003CdelayCancellationTokenSource_003E5__2;

			private UniTask<(int winArgumentIndex, bool result1, bool result2)>.Awaiter _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CTimeout_003Ed__13<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<T> _003C_003Et__builder;

			public TimeSpan timeout;

			public DelayType delayType;

			public PlayerLoopTiming timeoutCheckTiming;

			public UniTask<T> task;

			public CancellationTokenSource taskCancellationTokenSource;

			private CancellationTokenSource _003CdelayCancellationTokenSource_003E5__2;

			private UniTask<(int winArgumentIndex, (bool IsCanceled, T Result) result1, bool result2)>.Awaiter _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CTimeoutWithoutException_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			public TimeSpan timeout;

			public DelayType delayType;

			public PlayerLoopTiming timeoutCheckTiming;

			public UniTask task;

			public CancellationTokenSource taskCancellationTokenSource;

			private CancellationTokenSource _003CdelayCancellationTokenSource_003E5__2;

			private UniTask<(int winArgumentIndex, bool result1, bool result2)>.Awaiter _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CTimeoutWithoutException_003Ed__15<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<(bool IsTimeout, T Result)> _003C_003Et__builder;

			public TimeSpan timeout;

			public DelayType delayType;

			public PlayerLoopTiming timeoutCheckTiming;

			public UniTask<T> task;

			public CancellationTokenSource taskCancellationTokenSource;

			private CancellationTokenSource _003CdelayCancellationTokenSource_003E5__2;

			private UniTask<(int winArgumentIndex, (bool IsCanceled, T Result) result1, bool result2)>.Awaiter _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUnwrap_003Ed__30<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<T> _003C_003Et__builder;

			public UniTask<UniTask<T>> task;

			private UniTask<UniTask<T>>.Awaiter _003C_003Eu__1;

			private UniTask<T>.Awaiter _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUnwrap_003Ed__31 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public UniTask<UniTask> task;

			private UniTask<UniTask>.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUnwrap_003Ed__32<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<T> _003C_003Et__builder;

			public Task<UniTask<T>> task;

			private TaskAwaiter<UniTask<T>> _003C_003Eu__1;

			private UniTask<T>.Awaiter _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUnwrap_003Ed__33<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<T> _003C_003Et__builder;

			public Task<UniTask<T>> task;

			public bool continueOnCapturedContext;

			private ConfiguredTaskAwaitable<UniTask<T>>.ConfiguredTaskAwaiter _003C_003Eu__1;

			private UniTask<T>.Awaiter _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUnwrap_003Ed__34 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public Task<UniTask> task;

			private TaskAwaiter<UniTask> _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUnwrap_003Ed__35 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public Task<UniTask> task;

			public bool continueOnCapturedContext;

			private ConfiguredTaskAwaitable<UniTask>.ConfiguredTaskAwaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUnwrap_003Ed__36<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<T> _003C_003Et__builder;

			public UniTask<Task<T>> task;

			private UniTask<Task<T>>.Awaiter _003C_003Eu__1;

			private TaskAwaiter<T> _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUnwrap_003Ed__37<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<T> _003C_003Et__builder;

			public UniTask<Task<T>> task;

			public bool continueOnCapturedContext;

			private UniTask<Task<T>>.Awaiter _003C_003Eu__1;

			private ConfiguredTaskAwaitable<T>.ConfiguredTaskAwaiter _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUnwrap_003Ed__38 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public UniTask<Task> task;

			private UniTask<Task>.Awaiter _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CUnwrap_003Ed__39 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public UniTask<Task> task;

			public bool continueOnCapturedContext;

			private UniTask<Task>.Awaiter _003C_003Eu__1;

			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter _003C_003Eu__2;

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

		public static UniTask<T> AsUniTask<T>(this Task<T> task, bool useCurrentSynchronizationContext = true)
		{
			return default(UniTask<T>);
		}

		public static UniTask AsUniTask(this Task task, bool useCurrentSynchronizationContext = true)
		{
			return default(UniTask);
		}

		public static Task<T> AsTask<T>(this UniTask<T> task)
		{
			return null;
		}

		public static Task AsTask(this UniTask task)
		{
			return null;
		}

		public static AsyncLazy ToAsyncLazy(this UniTask task)
		{
			return null;
		}

		public static AsyncLazy<T> ToAsyncLazy<T>(this UniTask<T> task)
		{
			return null;
		}

		public static UniTask AttachExternalCancellation(this UniTask task, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public static UniTask<T> AttachExternalCancellation<T>(this UniTask<T> task, CancellationToken cancellationToken)
		{
			return default(UniTask<T>);
		}

		public static IEnumerator ToCoroutine<T>(this UniTask<T> task, Action<T> resultHandler = null, Action<Exception> exceptionHandler = null)
		{
			return null;
		}

		public static IEnumerator ToCoroutine(this UniTask task, Action<Exception> exceptionHandler = null)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CTimeout_003Ed__12))]
		public static UniTask Timeout(this UniTask task, TimeSpan timeout, DelayType delayType = DelayType.DeltaTime, PlayerLoopTiming timeoutCheckTiming = PlayerLoopTiming.Update, CancellationTokenSource taskCancellationTokenSource = null)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CTimeout_003Ed__13<>))]
		public static UniTask<T> Timeout<T>(this UniTask<T> task, TimeSpan timeout, DelayType delayType = DelayType.DeltaTime, PlayerLoopTiming timeoutCheckTiming = PlayerLoopTiming.Update, CancellationTokenSource taskCancellationTokenSource = null)
		{
			return default(UniTask<T>);
		}

		[AsyncStateMachine(typeof(_003CTimeoutWithoutException_003Ed__14))]
		public static UniTask<bool> TimeoutWithoutException(this UniTask task, TimeSpan timeout, DelayType delayType = DelayType.DeltaTime, PlayerLoopTiming timeoutCheckTiming = PlayerLoopTiming.Update, CancellationTokenSource taskCancellationTokenSource = null)
		{
			return default(UniTask<bool>);
		}

		[AsyncStateMachine(typeof(_003CTimeoutWithoutException_003Ed__15<>))]
		public static UniTask<(bool, T)> TimeoutWithoutException<T>(this UniTask<T> task, TimeSpan timeout, DelayType delayType = DelayType.DeltaTime, PlayerLoopTiming timeoutCheckTiming = PlayerLoopTiming.Update, CancellationTokenSource taskCancellationTokenSource = null)
		{
			return default(UniTask<(bool, T)>);
		}

		public static void Forget(this UniTask task)
		{
		}

		public static void Forget(this UniTask task, Action<Exception> exceptionHandler, bool handleExceptionOnMainThread = true)
		{
		}

		[AsyncStateMachine(typeof(_003CForgetCoreWithCatch_003Ed__18))]
		private static UniTaskVoid ForgetCoreWithCatch(UniTask task, Action<Exception> exceptionHandler, bool handleExceptionOnMainThread)
		{
			return default(UniTaskVoid);
		}

		public static void Forget<T>(this UniTask<T> task)
		{
		}

		public static void Forget<T>(this UniTask<T> task, Action<Exception> exceptionHandler, bool handleExceptionOnMainThread = true)
		{
		}

		[AsyncStateMachine(typeof(_003CForgetCoreWithCatch_003Ed__21<>))]
		private static UniTaskVoid ForgetCoreWithCatch<T>(UniTask<T> task, Action<Exception> exceptionHandler, bool handleExceptionOnMainThread)
		{
			return default(UniTaskVoid);
		}

		[AsyncStateMachine(typeof(_003CContinueWith_003Ed__22<>))]
		public static UniTask ContinueWith<T>(this UniTask<T> task, Action<T> continuationFunction)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CContinueWith_003Ed__23<>))]
		public static UniTask ContinueWith<T>(this UniTask<T> task, Func<T, UniTask> continuationFunction)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CContinueWith_003Ed__24<, >))]
		public static UniTask<TR> ContinueWith<T, TR>(this UniTask<T> task, Func<T, TR> continuationFunction)
		{
			return default(UniTask<TR>);
		}

		[AsyncStateMachine(typeof(_003CContinueWith_003Ed__25<, >))]
		public static UniTask<TR> ContinueWith<T, TR>(this UniTask<T> task, Func<T, UniTask<TR>> continuationFunction)
		{
			return default(UniTask<TR>);
		}

		[AsyncStateMachine(typeof(_003CContinueWith_003Ed__26))]
		public static UniTask ContinueWith(this UniTask task, Action continuationFunction)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CContinueWith_003Ed__27))]
		public static UniTask ContinueWith(this UniTask task, Func<UniTask> continuationFunction)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CContinueWith_003Ed__28<>))]
		public static UniTask<T> ContinueWith<T>(this UniTask task, Func<T> continuationFunction)
		{
			return default(UniTask<T>);
		}

		[AsyncStateMachine(typeof(_003CContinueWith_003Ed__29<>))]
		public static UniTask<T> ContinueWith<T>(this UniTask task, Func<UniTask<T>> continuationFunction)
		{
			return default(UniTask<T>);
		}

		[AsyncStateMachine(typeof(_003CUnwrap_003Ed__30<>))]
		public static UniTask<T> Unwrap<T>(this UniTask<UniTask<T>> task)
		{
			return default(UniTask<T>);
		}

		[AsyncStateMachine(typeof(_003CUnwrap_003Ed__31))]
		public static UniTask Unwrap(this UniTask<UniTask> task)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CUnwrap_003Ed__32<>))]
		public static UniTask<T> Unwrap<T>(this Task<UniTask<T>> task)
		{
			return default(UniTask<T>);
		}

		[AsyncStateMachine(typeof(_003CUnwrap_003Ed__33<>))]
		public static UniTask<T> Unwrap<T>(this Task<UniTask<T>> task, bool continueOnCapturedContext)
		{
			return default(UniTask<T>);
		}

		[AsyncStateMachine(typeof(_003CUnwrap_003Ed__34))]
		public static UniTask Unwrap(this Task<UniTask> task)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CUnwrap_003Ed__35))]
		public static UniTask Unwrap(this Task<UniTask> task, bool continueOnCapturedContext)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CUnwrap_003Ed__36<>))]
		public static UniTask<T> Unwrap<T>(this UniTask<Task<T>> task)
		{
			return default(UniTask<T>);
		}

		[AsyncStateMachine(typeof(_003CUnwrap_003Ed__37<>))]
		public static UniTask<T> Unwrap<T>(this UniTask<Task<T>> task, bool continueOnCapturedContext)
		{
			return default(UniTask<T>);
		}

		[AsyncStateMachine(typeof(_003CUnwrap_003Ed__38))]
		public static UniTask Unwrap(this UniTask<Task> task)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CUnwrap_003Ed__39))]
		public static UniTask Unwrap(this UniTask<Task> task, bool continueOnCapturedContext)
		{
			return default(UniTask);
		}

		public static UniTask.Awaiter GetAwaiter(this UniTask[] tasks)
		{
			return default(UniTask.Awaiter);
		}

		public static UniTask.Awaiter GetAwaiter(this IEnumerable<UniTask> tasks)
		{
			return default(UniTask.Awaiter);
		}

		public static UniTask<T[]>.Awaiter GetAwaiter<T>(this UniTask<T>[] tasks)
		{
			return default(UniTask<T[]>.Awaiter);
		}

		public static UniTask<T[]>.Awaiter GetAwaiter<T>(this IEnumerable<UniTask<T>> tasks)
		{
			return default(UniTask<T[]>.Awaiter);
		}

		public static UniTask<(T1, T2)>.Awaiter GetAwaiter<T1, T2>(this (UniTask<T1> task1, UniTask<T2> task2) tasks)
		{
			return default(UniTask<(T1, T2)>.Awaiter);
		}

		public static UniTask<(T1, T2, T3)>.Awaiter GetAwaiter<T1, T2, T3>(this (UniTask<T1> task1, UniTask<T2> task2, UniTask<T3> task3) tasks)
		{
			return default(UniTask<(T1, T2, T3)>.Awaiter);
		}

		public static UniTask<(T1, T2, T3, T4)>.Awaiter GetAwaiter<T1, T2, T3, T4>(this (UniTask<T1> task1, UniTask<T2> task2, UniTask<T3> task3, UniTask<T4> task4) tasks)
		{
			return default(UniTask<(T1, T2, T3, T4)>.Awaiter);
		}

		public static UniTask<(T1, T2, T3, T4, T5)>.Awaiter GetAwaiter<T1, T2, T3, T4, T5>(this (UniTask<T1> task1, UniTask<T2> task2, UniTask<T3> task3, UniTask<T4> task4, UniTask<T5> task5) tasks)
		{
			return default(UniTask<(T1, T2, T3, T4, T5)>.Awaiter);
		}

		public static UniTask<(T1, T2, T3, T4, T5, T6)>.Awaiter GetAwaiter<T1, T2, T3, T4, T5, T6>(this (UniTask<T1> task1, UniTask<T2> task2, UniTask<T3> task3, UniTask<T4> task4, UniTask<T5> task5, UniTask<T6> task6) tasks)
		{
			return default(UniTask<(T1, T2, T3, T4, T5, T6)>.Awaiter);
		}

		public static UniTask<(T1, T2, T3, T4, T5, T6, T7)>.Awaiter GetAwaiter<T1, T2, T3, T4, T5, T6, T7>(this (UniTask<T1> task1, UniTask<T2> task2, UniTask<T3> task3, UniTask<T4> task4, UniTask<T5> task5, UniTask<T6> task6, UniTask<T7> task7) tasks)
		{
			return default(UniTask<(T1, T2, T3, T4, T5, T6, T7)>.Awaiter);
		}

		public static UniTask<(T1, T2, T3, T4, T5, T6, T7, T8)>.Awaiter GetAwaiter<T1, T2, T3, T4, T5, T6, T7, T8>(this (UniTask<T1> task1, UniTask<T2> task2, UniTask<T3> task3, UniTask<T4> task4, UniTask<T5> task5, UniTask<T6> task6, UniTask<T7> task7, UniTask<T8> task8) tasks)
		{
			return default(UniTask<(T1, T2, T3, T4, T5, T6, T7, T8)>.Awaiter);
		}

		public static UniTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9)>.Awaiter GetAwaiter<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this (UniTask<T1> task1, UniTask<T2> task2, UniTask<T3> task3, UniTask<T4> task4, UniTask<T5> task5, UniTask<T6> task6, UniTask<T7> task7, UniTask<T8> task8, UniTask<T9> task9) tasks)
		{
			return default(UniTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9)>.Awaiter);
		}

		public static UniTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)>.Awaiter GetAwaiter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this (UniTask<T1> task1, UniTask<T2> task2, UniTask<T3> task3, UniTask<T4> task4, UniTask<T5> task5, UniTask<T6> task6, UniTask<T7> task7, UniTask<T8> task8, UniTask<T9> task9, UniTask<T10> task10) tasks)
		{
			return default(UniTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)>.Awaiter);
		}

		public static UniTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11)>.Awaiter GetAwaiter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this (UniTask<T1> task1, UniTask<T2> task2, UniTask<T3> task3, UniTask<T4> task4, UniTask<T5> task5, UniTask<T6> task6, UniTask<T7> task7, UniTask<T8> task8, UniTask<T9> task9, UniTask<T10> task10, UniTask<T11> task11) tasks)
		{
			return default(UniTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11)>.Awaiter);
		}

		public static UniTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12)>.Awaiter GetAwaiter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this (UniTask<T1> task1, UniTask<T2> task2, UniTask<T3> task3, UniTask<T4> task4, UniTask<T5> task5, UniTask<T6> task6, UniTask<T7> task7, UniTask<T8> task8, UniTask<T9> task9, UniTask<T10> task10, UniTask<T11> task11, UniTask<T12> task12) tasks)
		{
			return default(UniTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12)>.Awaiter);
		}

		public static UniTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13)>.Awaiter GetAwaiter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this (UniTask<T1> task1, UniTask<T2> task2, UniTask<T3> task3, UniTask<T4> task4, UniTask<T5> task5, UniTask<T6> task6, UniTask<T7> task7, UniTask<T8> task8, UniTask<T9> task9, UniTask<T10> task10, UniTask<T11> task11, UniTask<T12> task12, UniTask<T13> task13) tasks)
		{
			return default(UniTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13)>.Awaiter);
		}

		public static UniTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14)>.Awaiter GetAwaiter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this (UniTask<T1> task1, UniTask<T2> task2, UniTask<T3> task3, UniTask<T4> task4, UniTask<T5> task5, UniTask<T6> task6, UniTask<T7> task7, UniTask<T8> task8, UniTask<T9> task9, UniTask<T10> task10, UniTask<T11> task11, UniTask<T12> task12, UniTask<T13> task13, UniTask<T14> task14) tasks)
		{
			return default(UniTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14)>.Awaiter);
		}

		public static UniTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15)>.Awaiter GetAwaiter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this (UniTask<T1> task1, UniTask<T2> task2, UniTask<T3> task3, UniTask<T4> task4, UniTask<T5> task5, UniTask<T6> task6, UniTask<T7> task7, UniTask<T8> task8, UniTask<T9> task9, UniTask<T10> task10, UniTask<T11> task11, UniTask<T12> task12, UniTask<T13> task13, UniTask<T14> task14, UniTask<T15> task15) tasks)
		{
			return default(UniTask<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15)>.Awaiter);
		}

		public static UniTask.Awaiter GetAwaiter(this (UniTask task1, UniTask task2) tasks)
		{
			return default(UniTask.Awaiter);
		}

		public static UniTask.Awaiter GetAwaiter(this (UniTask task1, UniTask task2, UniTask task3) tasks)
		{
			return default(UniTask.Awaiter);
		}

		public static UniTask.Awaiter GetAwaiter(this (UniTask task1, UniTask task2, UniTask task3, UniTask task4) tasks)
		{
			return default(UniTask.Awaiter);
		}

		public static UniTask.Awaiter GetAwaiter(this (UniTask task1, UniTask task2, UniTask task3, UniTask task4, UniTask task5) tasks)
		{
			return default(UniTask.Awaiter);
		}

		public static UniTask.Awaiter GetAwaiter(this (UniTask task1, UniTask task2, UniTask task3, UniTask task4, UniTask task5, UniTask task6) tasks)
		{
			return default(UniTask.Awaiter);
		}

		public static UniTask.Awaiter GetAwaiter(this (UniTask task1, UniTask task2, UniTask task3, UniTask task4, UniTask task5, UniTask task6, UniTask task7) tasks)
		{
			return default(UniTask.Awaiter);
		}

		public static UniTask.Awaiter GetAwaiter(this (UniTask task1, UniTask task2, UniTask task3, UniTask task4, UniTask task5, UniTask task6, UniTask task7, UniTask task8) tasks)
		{
			return default(UniTask.Awaiter);
		}

		public static UniTask.Awaiter GetAwaiter(this (UniTask task1, UniTask task2, UniTask task3, UniTask task4, UniTask task5, UniTask task6, UniTask task7, UniTask task8, UniTask task9) tasks)
		{
			return default(UniTask.Awaiter);
		}

		public static UniTask.Awaiter GetAwaiter(this (UniTask task1, UniTask task2, UniTask task3, UniTask task4, UniTask task5, UniTask task6, UniTask task7, UniTask task8, UniTask task9, UniTask task10) tasks)
		{
			return default(UniTask.Awaiter);
		}

		public static UniTask.Awaiter GetAwaiter(this (UniTask task1, UniTask task2, UniTask task3, UniTask task4, UniTask task5, UniTask task6, UniTask task7, UniTask task8, UniTask task9, UniTask task10, UniTask task11) tasks)
		{
			return default(UniTask.Awaiter);
		}

		public static UniTask.Awaiter GetAwaiter(this (UniTask task1, UniTask task2, UniTask task3, UniTask task4, UniTask task5, UniTask task6, UniTask task7, UniTask task8, UniTask task9, UniTask task10, UniTask task11, UniTask task12) tasks)
		{
			return default(UniTask.Awaiter);
		}

		public static UniTask.Awaiter GetAwaiter(this (UniTask task1, UniTask task2, UniTask task3, UniTask task4, UniTask task5, UniTask task6, UniTask task7, UniTask task8, UniTask task9, UniTask task10, UniTask task11, UniTask task12, UniTask task13) tasks)
		{
			return default(UniTask.Awaiter);
		}

		public static UniTask.Awaiter GetAwaiter(this (UniTask task1, UniTask task2, UniTask task3, UniTask task4, UniTask task5, UniTask task6, UniTask task7, UniTask task8, UniTask task9, UniTask task10, UniTask task11, UniTask task12, UniTask task13, UniTask task14) tasks)
		{
			return default(UniTask.Awaiter);
		}

		public static UniTask.Awaiter GetAwaiter(this (UniTask task1, UniTask task2, UniTask task3, UniTask task4, UniTask task5, UniTask task6, UniTask task7, UniTask task8, UniTask task9, UniTask task10, UniTask task11, UniTask task12, UniTask task13, UniTask task14, UniTask task15) tasks)
		{
			return default(UniTask.Awaiter);
		}
	}
}
