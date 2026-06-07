using System.Collections;
using System.Collections.Specialized;
using System.Text;

namespace Edgegap.Codice.Utils
{
	public sealed class HttpUtility
	{
		private sealed class HttpQSCollection : NameValueCollection
		{
			public override string ToString()
			{
				return null;
			}
		}

		private static void WriteCharBytes(IList buf, char ch, Encoding e)
		{
		}

		public static string UrlDecode(string s, Encoding e)
		{
			return null;
		}

		private static int GetInt(byte b)
		{
			return 0;
		}

		private static int GetChar(string str, int offset, int length)
		{
			return 0;
		}

		public static string UrlEncode(string str)
		{
			return null;
		}

		public static string UrlEncode(string s, Encoding Enc)
		{
			return null;
		}

		public static byte[] UrlEncodeToBytes(byte[] bytes, int offset, int count)
		{
			return null;
		}

		public static string HtmlDecode(string s)
		{
			return null;
		}

		public static NameValueCollection ParseQueryString(string query)
		{
			return null;
		}

		public static NameValueCollection ParseQueryString(string query, Encoding encoding)
		{
			return null;
		}

		internal static void ParseQueryString(string query, Encoding encoding, NameValueCollection result)
		{
		}
	}
}
