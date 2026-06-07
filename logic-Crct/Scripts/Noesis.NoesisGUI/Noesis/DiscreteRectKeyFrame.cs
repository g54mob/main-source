using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DiscreteRectKeyFrame : RectKeyFrame
	{
		internal new static DiscreteRectKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DiscreteRectKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DiscreteRectKeyFrame obj)
		{
			return default(HandleRef);
		}

		public DiscreteRectKeyFrame()
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
