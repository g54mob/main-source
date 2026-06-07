using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public abstract class MarkupExtension : BaseComponent
	{
		internal MarkupExtension(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(MarkupExtension obj)
		{
			return default(HandleRef);
		}

		protected MarkupExtension()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public abstract object ProvideValue(IServiceProvider serviceProvider);

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
