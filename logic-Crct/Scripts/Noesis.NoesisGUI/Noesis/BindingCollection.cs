using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BindingCollection : UICollection<BindingBase>
	{
		internal new static BindingCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal BindingCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(BindingCollection obj)
		{
			return default(HandleRef);
		}

		public BindingCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
