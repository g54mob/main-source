namespace Sentry.Extensibility
{
	public interface ISentryTransactionProcessorWithHint : ISentryTransactionProcessor
	{
		SentryTransaction? Process(SentryTransaction transaction, SentryHint hint);
	}
}
