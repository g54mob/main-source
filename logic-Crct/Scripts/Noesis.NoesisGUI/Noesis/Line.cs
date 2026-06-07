using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Line : Shape
	{
		public static DependencyProperty X1Property => null;

		public static DependencyProperty Y1Property => null;

		public static DependencyProperty X2Property => null;

		public static DependencyProperty Y2Property => null;

		public float X1
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Y1
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float X2
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Y2
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static Line CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Line(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Line obj)
		{
			return default(HandleRef);
		}

		public Line()
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
