using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class MultiDataTrigger : TriggerBase
	{
		public ConditionCollection Conditions => null;

		public SetterBaseCollection Setters => null;

		internal new static MultiDataTrigger CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal MultiDataTrigger(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(MultiDataTrigger obj)
		{
			return default(HandleRef);
		}

		public MultiDataTrigger()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
