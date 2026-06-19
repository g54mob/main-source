namespace Sentry.Integrations
{
	public interface ISdkIntegration
	{
		void Register(IHub hub, SentryOptions options);
	}
}
