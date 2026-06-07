using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DiscreteStringKeyFrame : StringKeyFrame
	{
		internal new static DiscreteStringKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DiscreteStringKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DiscreteStringKeyFrame obj)
		{
			return default(HandleRef);
		}

		public DiscreteStringKeyFrame()
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
