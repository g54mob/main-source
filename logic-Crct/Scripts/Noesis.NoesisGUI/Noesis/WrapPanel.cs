using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class WrapPanel : Panel
	{
		public static DependencyProperty ItemWidthProperty => null;

		public static DependencyProperty ItemHeightProperty => null;

		public static DependencyProperty OrientationProperty => null;

		public float ItemWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ItemHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Orientation Orientation
		{
			get
			{
				return default(Orientation);
			}
			set
			{
			}
		}

		internal new static WrapPanel CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal WrapPanel(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(WrapPanel obj)
		{
			return default(HandleRef);
		}

		public WrapPanel()
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
