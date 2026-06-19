using System.Globalization;
using System.Net;
using System.Net.Http;

namespace Sentry.Internal.Extensions
{
	internal static class HttpStatusExtensions
	{
		private const string HttpRequestExceptionMessage = "Response status code does not indicate success: {0}";

		public static void EnsureSuccessStatusCode(this HttpStatusCode statusCode)
		{
			if (statusCode < HttpStatusCode.OK || statusCode > (HttpStatusCode)299)
			{
				throw new HttpRequestException(string.Format(CultureInfo.InvariantCulture, "Response status code does not indicate success: {0}", (int)statusCode));
			}
		}
	}
}
