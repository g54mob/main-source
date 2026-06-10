using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers
{
	public abstract class AsyncTriggerBase<T> : MonoBehaviour
	{
		private sealed class AsyncTriggerEnumerator : MoveNextSource, IUniTaskAsyncEnumerator<T>, ITriggerHandler<T>
		{
			private static Action<object> cancellationCallback;

			private readonly AsyncTriggerBase<T> parent;

			private CancellationToken cancellationToken;

			private CancellationTokenRegistration registration;

			private bool isDisposed;

			[CompilerGenerated]
			private ITriggerHandler<T> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CT_003E_002EPrev_003Ek__BackingField;

			[CompilerGenerated]
			private ITriggerHandler<T> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CT_003E_002ENext_003Ek__BackingField;

			private T Current
			{
				[CompilerGenerated]
				set
				{
					_003CCurrent_003Ek__BackingField = value;
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

			public AsyncTriggerEnumerator(AsyncTriggerBase<T> parent, CancellationToken cancellationToken)
			{
			}

			public void OnNext(T value)
			{
			}

			public void OnCompleted()
			{
			}

			private static void CancellationCallback(object state)
			{
			}

			public UniTask DisposeAsync()
			{
				return default(UniTask);
			}
		}

		private class AwakeMonitor : IPlayerLoopItem
		{
			private readonly AsyncTriggerBase<T> trigger;

			public AwakeMonitor(AsyncTriggerBase<T> trigger)
			{
			}

			public bool MoveNext()
			{
				return false;
			}
		}

		private TriggerEvent<T> triggerEvent;

		protected internal bool calledAwake;

		protected internal bool calledDestroy;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		internal void AddHandler(ITriggerHandler<T> handler)
		{
		}

		internal void RemoveHandler(ITriggerHandler<T> handler)
		{
		}

		protected void RaiseEvent(T value)
		{
		}

		public IUniTaskAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}
	}
}
