using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class InputGesture : BaseComponent
	{
		internal new static InputGesture CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal InputGesture(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(InputGesture obj)
		{
			return default(HandleRef);
		}

		protected InputGesture()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public virtual bool Matches(object target, RoutedEventArgs args)
		{
			return false;
		}
	}
}
