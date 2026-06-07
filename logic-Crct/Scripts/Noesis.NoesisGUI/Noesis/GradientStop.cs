using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class GradientStop : Animatable
	{
		public static DependencyProperty ColorProperty => null;

		public static DependencyProperty OffsetProperty => null;

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

		public float Offset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static GradientStop CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal GradientStop(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(GradientStop obj)
		{
			return default(HandleRef);
		}

		public GradientStop()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
