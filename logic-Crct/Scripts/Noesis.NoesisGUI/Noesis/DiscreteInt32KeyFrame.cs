using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DiscreteInt32KeyFrame : Int32KeyFrame
	{
		internal new static DiscreteInt32KeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DiscreteInt32KeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DiscreteInt32KeyFrame obj)
		{
			return default(HandleRef);
		}

		public DiscreteInt32KeyFrame()
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
