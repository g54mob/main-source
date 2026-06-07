using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BaseDictionary : BaseComponent
	{
		internal new static BaseDictionary CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal BaseDictionary(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(BaseDictionary obj)
		{
			return default(HandleRef);
		}

		protected BaseDictionary()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
