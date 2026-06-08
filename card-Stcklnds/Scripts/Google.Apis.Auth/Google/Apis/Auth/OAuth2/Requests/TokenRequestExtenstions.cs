using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Util;

namespace Google.Apis.Auth.OAuth2.Requests
{
	public static class TokenRequestExtenstions
	{
		public static Task<TokenResponse> ExecuteAsync(this TokenRequest request, HttpClient httpClient, string tokenServerUrl, CancellationToken taskCancellationToken, IClock clock)
		{
			return request.PostFormAsync(httpClient, tokenServerUrl, null, clock, ApplicationContext.Logger, taskCancellationToken);
		}
	}
}
