using System.Collections.Generic.Enumerable;
using System.Reflection;
using System.Text;

namespace System.Diagnostics
{
	internal static class ExceptionExtensions
	{
		private static readonly FieldInfo? stackTraceString = typeof(Exception).GetField("_stackTraceString", BindingFlags.Instance | BindingFlags.NonPublic);

		private static void SetStackTracesString(this Exception exception, string value)
		{
			stackTraceString?.SetValue(exception, value);
		}

		public static T Demystify<T>(this T exception) where T : Exception
		{
			try
			{
				EnhancedStackTrace enhancedStackTrace = new EnhancedStackTrace(exception);
				if (enhancedStackTrace.FrameCount > 0)
				{
					exception.SetStackTracesString(enhancedStackTrace.ToString());
				}
				if (exception is AggregateException ex)
				{
					foreach (Exception item in EnumerableIList.Create(ex.InnerExceptions))
					{
						item.Demystify();
					}
				}
				exception.InnerException?.Demystify();
			}
			catch
			{
			}
			return exception;
		}

		public static string ToStringDemystified(this Exception exception)
		{
			return new StringBuilder().AppendDemystified(exception).ToString();
		}
	}
}
