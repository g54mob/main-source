using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Json;
using Google.Apis.Logging;
using Google.Apis.Requests.Parameters;
using Google.Apis.Util;

namespace Google.Apis.Auth.OAuth2.Requests
{
	internal static class RequestExtensions
	{
		internal static async Task<HttpResponseMessage> PostJsonAsync(this object request, HttpClient httpClient, string url, CancellationToken cancellationToken)
		{
			HttpRequestMessage request2 = new HttpRequestMessage(HttpMethod.Post, url)
			{
				Content = new StringContent(NewtonsoftJsonSerializer.Instance.Serialize(request), Encoding.UTF8, "application/json")
			};
			return await httpClient.SendAsync(request2, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		internal static async Task<TResponse> PostJsonAsync<TResponse>(this object request, HttpClient httpClient, string url, CancellationToken cancellationToken)
		{
			HttpResponseMessage obj = await request.PostJsonAsync(httpClient, url, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			obj.EnsureSuccessStatusCode();
			NewtonsoftJsonSerializer instance = NewtonsoftJsonSerializer.Instance;
			return await instance.DeserializeAsync<TResponse>(await obj.Content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		internal static async Task<TokenResponse> PostJsonAsync(this object request, HttpClient httpClient, string url, IClock clock, ILogger logger, CancellationToken cancellationToken)
		{
			return await TokenResponse.FromHttpResponseAsync(await request.PostJsonAsync(httpClient, url, cancellationToken).ConfigureAwait(continueOnCapturedContext: false), clock, logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		internal static async Task<TokenResponse> PostFormAsync(this object request, HttpClient httpClient, string url, AuthenticationHeaderValue authenticationHeaderValue, IClock clock, ILogger logger, CancellationToken taskCancellationToken)
		{
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url)
			{
				Content = ParameterUtils.CreateFormUrlEncodedContent(request)
			};
			if (authenticationHeaderValue != null)
			{
				httpRequestMessage.Headers.Authorization = authenticationHeaderValue;
			}
			return await TokenResponse.FromHttpResponseAsync(await httpClient.SendAsync(httpRequestMessage, taskCancellationToken).ConfigureAwait(continueOnCapturedContext: false), clock, logger).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
}
