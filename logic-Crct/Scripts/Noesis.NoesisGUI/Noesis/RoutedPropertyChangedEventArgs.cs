using System;

namespace Noesis
{
	public class RoutedPropertyChangedEventArgs<T> : RoutedEventArgs
	{
		public T OldValue => default(T);

		public T NewValue => default(T);

		internal RoutedPropertyChangedEventArgs(IntPtr cPtr, bool ownMemory)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}
	}
}
