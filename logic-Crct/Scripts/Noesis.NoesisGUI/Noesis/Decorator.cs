using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Decorator : FrameworkElement
	{
		public UIElement Child
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static Decorator CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Decorator(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Decorator obj)
		{
			return default(HandleRef);
		}

		public Decorator(bool logicalChild)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public Decorator()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
