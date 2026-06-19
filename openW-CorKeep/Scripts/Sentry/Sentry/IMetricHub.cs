using System.Collections.Generic;
using Sentry.Protocol.Metrics;

namespace Sentry
{
	internal interface IMetricHub
	{
		void CaptureMetrics(IEnumerable<Metric> metrics);

		void CaptureCodeLocations(CodeLocations codeLocations);

		ISpan StartSpan(string operation, string description);

		ISpan? GetSpan();
	}
}
