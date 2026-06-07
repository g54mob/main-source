using System;

namespace MiscUtil
{
	public class EventArgs<T> : EventArgs
	{
		private readonly T value;

		public T Value => value;

		public EventArgs(T value)
		{
			this.value = value;
		}
	}
}
