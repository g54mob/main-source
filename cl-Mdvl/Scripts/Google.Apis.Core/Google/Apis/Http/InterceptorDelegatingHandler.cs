using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Util;

namespace Google.Apis.Http
{
	internal sealed class InterceptorDelegatingHandler : DelegatingHandler
	{
		private readonly IHttpExecuteInterceptor _interceptor;

		internal InterceptorDelegatingHandler(IHttpExecuteInterceptor interceptor, HttpMessageHandler innerHandler)
			: base(innerHandler)
		{
			_interceptor = interceptor.ThrowIfNull("interceptor");
		}

		internal InterceptorDelegatingHandler(IHttpExecuteInterceptor interceptor)
		{
			_interceptor = interceptor.ThrowIfNull("interceptor");
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			await _interceptor.InterceptAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return await base.SendAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
}
