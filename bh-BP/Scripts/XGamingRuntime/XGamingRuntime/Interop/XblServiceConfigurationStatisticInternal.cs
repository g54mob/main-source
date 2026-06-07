using System;

namespace XGamingRuntime.Interop
{
	internal struct XblServiceConfigurationStatisticInternal
	{
		internal readonly byte[] serviceConfigurationId;

		private readonly IntPtr statistics;

		private readonly uint statisticsCount;

		internal T[] GetStatistics<T>(Func<XblStatisticInternal, T> ctor)
		{
			return null;
		}
	}
}
