using System;

namespace XGamingRuntime.Interop
{
	internal struct XblRequestedStatisticsInternal
	{
		internal readonly byte[] serviceConfigurationId;

		private readonly IntPtr statistics;

		private readonly uint statisticsCount;

		internal XblRequestedStatisticsInternal(XGamingRuntime.XblRequestedStatistics requestedStatistics, DisposableCollection disposableCollection)
		{
			serviceConfigurationId = null;
			statistics = (IntPtr)0;
			statisticsCount = 0u;
		}

		internal static bool ValidateFields(string scid)
		{
			return false;
		}
	}
}
