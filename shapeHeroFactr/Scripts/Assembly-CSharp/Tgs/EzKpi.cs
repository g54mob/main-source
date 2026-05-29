using System;
using System.Diagnostics;

namespace Tgs
{
	public static class EzKpi
	{
		[Serializable]
		public class Record
		{
			public string deviceId;

			public string deviceName;

			public string keyName;

			public string eventName;

			public string positionName;

			public string eventTime;

			public string locale;
		}

		private static string kpiFolder;

		public static string GetNowPathName()
		{
			return null;
		}

		public static string GetNow()
		{
			return null;
		}

		public static string GetKpiFolder()
		{
			return null;
		}

		[Conditional("SHOW_VER")]
		public static void PrepareRecordEvent()
		{
		}

		[Conditional("SHOW_VER")]
		public static void RecordEvent(string keyName, string eventName = "", string positionName = "")
		{
		}
	}
}
