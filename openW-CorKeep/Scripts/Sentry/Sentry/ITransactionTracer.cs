using System.Collections.Generic;
using Sentry.Protocol;

namespace Sentry
{
	public interface ITransactionTracer : ITransactionData, ISpanData, ITraceContext, IHasTags, IHasExtra, ITransactionContext, IEventLike, ISpan
	{
		new string Name { get; set; }

		new bool? IsParentSampled { get; set; }

		IReadOnlyCollection<ISpan> Spans { get; }

		ISpan? GetLastActiveSpan();
	}
}
