namespace Sentry.Extensibility
{
	internal static class ISentryEventProcessorExtensions
	{
		internal static SentryEvent? DoProcessEvent(this ISentryEventProcessor processor, SentryEvent @event, SentryHint hint)
		{
			if (!(processor is ISentryEventProcessorWithHint sentryEventProcessorWithHint))
			{
				return processor.Process(@event);
			}
			return sentryEventProcessorWithHint.Process(@event, hint);
		}
	}
}
