using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using Amazon.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime
{
	public class URIBasedRefreshingCredentialHelper : RefreshingAWSCredentials
	{
		public class SecurityBase
		{
			public string Code { get; set; }

			public string Message { get; set; }

			public DateTime LastUpdated { get; set; }
		}

		public class SecurityInfo : SecurityBase
		{
			public string InstanceProfileArn { get; set; }

			public string InstanceProfileId { get; set; }
		}

		public class SecurityCredentials : SecurityBase
		{
			public string Type { get; set; }

			public string AccessKeyId { get; set; }

			public string SecretAccessKey { get; set; }

			public string Token { get; set; }

			public DateTime Expiration { get; set; }

			public string RoleArn { get; set; }

			public string AccountId { get; set; }
		}

		private static string SuccessCode = "Success";

		protected static string GetContents(Uri uri)
		{
			return GetContents(uri, null);
		}

		protected static string GetContents(Uri uri, IWebProxy proxy)
		{
			return GetContents(uri, proxy, null);
		}

		protected static string GetContents(Uri uri, IWebProxy proxy, Dictionary<string, string> headers)
		{
			try
			{
				return AWSSDKUtils.ExecuteHttpRequest(uri, "GET", null, TimeSpan.Zero, proxy, headers);
			}
			catch (Exception innerException)
			{
				throw new AmazonServiceException("Unable to reach credentials server", innerException);
			}
		}

		protected static async Task<string> GetContentsAsync(Uri uri, IWebProxy proxy, Dictionary<string, string> headers)
		{
			try
			{
				return await AWSSDKUtils.ExecuteHttpRequestAsync(uri, "GET", null, TimeSpan.Zero, proxy, headers).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception innerException)
			{
				throw new AmazonServiceException("Unable to reach credentials server", innerException);
			}
		}

		protected static T GetObjectFromResponse<T, TC>(Uri uri, IWebProxy proxy, Dictionary<string, string> headers) where TC : JsonSerializerContext, new()
		{
			return JsonSerializerHelper.Deserialize<T>(GetContents(uri, proxy, headers), new TC());
		}

		protected static async Task<T> GetObjectFromResponseAsync<T, TC>(Uri uri, IWebProxy proxy, Dictionary<string, string> headers) where TC : JsonSerializerContext, new()
		{
			return JsonSerializerHelper.Deserialize<T>(await GetContentsAsync(uri, proxy, headers).ConfigureAwait(continueOnCapturedContext: false), new TC());
		}

		protected static void ValidateResponse(SecurityBase response)
		{
			if (!string.Equals(response.Code, SuccessCode, StringComparison.OrdinalIgnoreCase))
			{
				throw new AmazonServiceException(string.Format(CultureInfo.InvariantCulture, "Unable to retrieve credentials. Code = \"{0}\". Message = \"{1}\".", response.Code, response.Message));
			}
		}
	}
}
