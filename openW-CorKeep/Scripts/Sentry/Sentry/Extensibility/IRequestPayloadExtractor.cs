namespace Sentry.Extensibility
{
	public interface IRequestPayloadExtractor
	{
		object? ExtractPayload(IHttpRequest request);
	}
}
