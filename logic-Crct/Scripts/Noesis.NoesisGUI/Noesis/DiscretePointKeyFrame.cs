using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DiscretePointKeyFrame : PointKeyFrame
	{
		internal new static DiscretePointKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DiscretePointKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DiscretePointKeyFrame obj)
		{
			return default(HandleRef);
		}

		public DiscretePointKeyFrame()
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
