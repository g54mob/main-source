using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Noesis
{
	[TypeConverter(typeof(BrushConverter))]
	public class Brush : Animatable
	{
		public static DependencyProperty OpacityProperty => null;

		public static DependencyProperty RelativeTransformProperty => null;

		public static DependencyProperty TransformProperty => null;

		public float Opacity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Transform RelativeTransform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Transform Transform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static Brush CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Brush(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Brush obj)
		{
			return default(HandleRef);
		}

		protected Brush()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public static Brush Parse(string source)
		{
			return null;
		}

		private static IntPtr ParseHelper(string str)
		{
			return (IntPtr)0;
		}
	}
}
