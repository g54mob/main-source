using System;
using System.Linq;
using System.Text;
using Google.Apis.Util;

namespace Google.Apis.Auth.OAuth2
{
	internal static class AwsCanonicalRequestUriExtensions
	{
		private const string DoubleEscapedEqual = "%253D";

		private static readonly char[] Ampersand = new char[1] { '&' };

		private static readonly char[] Equal = new char[1] { '=' };

		internal static string GetPathForAwsCanonicalRequest(this Uri uri)
		{
			uri.ThrowIfNull("uri");
			StringBuilder stringBuilder = new StringBuilder("/");
			string[] array = uri.GetComponents(UriComponents.Path, UriFormat.Unescaped).Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string stringToEscape in array)
			{
				stringBuilder.Append(Uri.EscapeDataString(Uri.EscapeDataString(stringToEscape)));
				stringBuilder.Append("/");
			}
			return stringBuilder.ToString();
		}

		internal static string GetQueryStringForAwsCanonicalRequest(this Uri uri)
		{
			uri.ThrowIfNull("uri");
			string components = uri.GetComponents(UriComponents.Query, UriFormat.Unescaped);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string item in components.Split(Ampersand, StringSplitOptions.RemoveEmptyEntries).OrderBy((string p) => p, StringComparer.Ordinal))
			{
				string[] array = item.Split(Equal, StringSplitOptions.None);
				stringBuilder.Append(Uri.EscapeDataString(array[0]));
				stringBuilder.Append("=");
				if (array.Length > 1)
				{
					stringBuilder.Append(Uri.EscapeDataString(array[1]));
				}
				for (int num = 2; num < array.Length; num++)
				{
					stringBuilder = stringBuilder.Append("%253D");
					stringBuilder.Append(Uri.EscapeDataString(array[num]));
				}
				stringBuilder.Append("&");
			}
			stringBuilder.Length--;
			return stringBuilder.ToString();
		}
	}
}
