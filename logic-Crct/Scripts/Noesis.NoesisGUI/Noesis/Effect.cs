using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Effect : Animatable
	{
		internal new static Effect CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Effect(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Effect obj)
		{
			return default(HandleRef);
		}

		protected Effect()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
