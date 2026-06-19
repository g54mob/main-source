using Sentry.Internal.Extensions;

namespace Sentry.Extensibility
{
	public abstract class BaseRequestPayloadExtractor : IRequestPayloadExtractor
	{
		public object? ExtractPayload(IHttpRequest request)
		{
			if (request.IsNull())
			{
				return null;
			}
			if (request.Body == null || !request.Body.CanSeek || !request.Body.CanRead || !IsSupported(request))
			{
				return null;
			}
			long position = request.Body.Position;
			try
			{
				request.Body.Position = 0L;
				return DoExtractPayLoad(request);
			}
			finally
			{
				request.Body.Position = position;
			}
		}

		protected abstract bool IsSupported(IHttpRequest request);

		protected abstract object? DoExtractPayLoad(IHttpRequest request);
	}
}
