using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Edgegap.Codice.Utils
{
	public class HttpEncoder
	{
		private static char[] hexChars;

		private static object entitiesLock;

		private static SortedDictionary<string, char> entities;

		private static HttpEncoder defaultEncoder;

		private static HttpEncoder currentEncoder;

		private static IDictionary<string, char> Entities => null;

		public static HttpEncoder Current
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static HttpEncoder Default => null;

		protected internal virtual void HeaderNameValueEncode(string headerName, string headerValue, out string encodedHeaderName, out string encodedHeaderValue)
		{
			encodedHeaderName = null;
			encodedHeaderValue = null;
		}

		private static void StringBuilderAppend(string s, ref StringBuilder sb)
		{
		}

		private static string EncodeHeaderString(string input)
		{
			return null;
		}

		protected internal virtual void HtmlAttributeEncode(string value, TextWriter output)
		{
		}

		protected internal virtual void HtmlDecode(string value, TextWriter output)
		{
		}

		protected internal virtual void HtmlEncode(string value, TextWriter output)
		{
		}

		protected internal virtual byte[] UrlEncode(byte[] bytes, int offset, int count)
		{
			return null;
		}

		protected internal virtual string UrlPathEncode(string value)
		{
			return null;
		}

		internal static byte[] UrlEncodeToBytes(byte[] bytes, int offset, int count)
		{
			return null;
		}

		internal static string HtmlEncode(string s)
		{
			return null;
		}

		internal static string HtmlAttributeEncode(string s)
		{
			return null;
		}

		internal static string HtmlDecode(string s)
		{
			return null;
		}

		internal static bool NotEncoded(char c)
		{
			return false;
		}

		internal static void UrlEncodeChar(char c, Stream result, bool isUnicode)
		{
		}

		internal static void UrlPathEncodeChar(char c, Stream result)
		{
		}

		private static void InitEntities()
		{
		}
	}
}
