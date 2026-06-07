using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks.Linq
{
	internal sealed class Publish<TSource> : IConnectableUniTaskAsyncEnumerable<TSource>, IUniTaskAsyncEnumerable<TSource>
	{
		private sealed class ConnectDisposable : IDisposable
		{
			private readonly CancellationTokenSource cancellationTokenSource;

			public ConnectDisposable(CancellationTokenSource cancellationTokenSource)
			{
			}

			public void Dispose()
			{
			}
		}

		private sealed class _Publish : MoveNextSource, IUniTaskAsyncEnumerator<TSource>, IUniTaskAsyncDisposable, ITriggerHandler<TSource>
		{
			private static readonly Action<object> CancelDelegate;

			private readonly Publish<TSource> parent;

			private CancellationToken cancellationToken;

			private CancellationTokenRegistration cancellationTokenRegistration;

			private bool isDisposed;

			[CompilerGenerated]
			private ITriggerHandler<TSource> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CTSource_003E_002EPrev_003Ek__BackingField;

			[CompilerGenerated]
			private ITriggerHandler<TSource> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CTSource_003E_002ENext_003Ek__BackingField;

			public TSource Current { get; private set; }

			ITriggerHandler<TSource> ITriggerHandler<TSource>.Prev
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

			ITriggerHandler<TSource> ITriggerHandler<TSource>.Next
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

			public _Publish(Publish<TSource> parent, CancellationToken cancellationToken)
			{
			}

			public UniTask<bool> MoveNextAsync()
			{
				return default(UniTask<bool>);
			}

			private static void OnCanceled(object state)
			{
			}

			public UniTask DisposeAsync()
			{
				return default(UniTask);
			}

			public void OnNext(TSource value)
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
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CConsumeEnumerator_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public Publish<TSource> _003C_003E4__this;

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

		private readonly IUniTaskAsyncEnumerable<TSource> source;

		private readonly CancellationTokenSource cancellationTokenSource;

		private TriggerEvent<TSource> trigger;

		private IUniTaskAsyncEnumerator<TSource> enumerator;

		private IDisposable connectedDisposable;

		private bool isCompleted;

		public Publish(IUniTaskAsyncEnumerable<TSource> source)
		{
		}

		public IDisposable Connect()
		{
			return null;
		}

		[AsyncStateMachine(typeof(Publish<>._003CConsumeEnumerator_003Ed__8))]
		private UniTaskVoid ConsumeEnumerator()
		{
			return default(UniTaskVoid);
		}

		public IUniTaskAsyncEnumerator<TSource> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}
	}
}
