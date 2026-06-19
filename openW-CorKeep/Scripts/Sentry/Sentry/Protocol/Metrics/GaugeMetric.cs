using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentry.Extensibility;

namespace Sentry.Protocol.Metrics
{
	internal class GaugeMetric : Metric
	{
		public double Value { get; private set; }

		public double First { get; }

		public double Min { get; private set; }

		public double Max { get; private set; }

		public double Sum { get; private set; }

		public double Count { get; private set; }

		public GaugeMetric()
		{
			Value = 0.0;
			First = 0.0;
			Min = 0.0;
			Max = 0.0;
			Sum = 0.0;
			Count = 0.0;
		}

		public GaugeMetric(string key, double value, MeasurementUnit? unit = null, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null)
			: base(key, unit, tags, timestamp)
		{
			Value = value;
			First = value;
			Min = value;
			Max = value;
			Sum = value;
			Count = 1.0;
		}

		public override void Add(double value)
		{
			Value = value;
			Min = Math.Min(Min, value);
			Max = Math.Max(Max, value);
			Sum += value;
			Count++;
		}

		protected override void WriteValues(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteNumber("value", Value);
			writer.WriteNumber("first", First);
			writer.WriteNumber("min", Min);
			writer.WriteNumber("max", Max);
			writer.WriteNumber("sum", Sum);
			writer.WriteNumber("count", Count);
		}

		protected override IEnumerable<IConvertible> SerializedStatsdValues()
		{
			yield return Value;
			yield return Min;
			yield return Max;
			yield return Sum;
			yield return Count;
		}
	}
}
