using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblAchievementsResultHandle
	{
		internal XGamingRuntime.Interop.XblAchievementsResultHandle InteropHandle { get; set; }

		internal XblAchievementsResultHandle(XGamingRuntime.Interop.XblAchievementsResultHandle interopHandle)
		{
			InteropHandle = interopHandle;
		}
	}
}
