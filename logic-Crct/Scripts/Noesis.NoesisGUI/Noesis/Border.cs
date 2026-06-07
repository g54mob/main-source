using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Border : Decorator
	{
		public static DependencyProperty BackgroundProperty => null;

		public static DependencyProperty BorderBrushProperty => null;

		public static DependencyProperty BorderThicknessProperty => null;

		public static DependencyProperty CornerRadiusProperty => null;

		public static DependencyProperty PaddingProperty => null;

		public Brush Background
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Brush BorderBrush
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Thickness BorderThickness
		{
			get
			{
				return default(Thickness);
			}
			set
			{
			}
		}

		public CornerRadius CornerRadius
		{
			get
			{
				return default(CornerRadius);
			}
			set
			{
			}
		}

		public Thickness Padding
		{
			get
			{
				return default(Thickness);
			}
			set
			{
			}
		}

		internal new static Border CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Border(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Border obj)
		{
			return default(HandleRef);
		}

		public Border(bool logicalChild)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public Border()
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
