using System;
using System.Globalization;
using System.Threading;
using Amazon.Util;

namespace Amazon.Runtime.Logging
{
	internal class ConsoleAdaptorLogger : IAdaptorLogger
	{
		public static long _sequenceId;

		private Type _declaredLoggerType;

		public bool IsEnabled(SdkLogLevel level)
		{
			return true;
		}

		public ConsoleAdaptorLogger(Type declaredLoggerType)
		{
			_declaredLoggerType = declaredLoggerType;
		}

		public void Log(SdkLogLevel level, string message, Exception ex, params object[] parameters)
		{
			string text = string.Format(CultureInfo.CurrentCulture, message, parameters);
			long num = Interlocked.Increment(ref _sequenceId);
			string text2 = AWSSDKUtils.CorrectedUtcNow.ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z", CultureInfo.InvariantCulture);
			string text3 = level.ToString().ToUpper(CultureInfo.InvariantCulture);
			Console.WriteLine(arg1: (ex == null) ? string.Format(CultureInfo.CurrentCulture, "{0}|{1}|{2}|{3}", num, text2, text3, text) : string.Format(CultureInfo.CurrentCulture, "{0}|{1}|{2}|{3} --> {4}", num, text2, text3, text, ex.ToString()), format: "{0} {1}", arg0: _declaredLoggerType.Name);
		}
	}
}
