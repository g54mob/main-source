using System;
using System.ComponentModel;
using System.Threading;

namespace R3
{
	internal sealed class ObservePropertyChanging<T, TProperty> : Observable<TProperty> where T : INotifyPropertyChanging
	{
		private sealed class _ObservePropertyChanging : IDisposable
		{
			private readonly Observer<TProperty> observer;

			private readonly T value;

			private readonly Func<T, TProperty> propertySelector;

			private readonly string propertyName;

			private PropertyChangingEventHandler? eventHandler;

			private CancellationTokenRegistration cancellationTokenRegistration;

			public _ObservePropertyChanging(Observer<TProperty> observer, T value, Func<T, TProperty> propertySelector, string propertyName, CancellationToken cancellationToken)
			{
				this.observer = observer;
				this.value = value;
				this.propertySelector = propertySelector;
				this.propertyName = propertyName;
				eventHandler = PublishOnNext;
				value.PropertyChanging += eventHandler;
				if (cancellationToken.CanBeCanceled)
				{
					cancellationTokenRegistration = cancellationToken.UnsafeRegister(delegate(object? state)
					{
						((_ObservePropertyChanging)state).CompleteDispose();
					}, this);
				}
			}

			private void PublishOnNext(object? sender, PropertyChangingEventArgs e)
			{
				if (e.PropertyName == propertyName)
				{
					TProperty val;
					try
					{
						val = propertySelector(value);
					}
					catch (Exception error)
					{
						observer.OnErrorResume(error);
						return;
					}
					observer.OnNext(val);
				}
			}

			private void CompleteDispose()
			{
				observer.OnCompleted();
				Dispose();
			}

			public void Dispose()
			{
				if (Interlocked.Exchange(ref eventHandler, null) != null)
				{
					cancellationTokenRegistration.Dispose();
					T val = value;
					val.PropertyChanging -= eventHandler;
				}
			}
		}

		public ObservePropertyChanging(T value, Func<T, TProperty> propertySelector, string propertyName, bool pushCurrentValueOnSubscribe, CancellationToken cancellationToken)
		{
			_003Cvalue_003EP = value;
			_003CpropertySelector_003EP = propertySelector;
			_003CpropertyName_003EP = propertyName;
			_003CpushCurrentValueOnSubscribe_003EP = pushCurrentValueOnSubscribe;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TProperty> observer)
		{
			if (_003CpushCurrentValueOnSubscribe_003EP)
			{
				observer.OnNext(_003CpropertySelector_003EP(_003Cvalue_003EP));
			}
			return new _ObservePropertyChanging(observer, _003Cvalue_003EP, _003CpropertySelector_003EP, _003CpropertyName_003EP, _003CcancellationToken_003EP);
		}
	}
}
