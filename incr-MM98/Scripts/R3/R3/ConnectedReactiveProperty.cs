using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class ConnectedReactiveProperty<T> : ReactiveProperty<T>
	{
		private class Observer : Observer<T>
		{
			public Observer(ConnectedReactiveProperty<T> parent)
			{
				_003Cparent_003EP = parent;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cparent_003EP.Value = value;
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cparent_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				_003Cparent_003EP.OnCompleted(result);
			}
		}

		private readonly IDisposable sourceSubscription;

		public ConnectedReactiveProperty(Observable<T> source, T initialValue, IEqualityComparer<T>? equalityComparer)
			: base(initialValue, equalityComparer)
		{
			sourceSubscription = source.Subscribe(new Observer(this));
		}

		protected override void DisposeCore()
		{
			sourceSubscription.Dispose();
		}
	}
}
