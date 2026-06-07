using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Noesis
{
	[TypeConverter(typeof(TransformConverter))]
	public class Transform : Animatable
	{
		public Matrix Value => default(Matrix);

		public static Transform Identity => null;

		internal new static Transform CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Transform(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Transform obj)
		{
			return default(HandleRef);
		}

		protected Transform()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public static Transform Parse(string source)
		{
			return null;
		}

		private void GetTransformHelper(out Matrix transform)
		{
			transform = default(Matrix);
		}

		private static IntPtr ParseHelper(string str)
		{
			return (IntPtr)0;
		}
	}
}
