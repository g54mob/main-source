using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PauseStoryboard : ControllableStoryboardAction
	{
		internal new static PauseStoryboard CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PauseStoryboard(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(PauseStoryboard obj)
		{
			return default(HandleRef);
		}

		public PauseStoryboard()
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
