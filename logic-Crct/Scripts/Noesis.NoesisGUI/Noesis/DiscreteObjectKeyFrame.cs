using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DiscreteObjectKeyFrame : ObjectKeyFrame
	{
		internal new static DiscreteObjectKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DiscreteObjectKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DiscreteObjectKeyFrame obj)
		{
			return default(HandleRef);
		}

		public DiscreteObjectKeyFrame()
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
