using Sentry.Protocol;

namespace Sentry
{
	public interface ITransactionData : ISpanData, ITraceContext, IHasTags, IHasExtra, ITransactionContext, IEventLike
	{
		string? Platform { get; set; }
	}
}
