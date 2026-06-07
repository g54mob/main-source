using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Rectangle : Shape
	{
		public static DependencyProperty RadiusXProperty => null;

		public static DependencyProperty RadiusYProperty => null;

		public float RadiusX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RadiusY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static Rectangle CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Rectangle(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Rectangle obj)
		{
			return default(HandleRef);
		}

		public Rectangle()
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
