using System;
using Sentry.Protocol;

namespace Sentry
{
	public interface ISpan : ISpanData, ITraceContext, IHasTags, IHasExtra
	{
		new string? Description { get; set; }

		new string Operation { get; set; }

		new SpanStatus? Status { get; set; }

		ISpan StartChild(string operation);

		void Finish();

		void Finish(SpanStatus status);

		void Finish(Exception exception, SpanStatus status);

		void Finish(Exception exception);
	}
}
