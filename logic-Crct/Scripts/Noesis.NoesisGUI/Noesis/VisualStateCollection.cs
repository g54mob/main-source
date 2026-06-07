using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class VisualStateCollection : UICollection<VisualState>
	{
		internal new static VisualStateCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal VisualStateCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(VisualStateCollection obj)
		{
			return default(HandleRef);
		}

		public VisualStateCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
