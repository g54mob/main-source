using System.Text.RegularExpressions;

namespace Sentry.Internal
{
	internal static class OriginHelper
	{
		internal const string Manual = "manual";

		private const string ValidOriginPattern = "^(auto|manual)(\\.[\\w]+){0,3}$";

		private static readonly Regex ValidOrigin = new Regex("^(auto|manual)(\\.[\\w]+){0,3}$", RegexOptions.Compiled);

		public static bool IsValidOrigin(string? value)
		{
			if (value != null)
			{
				return ValidOrigin.IsMatch(value);
			}
			return true;
		}

		internal static string? TryParse(string origin)
		{
			if (!IsValidOrigin(origin))
			{
				return null;
			}
			return origin;
		}

		public static void SetOrigin(this ISpan span, string origin)
		{
			if (!(span is SpanTracer spanTracer))
			{
				if (span is TransactionTracer transactionTracer)
				{
					transactionTracer.Contexts.Trace.Origin = origin;
				}
			}
			else
			{
				spanTracer.Origin = origin;
			}
		}
	}
}
