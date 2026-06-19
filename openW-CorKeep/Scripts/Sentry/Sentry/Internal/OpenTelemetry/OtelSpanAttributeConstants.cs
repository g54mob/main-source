namespace Sentry.Internal.OpenTelemetry
{
	internal static class OtelSpanAttributeConstants
	{
		public const string StatusCodeKey = "otel.status_code";

		public const string StatusDescriptionKey = "otel.status_description";

		public const string DatabaseStatementTypeKey = "db.statement_type";
	}
}
