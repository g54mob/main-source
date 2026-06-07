namespace ATL.Logging
{
	public class LogDelegator
	{
		public delegate void LogWriteDelegate(int level, string msg);

		public delegate void LogLocateDelegate(string msg);

		private static LogWriteDelegate theLogWriteDelegate;

		private static LogLocateDelegate theLogLocateDelegate;

		private static void writeDummyMethod(int a, string b)
		{
		}

		private static void locateDummyMethod(string a)
		{
		}

		public static LogWriteDelegate GetLogDelegate()
		{
			return null;
		}

		public static LogLocateDelegate GetLocateDelegate()
		{
			return null;
		}
	}
}
