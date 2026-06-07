using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ToolBarOverflowPanel : Panel
	{
		public static DependencyProperty WrapWidthProperty => null;

		public float WrapWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static ToolBarOverflowPanel CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ToolBarOverflowPanel(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ToolBarOverflowPanel obj)
		{
			return default(HandleRef);
		}

		public ToolBarOverflowPanel()
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
