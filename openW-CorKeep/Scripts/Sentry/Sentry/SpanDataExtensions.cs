using System;
using System.ComponentModel;
using Sentry.Protocol;

namespace Sentry
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class SpanDataExtensions
	{
		public static void SetMeasurement(this ISpanData spanData, string name, int value, MeasurementUnit unit = default(MeasurementUnit))
		{
			spanData.SetMeasurement(name, new Measurement(value, unit));
		}

		public static void SetMeasurement(this ISpanData spanData, string name, long value, MeasurementUnit unit = default(MeasurementUnit))
		{
			spanData.SetMeasurement(name, new Measurement(value, unit));
		}

		[CLSCompliant(false)]
		public static void SetMeasurement(this ISpanData spanData, string name, ulong value, MeasurementUnit unit = default(MeasurementUnit))
		{
			spanData.SetMeasurement(name, new Measurement(value, unit));
		}

		public static void SetMeasurement(this ISpanData spanData, string name, double value, MeasurementUnit unit = default(MeasurementUnit))
		{
			spanData.SetMeasurement(name, new Measurement(value, unit));
		}
	}
}
