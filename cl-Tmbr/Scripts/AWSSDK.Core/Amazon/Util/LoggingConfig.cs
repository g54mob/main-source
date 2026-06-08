using Amazon.Runtime;
using Amazon.Runtime.Logging;

namespace Amazon.Util
{
	public class LoggingConfig
	{
		public static readonly int DefaultLogResponsesSizeLimit = 1024;

		private LoggingOptions _logTo;

		public LoggingOptions LogTo
		{
			get
			{
				return _logTo;
			}
			set
			{
				switch (LogTo)
				{
				case LoggingOptions.Console:
					AdaptorLoggerFactoryRegistry.DeregisterAdaptorLoggerFactory(new ConsoleAdaptorLoggerFactory().Name);
					break;
				case LoggingOptions.SystemDiagnostics:
					AdaptorLoggerFactoryRegistry.DeregisterAdaptorLoggerFactory(new DiagnosticAdaptorLoggerFactory().Name);
					break;
				}
				_logTo = value;
				switch (LogTo)
				{
				case LoggingOptions.Console:
					AdaptorLoggerFactoryRegistry.RegisterAdaptorLoggerFactory(new ConsoleAdaptorLoggerFactory());
					break;
				case LoggingOptions.SystemDiagnostics:
					AdaptorLoggerFactoryRegistry.RegisterAdaptorLoggerFactory(new DiagnosticAdaptorLoggerFactory());
					break;
				}
				AWSConfigs.OnPropertyChanged("LogTo");
			}
		}

		public ResponseLoggingOption LogResponses { get; set; }

		public int LogResponsesSizeLimit { get; set; }

		public bool LogMetrics { get; set; }

		public LogMetricsFormatOption LogMetricsFormat { get; set; }

		public IMetricsFormatter LogMetricsCustomFormatter { get; set; }

		internal LoggingConfig()
		{
			LogResponsesSizeLimit = DefaultLogResponsesSizeLimit;
		}
	}
}
