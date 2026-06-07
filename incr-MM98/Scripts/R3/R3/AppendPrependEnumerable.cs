using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class AppendPrependEnumerable<T> : Observable<T>
	{
		private sealed class _Append : Observer<T>
		{
			public _Append(Observer<T> observer, IEnumerable<T> values)
			{
				_003Cobserver_003EP = observer;
				_003Cvalues_003EP = values;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cobserver_003EP.OnNext(value);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				if (result.IsFailure)
				{
					_003Cobserver_003EP.OnCompleted(result);
					return;
				}
				if (_003Cvalues_003EP is T[] array)
				{
					T[] array2 = array;
					foreach (T value in array2)
					{
						_003Cobserver_003EP.OnNext(value);
					}
				}
				else
				{
					foreach (T item in _003Cvalues_003EP)
					{
						_003Cobserver_003EP.OnNext(item);
					}
				}
				_003Cobserver_003EP.OnCompleted();
			}
		}

		public AppendPrependEnumerable(Observable<T> source, IEnumerable<T> values, bool append)
		{
			_003Csource_003EP = source;
			_003Cvalues_003EP = values;
			_003Cappend_003EP = append;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			if (!_003Cappend_003EP)
			{
				if (_003Cvalues_003EP is T[] array)
				{
					T[] array2 = array;
					foreach (T value in array2)
					{
						observer.OnNext(value);
					}
				}
				else
				{
					foreach (T item in _003Cvalues_003EP)
					{
						observer.OnNext(item);
					}
				}
				return _003Csource_003EP.Subscribe(observer.Wrap());
			}
			return _003Csource_003EP.Subscribe(new _Append(observer, _003Cvalues_003EP));
		}
	}
}
