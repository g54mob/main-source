using System.Runtime.InteropServices;

namespace DV.Platform.Windows
{
	public static class MemoryMonitoring_Native
	{
		private struct PERFORMANCE_INFORMATION
		{
			public uint cb;

			public ulong CommitTotal;

			public ulong CommitLimit;

			public ulong CommitPeak;

			public ulong PhysicalTotal;

			public ulong PhysicalAvailable;

			public ulong SystemCache;

			public ulong KernelTotal;

			public ulong KernelPaged;

			public ulong KernelNonpaged;

			public ulong PageSize;

			public uint HandleCount;

			public uint ProcessCount;

			public uint ThreadCount;
		}

		[DllImport("psapi.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern bool GetPerformanceInfo(out PERFORMANCE_INFORMATION pPerformanceInformation, uint cb);

		public static (long freeKB, long totalKB) GetFreeAndTotalMemoryKB()
		{
			if (!GetPerformanceInfo(out var pPerformanceInformation, (uint)Marshal.SizeOf<PERFORMANCE_INFORMATION>()))
			{
				return (freeKB: -1L, totalKB: -1L);
			}
			return (freeKB: (long)(pPerformanceInformation.PhysicalAvailable * pPerformanceInformation.PageSize / 1024), totalKB: (long)(pPerformanceInformation.PhysicalTotal * pPerformanceInformation.PageSize / 1024));
		}
	}
}
