using System;
using System.Threading;
using UnityEngine;

namespace R3.Triggers
{
	[DisallowMultipleComponent]
	public class ObservableDestroyTrigger : MonoBehaviour, IFrameRunnerWorkItem
	{
		private bool calledDestroy;

		private Subject<Unit> onDestroy;

		private CancellationTokenSource cancellationTokenSource;

		private DisposableBag disposableBag;

		private bool isMonitoring;

		public bool IsActivated { get; private set; }

		public CancellationToken GetCancellationToken()
		{
			if (cancellationTokenSource == null)
			{
				cancellationTokenSource = new CancellationTokenSource();
				if (calledDestroy)
				{
					cancellationTokenSource.Cancel();
				}
			}
			return cancellationTokenSource.Token;
		}

		public void AddDisposableOnDestroy(IDisposable disposable)
		{
			if (calledDestroy)
			{
				disposable.Dispose();
			}
			else
			{
				disposableBag.Add(disposable);
			}
		}

		private void Awake()
		{
			IsActivated = true;
		}

		private void OnDestroy()
		{
			if (!calledDestroy)
			{
				calledDestroy = true;
				if (cancellationTokenSource != null)
				{
					cancellationTokenSource.Cancel();
				}
				disposableBag.Dispose();
				if (onDestroy != null)
				{
					onDestroy.OnNext(Unit.Default);
					onDestroy.OnCompleted();
				}
			}
		}

		public Observable<Unit> OnDestroyAsObservable()
		{
			if (this == null)
			{
				return Observable.Return(Unit.Default);
			}
			if (calledDestroy)
			{
				return Observable.Return(Unit.Default);
			}
			return onDestroy ?? (onDestroy = new Subject<Unit>());
		}

		internal void TryStartActivateMonitoring()
		{
			if (!isMonitoring)
			{
				isMonitoring = true;
				UnityFrameProvider.Update.Register(this);
			}
		}

		bool IFrameRunnerWorkItem.MoveNext(long frameCount)
		{
			if (IsActivated)
			{
				return false;
			}
			if (this == null)
			{
				OnDestroy();
				return false;
			}
			return true;
		}
	}
}
