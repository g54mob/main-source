using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Noesis
{
	[TypeConverter(typeof(BrushConverter))]
	public class SolidColorBrush : Brush
	{
		public static DependencyProperty ColorProperty => null;

		public Color Color
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		internal new static SolidColorBrush CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal SolidColorBrush(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(SolidColorBrush obj)
		{
			return default(HandleRef);
		}

		public SolidColorBrush()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public SolidColorBrush(Color color)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
