using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RotateTransform : Transform
	{
		public static DependencyProperty AngleProperty => null;

		public static DependencyProperty CenterXProperty => null;

		public static DependencyProperty CenterYProperty => null;

		public float Angle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float CenterX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float CenterY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static RotateTransform CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal RotateTransform(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RotateTransform obj)
		{
			return default(HandleRef);
		}

		public RotateTransform()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public RotateTransform(float angle)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
