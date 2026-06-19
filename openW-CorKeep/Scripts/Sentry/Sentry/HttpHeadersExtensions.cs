using System.Net.Http.Headers;

namespace Sentry
{
	internal static class HttpHeadersExtensions
	{
		internal static string GetCookies(this HttpHeaders headers)
		{
			if (!headers.TryGetValues("Cookie", out var values))
			{
				return string.Empty;
			}
			return string.Join("; ", values);
		}
	}
}
