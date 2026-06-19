using System.Collections.Generic;

namespace Sentry
{
	public class ExperimentalMetricsOptions
	{
		private IList<SubstringOrRegexPattern> _captureSystemDiagnosticsInstruments = new List<SubstringOrRegexPattern>();

		private IList<SubstringOrRegexPattern> _captureSystemDiagnosticsMeters = BuiltInSystemDiagnosticsMeters.All;

		public bool EnableCodeLocations { get; set; } = true;

		public IList<SubstringOrRegexPattern> CaptureSystemDiagnosticsInstruments
		{
			get
			{
				return _captureSystemDiagnosticsInstruments;
			}
			set
			{
				_captureSystemDiagnosticsInstruments = value.WithConfigBinding();
			}
		}

		public IList<SubstringOrRegexPattern> CaptureSystemDiagnosticsMeters
		{
			get
			{
				return _captureSystemDiagnosticsMeters;
			}
			set
			{
				_captureSystemDiagnosticsMeters = value.WithConfigBinding();
			}
		}
	}
}
