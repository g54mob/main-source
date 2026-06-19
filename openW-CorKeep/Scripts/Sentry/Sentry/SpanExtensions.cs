using System;
using System.ComponentModel;
using System.Linq;
using Sentry.Internal;

namespace Sentry
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class SpanExtensions
	{
		public static ISpan StartChild(this ISpan span, string operation, string? description)
		{
			ISpan span2 = span.StartChild(operation);
			span2.Description = description;
			return span2;
		}

		internal static ISpan StartChild(this ISpan span, SpanContext context)
		{
			if (!((span.GetTransaction() as TransactionTracer)?.StartChild(context.SpanId, span.SpanId, context.Operation, context.Instrumenter) is SpanTracer spanTracer))
			{
				return NoOpSpan.Instance;
			}
			spanTracer.Description = context.Description;
			return spanTracer;
		}

		public static ITransactionTracer GetTransaction(this ISpan span)
		{
			if (!(span is ITransactionTracer result))
			{
				if (span is SpanTracer spanTracer)
				{
					return spanTracer.Transaction;
				}
				throw new ArgumentOutOfRangeException("span", span, null);
			}
			return result;
		}

		internal static ISpan GetDbParentSpan(this ISpan span)
		{
			ITransactionTracer transaction = span.GetTransaction();
			return transaction.Spans.OrderByDescending((ISpan x) => x.StartTimestamp).FirstOrDefault((ISpan s) => !s.IsFinished && !s.Operation.StartsWith("db.")) ?? transaction;
		}
	}
}
