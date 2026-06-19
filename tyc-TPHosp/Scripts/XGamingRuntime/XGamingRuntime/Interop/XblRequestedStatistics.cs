using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal struct XblRequestedStatistics
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
		internal readonly byte[] serviceConfigurationId;

		private readonly IntPtr statistics;

		private readonly uint statisticsCount;

		internal XblRequestedStatistics(XGamingRuntime.XblRequestedStatistics requestedStatistics, DisposableCollection disposableCollection)
		{
			serviceConfigurationId = Converters.StringToNullTerminatedUTF8ByteArray(requestedStatistics.ServiceConfigurationId, 40);
			statistics = Converters.StringArrayToUTF8StringArray(requestedStatistics.Statistics, disposableCollection, out var count);
			statisticsCount = count.ToUInt32();
		}

		internal static bool ValidateFields(string scid)
		{
			if (scid != null)
			{
				return Converters.StringToNullTerminatedUTF8ByteArray(scid).Length <= 40;
			}
			return false;
		}
	}
}
