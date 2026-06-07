using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class InlineCollection : UICollection<Inline>
	{
		internal new static InlineCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal InlineCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(InlineCollection obj)
		{
			return default(HandleRef);
		}

		public InlineCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
