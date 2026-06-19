namespace Sentry.Extensibility
{
	public interface ISentryTransactionProcessor
	{
		SentryTransaction? Process(SentryTransaction transaction);
	}
}
