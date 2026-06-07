using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	public static class UserStatistics
	{
		[PreserveSig]
		public unsafe static extern int XblUserStatisticsAddStatisticChangedHandler(IntPtr xblContextHandle, XblStatisticChangedHandler handler, void* handlerContext);

		[PreserveSig]
		public static extern void XblUserStatisticsRemoveStatisticChangedHandler(IntPtr xblContextHandle, int context);

		[PreserveSig]
		public unsafe static extern int XblUserStatisticsTrackStatistics(IntPtr xblContextHandle, ulong* xboxUserIds, UIntPtr xboxUserIdsCount, sbyte* serviceConfigurationId, sbyte** statisticNames, UIntPtr statisticNamesCount);

		[PreserveSig]
		public unsafe static extern int XblUserStatisticsStopTrackingStatistics(IntPtr xblContextHandle, ulong* xboxUserIds, UIntPtr xboxUserIdsCount, sbyte* serviceConfigurationId, sbyte** statisticNames, UIntPtr statisticNamesCount);

		[PreserveSig]
		public unsafe static extern int XblUserStatisticsStopTrackingUsers(IntPtr xblContextHandle, ulong* xboxUserIds, UIntPtr xboxUserIdsCount);
	}
}
