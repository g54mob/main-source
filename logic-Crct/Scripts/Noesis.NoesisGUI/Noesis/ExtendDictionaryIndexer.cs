using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	internal class ExtendDictionaryIndexer : BaseComponent
	{
		internal new static ExtendDictionaryIndexer CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ExtendDictionaryIndexer(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ExtendDictionaryIndexer obj)
		{
			return default(HandleRef);
		}

		protected ExtendDictionaryIndexer()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
