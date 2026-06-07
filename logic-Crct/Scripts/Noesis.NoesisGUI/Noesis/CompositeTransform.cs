using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class CompositeTransform : Transform
	{
		public static DependencyProperty CenterXProperty => null;

		public static DependencyProperty CenterYProperty => null;

		public static DependencyProperty RotationProperty => null;

		public static DependencyProperty ScaleXProperty => null;

		public static DependencyProperty ScaleYProperty => null;

		public static DependencyProperty SkewXProperty => null;

		public static DependencyProperty SkewYProperty => null;

		public static DependencyProperty TranslateXProperty => null;

		public static DependencyProperty TranslateYProperty => null;

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

		public float Rotation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

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

		public float SkewX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float SkewY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TranslateX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TranslateY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static CompositeTransform CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal CompositeTransform(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(CompositeTransform obj)
		{
			return default(HandleRef);
		}

		public CompositeTransform()
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
