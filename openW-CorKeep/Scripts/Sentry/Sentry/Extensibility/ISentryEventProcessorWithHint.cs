namespace Sentry.Extensibility
{
	public interface ISentryEventProcessorWithHint : ISentryEventProcessor
	{
		SentryEvent? Process(SentryEvent @event, SentryHint hint);
	}
}
