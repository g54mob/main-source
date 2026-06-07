using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblAchievementsResultHandle : EquatableHandle
	{
		internal XGamingRuntime.Interop.XblAchievementsResultHandle InteropHandle { get; set; }

		internal XblAchievementsResultHandle(XGamingRuntime.Interop.XblAchievementsResultHandle interopHandle)
		{
		}

		internal override IntPtr GetInternalPtr()
		{
			return (IntPtr)0;
		}
	}
}
