using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;
using Sentry.Protocol.Envelopes;

namespace Sentry.Protocol.Metrics
{
	internal abstract class Metric : ISentryJsonSerializable, ISerializable
	{
		private IDictionary<string, string>? _tags;

		public SentryId EventId { get; } = SentryId.Create();

		public string Key { get; }

		public DateTimeOffset Timestamp { get; }

		public MeasurementUnit? Unit { get; }

		public IDictionary<string, string> Tags
		{
			get
			{
				if (_tags == null)
				{
					_tags = new Dictionary<string, string>();
				}
				return _tags;
			}
		}

		private string StatsdType
		{
			get
			{
				if (!(this is CounterMetric))
				{
					if (!(this is GaugeMetric))
					{
						if (!(this is DistributionMetric))
						{
							if (this is SetMetric)
							{
								return "s";
							}
							throw new ArgumentOutOfRangeException(GetType().Name, "Unable to infer statsd type");
						}
						return "d";
					}
					return "g";
				}
				return "c";
			}
		}

		protected Metric()
			: this(string.Empty)
		{
		}

		protected Metric(string key, MeasurementUnit? unit = null, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null)
		{
			Key = key;
			Unit = unit;
			_tags = tags;
			Timestamp = timestamp ?? DateTimeOffset.UtcNow;
		}

		public abstract void Add(double value);

		protected abstract void WriteValues(Utf8JsonWriter writer, IDiagnosticLogger? logger);

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteString("type", GetType().Name);
			writer.WriteSerializable("event_id", EventId, logger);
			writer.WriteString("name", Key);
			writer.WriteString("timestamp", Timestamp);
			if (Unit.HasValue)
			{
				writer.WriteStringIfNotWhiteSpace("unit", Unit.ToString());
			}
			writer.WriteStringDictionaryIfNotEmpty("tags", _tags);
			WriteValues(writer, logger);
			writer.WriteEndObject();
		}

		protected abstract IEnumerable<IConvertible> SerializedStatsdValues();

		public async Task SerializeAsync(Stream stream, IDiagnosticLogger? logger, CancellationToken cancellationToken = default(CancellationToken))
		{
			string text = MetricHelper.SanitizeMetricKeyOrName(Key);
			await Write(text + "@").ConfigureAwait(continueOnCapturedContext: false);
			string content = MetricHelper.SanitizeMetricUnit((Unit ?? MeasurementUnit.None).ToString());
			await Write(content);
			foreach (IConvertible item in SerializedStatsdValues())
			{
				await Write(":" + item.ToString(CultureInfo.InvariantCulture));
			}
			await Write("|" + StatsdType);
			IDictionary<string, string> tags = _tags;
			if (tags != null && tags.Count > 0)
			{
				await Write("|#");
				bool first = true;
				foreach (var (key, value) in tags)
				{
					if (!string.IsNullOrWhiteSpace(MetricHelper.SanitizeTagKey(key)))
					{
						if (!first)
						{
							await Write(",");
						}
						else
						{
							first = false;
						}
						string text4 = MetricHelper.SanitizeTagValue(value);
						await Write(key + ":" + text4);
					}
				}
			}
			await Write("|T" + Timestamp.GetTimeBucketKey().ToString(CultureInfo.InvariantCulture) + "\n");
			async Task Write(string s)
			{
				await PolyfillExtensions.WriteAsync(stream, Encoding.UTF8.GetBytes(s), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		public void Serialize(Stream stream, IDiagnosticLogger? logger)
		{
			SerializeAsync(stream, logger).GetAwaiter().GetResult();
		}
	}
}
