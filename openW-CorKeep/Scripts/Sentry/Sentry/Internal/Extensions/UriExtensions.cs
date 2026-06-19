using System;

namespace Sentry.Internal.Extensions
{
	internal static class UriExtensions
	{
		public static string HttpRequestUrl(this Uri uri)
		{
			return new UriBuilder(uri).Uri.GetComponents(UriComponents.HttpRequestUrl, UriFormat.Unescaped);
		}
	}
}
