using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol
{
	public sealed class Measurement : ISentryJsonSerializable
	{
		public object Value { get; }

		public MeasurementUnit Unit { get; }

		private Measurement(object value, MeasurementUnit unit)
		{
			Value = value;
			Unit = unit;
		}

		internal Measurement(int value, MeasurementUnit unit = default(MeasurementUnit))
		{
			Value = value;
			Unit = unit;
		}

		internal Measurement(long value, MeasurementUnit unit = default(MeasurementUnit))
		{
			Value = value;
			Unit = unit;
		}

		internal Measurement(ulong value, MeasurementUnit unit = default(MeasurementUnit))
		{
			Value = value;
			Unit = unit;
		}

		internal Measurement(double value, MeasurementUnit unit = default(MeasurementUnit))
		{
			Value = value;
			Unit = unit;
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			object value = Value;
			if (!(value is int value2))
			{
				if (!(value is long value3))
				{
					if (!(value is ulong value4))
					{
						if (value is double value5)
						{
							writer.WriteNumber("value", value5);
						}
					}
					else
					{
						writer.WriteNumber("value", value4);
					}
				}
				else
				{
					writer.WriteNumber("value", value3);
				}
			}
			else
			{
				writer.WriteNumber("value", value2);
			}
			writer.WriteStringIfNotWhiteSpace("unit", Unit.ToString());
			writer.WriteEndObject();
		}

		public static Measurement FromJson(JsonElement json)
		{
			object? dynamicOrNull = json.GetProperty("value").GetDynamicOrNull();
			string name = json.GetPropertyOrNull("unit")?.GetString();
			return new Measurement(dynamicOrNull, MeasurementUnit.Parse(name));
		}
	}
}
