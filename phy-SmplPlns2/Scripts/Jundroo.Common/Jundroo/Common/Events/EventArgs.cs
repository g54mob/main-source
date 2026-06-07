using System;

namespace Jundroo.Common.Events
{
	public class EventArgs<T> : EventArgs
	{
		public T Data { get; }

		public EventArgs(T data)
		{
			Data = data;
		}
	}
}
