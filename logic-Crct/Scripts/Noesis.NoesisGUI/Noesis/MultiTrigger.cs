using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class MultiTrigger : TriggerBase
	{
		public ConditionCollection Conditions => null;

		public SetterBaseCollection Setters => null;

		internal new static MultiTrigger CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal MultiTrigger(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(MultiTrigger obj)
		{
			return default(HandleRef);
		}

		public MultiTrigger()
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
