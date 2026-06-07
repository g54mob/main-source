using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	internal class ExtendListIndexer : BaseComponent
	{
		internal new static ExtendListIndexer CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ExtendListIndexer(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ExtendListIndexer obj)
		{
			return default(HandleRef);
		}

		protected ExtendListIndexer()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
