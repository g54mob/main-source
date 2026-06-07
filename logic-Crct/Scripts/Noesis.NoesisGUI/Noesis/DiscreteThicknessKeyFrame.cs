using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DiscreteThicknessKeyFrame : ThicknessKeyFrame
	{
		internal new static DiscreteThicknessKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DiscreteThicknessKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DiscreteThicknessKeyFrame obj)
		{
			return default(HandleRef);
		}

		public DiscreteThicknessKeyFrame()
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
