using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TriggerActionCollection : UICollection<TriggerAction>
	{
		internal new static TriggerActionCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TriggerActionCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(TriggerActionCollection obj)
		{
			return default(HandleRef);
		}

		public TriggerActionCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
