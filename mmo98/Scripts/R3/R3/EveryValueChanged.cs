using System;
using System.Collections.Generic;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class EveryValueChanged<TSource, TProperty> : Observable<TProperty> where TSource : class
	{
		private sealed class EveryValueChangedRunnerWorkItem : CancellableFrameRunnerWorkItemBase<TProperty>
		{
			public EveryValueChangedRunnerWorkItem(Observer<TProperty> observer, TSource source, TProperty previousValue, Func<TSource, TProperty> propertySelector, EqualityComparer<TProperty> equalityComparer, CancellationToken cancellationToken)
			{
				_003Csource_003EP = source;
				_003CpreviousValue_003EP = previousValue;
				_003CpropertySelector_003EP = propertySelector;
				_003CequalityComparer_003EP = equalityComparer;
				base._002Ector(observer, cancellationToken);
			}

			protected override bool MoveNextCore(long _)
			{
				TProperty val;
				try
				{
					val = _003CpropertySelector_003EP(_003Csource_003EP);
				}
				catch (Exception error)
				{
					PublishOnCompleted(error);
					return false;
				}
				if (_003CequalityComparer_003EP.Equals(_003CpreviousValue_003EP, val))
				{
					return true;
				}
				_003CpreviousValue_003EP = val;
				PublishOnNext(val);
				return true;
			}
		}

		public EveryValueChanged(TSource source, Func<TSource, TProperty> propertySelector, FrameProvider frameProvider, EqualityComparer<TProperty> equalityComparer, CancellationToken cancellationToken)
		{
			_003Csource_003EP = source;
			_003CpropertySelector_003EP = propertySelector;
			_003CframeProvider_003EP = frameProvider;
			_003CequalityComparer_003EP = equalityComparer;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TProperty> observer)
		{
			TProperty val = _003CpropertySelector_003EP(_003Csource_003EP);
			observer.OnNext(val);
			if (observer.IsDisposed)
			{
				return Disposable.Empty;
			}
			EveryValueChangedRunnerWorkItem everyValueChangedRunnerWorkItem = new EveryValueChangedRunnerWorkItem(observer, _003Csource_003EP, val, _003CpropertySelector_003EP, _003CequalityComparer_003EP, _003CcancellationToken_003EP);
			_003CframeProvider_003EP.Register(everyValueChangedRunnerWorkItem);
			return everyValueChangedRunnerWorkItem;
		}
	}
}
