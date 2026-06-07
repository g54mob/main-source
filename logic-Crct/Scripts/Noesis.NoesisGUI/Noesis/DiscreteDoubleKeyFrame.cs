using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DiscreteDoubleKeyFrame : DoubleKeyFrame
	{
		internal new static DiscreteDoubleKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DiscreteDoubleKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DiscreteDoubleKeyFrame obj)
		{
			return default(HandleRef);
		}

		public DiscreteDoubleKeyFrame()
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
