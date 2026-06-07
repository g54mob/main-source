using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblSocialManagerUserGroupHandle : EquatableHandle
	{
		internal XGamingRuntime.Interop.XblSocialManagerUserGroupHandle InteropHandle { get; set; }

		internal XblSocialManagerUserGroupHandle(XGamingRuntime.Interop.XblSocialManagerUserGroupHandle interopHandle)
		{
		}

		internal static int WrapAndReturnHResult(int hresult, XGamingRuntime.Interop.XblSocialManagerUserGroupHandle interopHandle, out XblSocialManagerUserGroupHandle handle)
		{
			handle = null;
			return 0;
		}

		internal void ClearInteropHandle()
		{
		}

		internal override IntPtr GetInternalPtr()
		{
			return (IntPtr)0;
		}
	}
}
