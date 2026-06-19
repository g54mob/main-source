namespace Sentry.Extensibility
{
	internal static class ISentryTransactionProcessorExtensions
	{
		internal static SentryTransaction? DoProcessTransaction(this ISentryTransactionProcessor processor, SentryTransaction transaction, SentryHint hint)
		{
			if (!(processor is ISentryTransactionProcessorWithHint sentryTransactionProcessorWithHint))
			{
				return processor.Process(transaction);
			}
			return sentryTransactionProcessorWithHint.Process(transaction, hint);
		}
	}
}
