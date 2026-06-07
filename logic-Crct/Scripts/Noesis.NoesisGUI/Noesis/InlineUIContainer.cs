using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class InlineUIContainer : Inline
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

		internal new static InlineUIContainer CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal InlineUIContainer(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(InlineUIContainer obj)
		{
			return default(HandleRef);
		}

		public InlineUIContainer()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public InlineUIContainer(UIElement child)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
