using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks
{
	public class ReadOnlyAsyncReactiveProperty<T> : IReadOnlyAsyncReactiveProperty<T>, IUniTaskAsyncEnumerable<T>, IDisposable
	{
		private sealed class WaitAsyncSource : IUniTaskSource<T>, IUniTaskSource, ITriggerHandler<T>, ITaskPoolNode<WaitAsyncSource>
		{
			private static Action<object> cancellationCallback;

			private static TaskPool<WaitAsyncSource> pool;

			private WaitAsyncSource nextNode;

			private ReadOnlyAsyncReactiveProperty<T> parent;

			private CancellationToken cancellationToken;

			private CancellationTokenRegistration cancellationTokenRegistration;

			private UniTaskCompletionSourceCore<T> core;

			[CompilerGenerated]
			private ITriggerHandler<T> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CT_003E_002EPrev_003Ek__BackingField;

			[CompilerGenerated]
			private ITriggerHandler<T> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CT_003E_002ENext_003Ek__BackingField;

			ref WaitAsyncSource ITaskPoolNode<WaitAsyncSource>.NextNode
			{
				get
				{
					throw null;
				}
			}

			ITriggerHandler<T> ITriggerHandler<T>.Prev
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
				[CompilerGenerated]
				set
				{
				}
			}

			ITriggerHandler<T> ITriggerHandler<T>.Next
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
				[CompilerGenerated]
				set
				{
				}
			}

			static WaitAsyncSource()
			{
			}

			private WaitAsyncSource()
			{
			}

			public static IUniTaskSource<T> Create(ReadOnlyAsyncReactiveProperty<T> parent, CancellationToken cancellationToken, out short token)
			{
				token = default(short);
				return null;
			}

			private bool TryReturn()
			{
				return false;
			}

			private static void CancellationCallback(object state)
			{
			}

			public T GetResult(short token)
			{
				return default(T);
			}

			void IUniTaskSource.GetResult(short token)
			{
			}

			public void OnCompleted(Action<object> continuation, object state, short token)
			{
			}

			public UniTaskStatus GetStatus(short token)
			{
				return default(UniTaskStatus);
			}

			public UniTaskStatus UnsafeGetStatus()
			{
				return default(UniTaskStatus);
			}

			public void OnCanceled(CancellationToken cancellationToken)
			{
			}

			public void OnCompleted()
			{
			}

			public void OnError(Exception ex)
			{
			}

			public void OnNext(T value)
			{
			}
		}

		private sealed class WithoutCurrentEnumerable : IUniTaskAsyncEnumerable<T>
		{
			private readonly ReadOnlyAsyncReactiveProperty<T> parent;

			public WithoutCurrentEnumerable(ReadOnlyAsyncReactiveProperty<T> parent)
			{
			}

			public IUniTaskAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
			{
				return null;
			}
		}

		private sealed class Enumerator : MoveNextSource, IUniTaskAsyncEnumerator<T>, IUniTaskAsyncDisposable, ITriggerHandler<T>
		{
			private static Action<object> cancellationCallback;

			private readonly ReadOnlyAsyncReactiveProperty<T> parent;

			private readonly CancellationToken cancellationToken;

			private readonly CancellationTokenRegistration cancellationTokenRegistration;

			private T value;

			private bool isDisposed;

			private bool firstCall;

			[CompilerGenerated]
			private ITriggerHandler<T> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CT_003E_002EPrev_003Ek__BackingField;

			[CompilerGenerated]
			private ITriggerHandler<T> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CT_003E_002ENext_003Ek__BackingField;

			public T Current => default(T);

			ITriggerHandler<T> ITriggerHandler<T>.Prev
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
				[CompilerGenerated]
				set
				{
				}
			}

			ITriggerHandler<T> ITriggerHandler<T>.Next
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
				[CompilerGenerated]
				set
				{
				}
			}

			public Enumerator(ReadOnlyAsyncReactiveProperty<T> parent, CancellationToken cancellationToken, bool publishCurrentValue)
			{
			}

			public UniTask<bool> MoveNextAsync()
			{
				return default(UniTask<bool>);
			}

			public UniTask DisposeAsync()
			{
				return default(UniTask);
			}

			public void OnNext(T value)
			{
			}

			public void OnCanceled(CancellationToken cancellationToken)
			{
			}

			public void OnCompleted()
			{
			}

			public void OnError(Exception ex)
			{
			}

			private static void CancellationCallback(object state)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CConsumeEnumerator_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public ReadOnlyAsyncReactiveProperty<T> _003C_003E4__this;

			public IUniTaskAsyncEnumerable<T> source;

			public CancellationToken cancellationToken;

			private object _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

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

		private TriggerEvent<T> triggerEvent;

		private T latestValue;

		private IUniTaskAsyncEnumerator<T> enumerator;

		private static bool isValueType;

		public T Value => default(T);

		public ReadOnlyAsyncReactiveProperty(T initialValue, IUniTaskAsyncEnumerable<T> source, CancellationToken cancellationToken)
		{
		}

		public ReadOnlyAsyncReactiveProperty(IUniTaskAsyncEnumerable<T> source, CancellationToken cancellationToken)
		{
		}

		[AsyncStateMachine(typeof(ReadOnlyAsyncReactiveProperty<>._003CConsumeEnumerator_003Ed__7))]
		private UniTaskVoid ConsumeEnumerator(IUniTaskAsyncEnumerable<T> source, CancellationToken cancellationToken)
		{
			return default(UniTaskVoid);
		}

		public IUniTaskAsyncEnumerable<T> WithoutCurrent()
		{
			return null;
		}

		public IUniTaskAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken)
		{
			return null;
		}

		public void Dispose()
		{
		}

		public static implicit operator T(ReadOnlyAsyncReactiveProperty<T> value)
		{
			return default(T);
		}

		public override string ToString()
		{
			return null;
		}

		public UniTask<T> WaitAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(UniTask<T>);
		}

		static ReadOnlyAsyncReactiveProperty()
		{
		}
	}
}
