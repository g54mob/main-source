using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class LinearSizeKeyFrame : SizeKeyFrame
	{
		internal new static LinearSizeKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal LinearSizeKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(LinearSizeKeyFrame obj)
		{
			return default(HandleRef);
		}

		public LinearSizeKeyFrame()
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
