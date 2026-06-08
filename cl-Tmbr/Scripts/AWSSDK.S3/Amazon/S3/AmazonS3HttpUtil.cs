using System;
using System.Net;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Util.Internal;

namespace Amazon.S3
{
	internal static class AmazonS3HttpUtil
	{
		internal static async Task<GetHeadResponse> GetHeadAsync(IAmazonS3 s3Client, IClientConfig config, string url, string header)
		{
			HttpWebRequest headHttpRequest = GetHeadHttpRequest(config, url);
			try
			{
				using HttpWebResponse httpResponse = (await headHttpRequest.GetResponseAsync().ConfigureAwait(continueOnCapturedContext: false)) as HttpWebResponse;
				return HandleWebResponse(header, httpResponse);
			}
			catch (WebException we)
			{
				return HandleWebException(header, we);
			}
		}

		internal static GetHeadResponse GetHead(IAmazonS3 s3Client, IClientConfig config, string url, string header)
		{
			return GetHeadAsync(s3Client, config, url, header).GetAwaiter().GetResult();
		}

		internal static HttpWebRequest GetHeadHttpRequest(IClientConfig config, string url)
		{
			HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
			httpWebRequest.Method = "HEAD";
			SetProxyIfAvailableAndConfigured(config, httpWebRequest);
			return httpWebRequest;
		}

		private static GetHeadResponse HandleWebResponse(string header, HttpWebResponse httpResponse)
		{
			return new GetHeadResponse
			{
				HeaderValue = httpResponse.Headers[header],
				StatusCode = httpResponse.StatusCode
			};
		}

		private static GetHeadResponse HandleWebException(string header, WebException we)
		{
			using HttpWebResponse httpWebResponse = we.Response as HttpWebResponse;
			if (httpWebResponse == null)
			{
				return new GetHeadResponse();
			}
			return new GetHeadResponse
			{
				HeaderValue = httpWebResponse.Headers[header],
				StatusCode = httpWebResponse.StatusCode
			};
		}

		private static void SetProxyIfAvailableAndConfigured(IClientConfig config, HttpWebRequest httpWebRequest)
		{
			IWebProxy webProxy = config.GetWebProxy();
			if (webProxy != null)
			{
				httpWebRequest.Proxy = webProxy;
			}
			else if (!NoProxyFilter.Instance.Match(httpWebRequest.RequestUri))
			{
				if (httpWebRequest.RequestUri.Scheme == Uri.UriSchemeHttp)
				{
					httpWebRequest.Proxy = config.GetHttpProxy();
				}
				else if (httpWebRequest.RequestUri.Scheme == Uri.UriSchemeHttps)
				{
					httpWebRequest.Proxy = config.GetHttpsProxy();
				}
			}
		}
	}
}
