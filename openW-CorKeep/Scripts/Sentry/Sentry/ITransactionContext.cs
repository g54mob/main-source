using Sentry.Protocol;

namespace Sentry
{
	public interface ITransactionContext : ITraceContext
	{
		string Name { get; }

		bool? IsParentSampled { get; }

		TransactionNameSource NameSource { get; }
	}
}
