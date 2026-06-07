using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TriggerCollection : UICollection<TriggerBase>
	{
		internal new static TriggerCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TriggerCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(TriggerCollection obj)
		{
			return default(HandleRef);
		}

		public TriggerCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
