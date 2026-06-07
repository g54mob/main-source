using System;

namespace Gh
{
	public class EventArgs<T> : EventArgs
	{
		public T Value { get; private set; }

		public EventArgs(T value)
		{
		}
	}
}
