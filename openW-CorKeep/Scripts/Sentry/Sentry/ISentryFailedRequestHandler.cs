using System.Net.Http;

namespace Sentry
{
	internal interface ISentryFailedRequestHandler
	{
		void HandleResponse(HttpResponseMessage response);
	}
}
