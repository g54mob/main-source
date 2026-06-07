using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Transform3D : Animatable
	{
		internal new static Transform3D CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Transform3D(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Transform3D obj)
		{
			return default(HandleRef);
		}

		protected Transform3D()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public virtual Matrix3D GetTransform()
		{
			return default(Matrix3D);
		}
	}
}
