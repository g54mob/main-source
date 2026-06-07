using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DiscreteInt16KeyFrame : Int16KeyFrame
	{
		internal new static DiscreteInt16KeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DiscreteInt16KeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DiscreteInt16KeyFrame obj)
		{
			return default(HandleRef);
		}

		public DiscreteInt16KeyFrame()
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
