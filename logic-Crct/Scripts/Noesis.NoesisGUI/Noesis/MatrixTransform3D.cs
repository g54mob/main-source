using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class MatrixTransform3D : Transform3D
	{
		public static DependencyProperty MatrixProperty => null;

		public Matrix3D Matrix
		{
			get
			{
				return default(Matrix3D);
			}
			set
			{
			}
		}

		internal new static MatrixTransform3D CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal MatrixTransform3D(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(MatrixTransform3D obj)
		{
			return default(HandleRef);
		}

		public MatrixTransform3D()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public MatrixTransform3D(Matrix3D matrix)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public override Matrix3D GetTransform()
		{
			return default(Matrix3D);
		}
	}
}
