using System;

namespace R3
{
	public abstract class ReadOnlyReactiveProperty<T> : Observable<T>, IDisposable
	{
		public abstract T CurrentValue { get; }

		protected virtual void OnValueChanged(T value)
		{
		}

		protected virtual void OnReceiveError(Exception exception)
		{
		}

		public ReadOnlyReactiveProperty<T> ToReadOnlyReactiveProperty()
		{
			return this;
		}

		public abstract void Dispose();
	}
}
