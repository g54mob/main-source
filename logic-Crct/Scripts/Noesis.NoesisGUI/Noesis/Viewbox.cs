using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Viewbox : FrameworkElement
	{
		public static DependencyProperty StretchDirectionProperty => null;

		public static DependencyProperty StretchProperty => null;

		public StretchDirection StretchDirection
		{
			get
			{
				return default(StretchDirection);
			}
			set
			{
			}
		}

		public Stretch Stretch
		{
			get
			{
				return default(Stretch);
			}
			set
			{
			}
		}

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

		internal new static Viewbox CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Viewbox(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Viewbox obj)
		{
			return default(HandleRef);
		}

		public Viewbox()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public static Point GetStretchScale(Size elementSize, Size availableSize, Stretch stretch, StretchDirection stretchDirection)
		{
			return default(Point);
		}

		public static Point GetStretchScale(Size elementSize, Size availableSize, Stretch stretch)
		{
			return default(Point);
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
