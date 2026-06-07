using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ItemsChangedEventArgs : EventArgs
	{
		private HandleRef swigCPtr;

		public NotifyCollectionChangedAction Action => default(NotifyCollectionChangedAction);

		public GeneratorPosition Position => default(GeneratorPosition);

		public GeneratorPosition OldPosition => default(GeneratorPosition);

		public int ItemCount => 0;

		public int ItemUICount => 0;

		internal ItemsChangedEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ItemsChangedEventArgs obj)
		{
			return default(HandleRef);
		}

		~ItemsChangedEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		public ItemsChangedEventArgs(NotifyCollectionChangedAction action, GeneratorPosition position, GeneratorPosition oldPosition, int itemCount, int itemUICount)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public ItemsChangedEventArgs(NotifyCollectionChangedAction action, GeneratorPosition position, int itemCount, int itemUICount)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private static IntPtr CreateHelper1(int action, GeneratorPosition position, GeneratorPosition oldPosition, int itemCount, int itemUICount)
		{
			return (IntPtr)0;
		}

		private static IntPtr CreateHelper2(int action, GeneratorPosition position, int itemCount, int itemUICount)
		{
			return (IntPtr)0;
		}

		private int GetActionHelper()
		{
			return 0;
		}
	}
}
