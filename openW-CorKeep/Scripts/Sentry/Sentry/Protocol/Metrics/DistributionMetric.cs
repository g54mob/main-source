using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol.Metrics
{
	internal class DistributionMetric : Metric
	{
		private readonly List<double> _value;

		public IReadOnlyList<double> Value => _value;

		public DistributionMetric()
		{
			_value = new List<double>();
		}

		public DistributionMetric(string key, double value, MeasurementUnit? unit = null, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null)
			: base(key, unit, tags, timestamp)
		{
			_value = new List<double> { value };
		}

		public override void Add(double value)
		{
			_value.Add(value);
		}

		protected override void WriteValues(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteArrayIfNotEmpty("value", _value, logger);
		}

		protected override IEnumerable<IConvertible> SerializedStatsdValues()
		{
			return _value.Cast<IConvertible>();
		}
	}
}
