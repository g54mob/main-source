using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class CompositeTransform3D : Transform3D
	{
		public static DependencyProperty CenterXProperty => null;

		public static DependencyProperty CenterYProperty => null;

		public static DependencyProperty CenterZProperty => null;

		public static DependencyProperty RotationXProperty => null;

		public static DependencyProperty RotationYProperty => null;

		public static DependencyProperty RotationZProperty => null;

		public static DependencyProperty ScaleXProperty => null;

		public static DependencyProperty ScaleYProperty => null;

		public static DependencyProperty ScaleZProperty => null;

		public static DependencyProperty TranslateXProperty => null;

		public static DependencyProperty TranslateYProperty => null;

		public static DependencyProperty TranslateZProperty => null;

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

		public float CenterZ
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RotationX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RotationY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RotationZ
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

		public float ScaleZ
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

		public float TranslateZ
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static CompositeTransform3D CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal CompositeTransform3D(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(CompositeTransform3D obj)
		{
			return default(HandleRef);
		}

		public CompositeTransform3D()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public static Matrix3D ConstructTransform3DMatrix(float centerX, float centerY, float centerZ, float rotX, float rotY, float rotZ, float scaleX, float scaleY, float scaleZ, float transX, float transY, float transZ)
		{
			return default(Matrix3D);
		}

		public override Matrix3D GetTransform()
		{
			return default(Matrix3D);
		}
	}
}
