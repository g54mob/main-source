using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblContextHandle : EquatableHandle
	{
		public XGamingRuntime.Interop.XblContextHandle InteropHandle { get; set; }

		public XblContextHandle(XGamingRuntime.Interop.XblContextHandle interopHandle)
		{
		}

		internal override IntPtr GetInternalPtr()
		{
			return (IntPtr)0;
		}
	}
}
