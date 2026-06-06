using System.Text;

namespace PajamaLlama.Debugging
{
	public static class LogBlock
	{
		private static StringBuilder _logs;

		private static bool _hasLogs;

		public static void Begin()
		{
			if (_logs == null)
			{
				_logs = new StringBuilder();
			}
			else
			{
				_logs.Clear();
			}
			_hasLogs = false;
		}

		public static void Log(string error)
		{
			_logs.AppendLine(error);
			_hasLogs = true;
		}

		public static void LogFormat(string formattedError, params object[] args)
		{
			Log(string.Format(formattedError, args));
		}

		public static bool End(out string log)
		{
			if (_hasLogs)
			{
				log = _logs.ToString();
				return true;
			}
			log = null;
			return false;
		}
	}
}
