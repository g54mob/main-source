using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class SkewTransform : Transform
	{
		public static DependencyProperty AngleXProperty => null;

		public static DependencyProperty AngleYProperty => null;

		public static DependencyProperty CenterXProperty => null;

		public static DependencyProperty CenterYProperty => null;

		public float AngleX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float AngleY
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

		internal new static SkewTransform CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal SkewTransform(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(SkewTransform obj)
		{
			return default(HandleRef);
		}

		public SkewTransform()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public SkewTransform(float angleX, float angleY)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
