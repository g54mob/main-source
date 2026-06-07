using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Stats
{
	public sealed class StatsInterface : Handle
	{
		public const int CopystatbyindexApiLatest = 1;

		public const int CopystatbynameApiLatest = 1;

		public const int GetstatcountApiLatest = 1;

		public const int GetstatscountApiLatest = 1;

		public const int IngestdataApiLatest = 1;

		public const int IngeststatApiLatest = 3;

		public const int MaxIngestStats = 3000;

		public const int MaxQueryStats = 1000;

		public const int QuerystatsApiLatest = 3;

		public const int StatApiLatest = 1;

		public const int TimeUndefined = -1;

		public StatsInterface()
		{
		}

		public StatsInterface(IntPtr innerHandle)
		{
		}

		public Result CopyStatByIndex(CopyStatByIndexOptions options, out Stat outStat)
		{
			outStat = null;
			return default(Result);
		}

		public Result CopyStatByName(CopyStatByNameOptions options, out Stat outStat)
		{
			outStat = null;
			return default(Result);
		}

		public uint GetStatsCount(GetStatCountOptions options)
		{
			return 0u;
		}

		public void IngestStat(IngestStatOptions options, object clientData, OnIngestStatCompleteCallback completionDelegate)
		{
		}

		public void QueryStats(QueryStatsOptions options, object clientData, OnQueryStatsCompleteCallback completionDelegate)
		{
		}

		internal static void OnIngestStatCompleteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryStatsCompleteCallbackInternalImplementation(IntPtr data)
		{
		}

		[PreserveSig]
		internal static extern Result EOS_Stats_CopyStatByIndex(IntPtr handle, IntPtr options, ref IntPtr outStat);

		[PreserveSig]
		internal static extern Result EOS_Stats_CopyStatByName(IntPtr handle, IntPtr options, ref IntPtr outStat);

		[PreserveSig]
		internal static extern uint EOS_Stats_GetStatsCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern void EOS_Stats_IngestStat(IntPtr handle, IntPtr options, IntPtr clientData, OnIngestStatCompleteCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Stats_QueryStats(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryStatsCompleteCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Stats_Stat_Release(IntPtr stat);
	}
}
