using System;
using System.Text.RegularExpressions;

namespace ScheduleOne.DevUtilities
{
	public static class PlayerLogExporter
	{
		private static Action _onSuccess;

		private static Regex[] ExcludedRegexes;

		public static void ExportPlayerLog(bool previous, Action onSuccess = null)
		{
		}

		private static void SavePathSelected(string savePath, bool previous)
		{
		}

		public static string FilterLog(string log)
		{
			return null;
		}

		private static string ReadFileShared(string path)
		{
			return null;
		}

		public static string GetLogPath(bool previous)
		{
			return null;
		}
	}
}
