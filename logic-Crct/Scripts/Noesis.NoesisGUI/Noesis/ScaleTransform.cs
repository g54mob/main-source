using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ScaleTransform : Transform
	{
		public static DependencyProperty CenterXProperty => null;

		public static DependencyProperty CenterYProperty => null;

		public static DependencyProperty ScaleXProperty => null;

		public static DependencyProperty ScaleYProperty => null;

		public float ScaleX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ScaleY
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

		internal new static ScaleTransform CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ScaleTransform(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ScaleTransform obj)
		{
			return default(HandleRef);
		}

		public ScaleTransform()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public ScaleTransform(float scaleX, float scaleY)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
