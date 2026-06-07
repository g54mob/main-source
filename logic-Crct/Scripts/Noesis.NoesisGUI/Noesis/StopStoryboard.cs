using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class StopStoryboard : ControllableStoryboardAction
	{
		internal new static StopStoryboard CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal StopStoryboard(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(StopStoryboard obj)
		{
			return default(HandleRef);
		}

		public StopStoryboard()
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
