using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	internal class ExtendObservableList : BaseComponent
	{
		internal new static ExtendObservableList CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ExtendObservableList(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ExtendObservableList obj)
		{
			return default(HandleRef);
		}

		protected ExtendObservableList()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
