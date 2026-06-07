using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class VisualBrush : TileBrush
	{
		public static DependencyProperty VisualProperty => null;

		public Visual Visual
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static VisualBrush CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal VisualBrush(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(VisualBrush obj)
		{
			return default(HandleRef);
		}

		public VisualBrush()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
