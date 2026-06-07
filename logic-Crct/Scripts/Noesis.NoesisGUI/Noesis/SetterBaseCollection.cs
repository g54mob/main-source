using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class SetterBaseCollection : UICollection<SetterBase>
	{
		internal new static SetterBaseCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal SetterBaseCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(SetterBaseCollection obj)
		{
			return default(HandleRef);
		}

		public SetterBaseCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
