using System.Net.Http;

namespace Sentry.Http
{
	public interface ISentryHttpClientFactory
	{
		HttpClient Create(SentryOptions options);
	}
}
