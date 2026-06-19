using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal struct XblServiceConfigurationStatistic
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
		internal readonly byte[] serviceConfigurationId;

		private readonly IntPtr statistics;

		private readonly uint statisticsCount;

		internal T[] GetStatistics<T>(Func<XblStatistic, T> ctor)
		{
			return Converters.PtrToClassArray(statistics, statisticsCount, ctor);
		}
	}
}
