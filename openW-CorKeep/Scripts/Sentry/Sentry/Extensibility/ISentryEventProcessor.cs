namespace Sentry.Extensibility
{
	public interface ISentryEventProcessor
	{
		SentryEvent? Process(SentryEvent @event);
	}
}
