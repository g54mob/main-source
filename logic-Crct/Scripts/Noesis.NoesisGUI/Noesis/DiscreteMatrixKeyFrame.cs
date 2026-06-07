using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DiscreteMatrixKeyFrame : MatrixKeyFrame
	{
		internal new static DiscreteMatrixKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DiscreteMatrixKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DiscreteMatrixKeyFrame obj)
		{
			return default(HandleRef);
		}

		public DiscreteMatrixKeyFrame()
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
