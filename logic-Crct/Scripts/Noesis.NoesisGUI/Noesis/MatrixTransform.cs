using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Noesis
{
	[TypeConverter(typeof(TransformConverter))]
	public class MatrixTransform : Transform
	{
		public static DependencyProperty MatrixProperty => null;

		public Matrix Matrix
		{
			get
			{
				return default(Matrix);
			}
			set
			{
			}
		}

		internal new static MatrixTransform CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal MatrixTransform(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(MatrixTransform obj)
		{
			return default(HandleRef);
		}

		public MatrixTransform()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public MatrixTransform(Matrix matrix)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
