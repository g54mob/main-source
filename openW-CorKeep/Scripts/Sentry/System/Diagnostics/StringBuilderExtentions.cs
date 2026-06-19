using System.Collections.Generic.Enumerable;
using System.Text;

namespace System.Diagnostics
{
	internal static class StringBuilderExtentions
	{
		public static StringBuilder AppendDemystified(this StringBuilder builder, Exception exception)
		{
			try
			{
				EnhancedStackTrace enhancedStackTrace = new EnhancedStackTrace(exception);
				builder.Append(exception.GetType());
				if (!string.IsNullOrEmpty(exception.Message))
				{
					builder.Append(": ").Append(exception.Message);
				}
				builder.Append(Environment.NewLine);
				if (enhancedStackTrace.FrameCount > 0)
				{
					enhancedStackTrace.Append(builder);
				}
				if (exception is AggregateException ex)
				{
					foreach (Exception item in EnumerableIList.Create(ex.InnerExceptions))
					{
						builder.AppendInnerException(item);
					}
				}
				if (exception.InnerException != null)
				{
					builder.AppendInnerException(exception.InnerException);
				}
			}
			catch
			{
			}
			return builder;
		}

		private static void AppendInnerException(this StringBuilder builder, Exception exception)
		{
			builder.Append(" ---> ").AppendDemystified(exception).AppendLine()
				.Append("   --- End of inner exception stack trace ---");
		}
	}
}
