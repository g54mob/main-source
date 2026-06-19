using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol.Metrics
{
	internal class SetMetric : Metric
	{
		private readonly HashSet<int> _value;

		public IReadOnlyCollection<int> Value => _value;

		public SetMetric()
		{
			_value = new HashSet<int>();
		}

		public SetMetric(string key, int value, MeasurementUnit? unit = null, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null)
			: base(key, unit, tags, timestamp)
		{
			_value = new HashSet<int> { value };
		}

		public override void Add(double value)
		{
			_value.Add((int)value);
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
