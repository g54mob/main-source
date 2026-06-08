using System;

namespace XGamingRuntime.Interop
{
	internal struct XblUserStatisticsResult
	{
		internal readonly ulong xboxUserId;

		private readonly IntPtr serviceConfigStatistics;

		private readonly uint serviceConfigStatisticsCount;

		internal T[] GetServiceConfigStatistics<T>(Func<XblServiceConfigurationStatistic, T> ctor)
		{
			return Converters.PtrToClassArray(serviceConfigStatistics, serviceConfigStatisticsCount, ctor);
		}
	}
}
