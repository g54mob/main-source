using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentry.Extensibility;

namespace Sentry.Protocol.Metrics
{
	internal class CounterMetric : Metric
	{
		public double Value { get; private set; }

		public CounterMetric()
		{
			Value = 0.0;
		}

		public CounterMetric(string key, double value, MeasurementUnit? unit = null, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null)
			: base(key, unit, tags, timestamp)
		{
			Value = value;
		}

		public override void Add(double value)
		{
			Value += value;
		}

		protected override void WriteValues(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteNumber("value", Value);
		}

		protected override IEnumerable<IConvertible> SerializedStatsdValues()
		{
			yield return Value;
		}
	}
}
