using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class AdornerDecorator : Decorator
	{
		internal new static AdornerDecorator CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal AdornerDecorator(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(AdornerDecorator obj)
		{
			return default(HandleRef);
		}

		public AdornerDecorator(bool logicalChild)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public AdornerDecorator()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public AdornerLayer GetAdornerLayer()
		{
			return null;
		}
	}
}
