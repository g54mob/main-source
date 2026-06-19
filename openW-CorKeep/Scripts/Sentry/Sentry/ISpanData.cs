using System;
using System.Collections.Generic;
using Sentry.Protocol;

namespace Sentry
{
	public interface ISpanData : ITraceContext, IHasTags, IHasExtra
	{
		DateTimeOffset StartTimestamp { get; }

		DateTimeOffset? EndTimestamp { get; }

		bool IsFinished { get; }

		IReadOnlyDictionary<string, Measurement> Measurements { get; }

		SentryTraceHeader GetTraceHeader();

		void SetMeasurement(string name, Measurement measurement);
	}
}
