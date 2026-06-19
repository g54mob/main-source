using System.Collections.Generic;

namespace Sentry
{
	public class TransactionSamplingContext
	{
		public ITransactionContext TransactionContext { get; }

		public IReadOnlyDictionary<string, object?> CustomSamplingContext { get; }

		public TransactionSamplingContext(ITransactionContext transactionContext, IReadOnlyDictionary<string, object?> customSamplingContext)
		{
			TransactionContext = transactionContext;
			CustomSamplingContext = customSamplingContext;
		}
	}
}
