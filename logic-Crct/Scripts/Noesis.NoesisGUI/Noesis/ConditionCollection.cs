using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ConditionCollection : UICollection<Condition>
	{
		internal new static ConditionCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ConditionCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(ConditionCollection obj)
		{
			return default(HandleRef);
		}

		public ConditionCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
