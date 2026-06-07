using System;

namespace Gh
{
	public class ValueChangedEventArgs<T> : EventArgs
	{
		public T NewValue { get; private set; }

		public T OldValue { get; private set; }

		public ValueChangedEventArgs(T oldValue, T newValue)
		{
		}
	}
}
