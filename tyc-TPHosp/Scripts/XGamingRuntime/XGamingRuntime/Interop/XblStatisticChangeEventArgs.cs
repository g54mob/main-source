using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal struct XblStatisticChangeEventArgs
	{
		internal readonly ulong xboxUserId;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
		internal readonly byte[] serviceConfigurationId;

		internal readonly XblStatistic latestStatistic;
	}
}
