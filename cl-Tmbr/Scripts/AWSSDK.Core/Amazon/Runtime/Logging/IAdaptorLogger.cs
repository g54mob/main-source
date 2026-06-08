using System;

namespace Amazon.Runtime.Logging
{
	public interface IAdaptorLogger
	{
		bool IsEnabled(SdkLogLevel level);

		void Log(SdkLogLevel level, string message, Exception ex, params object[] parameters);
	}
}
