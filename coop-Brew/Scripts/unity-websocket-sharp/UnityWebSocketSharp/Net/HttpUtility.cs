using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Text;

namespace UnityWebSocketSharp.Net
{
	internal static class HttpUtility
	{
		private static Dictionary<string, char> _entities;

		private static char[] _hexChars;

		private static object _sync;

		static HttpUtility()
		{
		}

		private static Dictionary<string, char> getEntities()
		{
			return null;
		}

		private static int getNumber(char c)
		{
			return 0;
		}

		private static int getNumber(byte[] bytes, int offset, int count)
		{
			return 0;
		}

		private static int getNumber(string s, int offset, int count)
		{
			return 0;
		}

		private static string htmlDecode(string s)
		{
			return null;
		}

		private static string htmlEncode(string s, bool minimal)
		{
			return null;
		}

		private static void initEntities()
		{
		}

		private static bool isAlphabet(char c)
		{
			return false;
		}

		private static bool isNumeric(char c)
		{
			return false;
		}

		private static bool isUnreserved(char c)
		{
			return false;
		}

		private static bool isUnreservedInRfc2396(char c)
		{
			return false;
		}

		private static bool isUnreservedInRfc3986(char c)
		{
			return false;
		}

		private static byte[] urlDecodeToBytes(byte[] bytes, int offset, int count)
		{
			return null;
		}

		private static void urlEncode(byte b, Stream output)
		{
		}

		private static byte[] urlEncodeToBytes(byte[] bytes, int offset, int count)
		{
			return null;
		}

		internal static Uri CreateRequestUrl(string requestUri, string host, bool websocketRequest, bool secure)
		{
			return null;
		}

		internal static IPrincipal CreateUser(string response, AuthenticationSchemes scheme, string realm, string method, Func<IIdentity, NetworkCredential> credentialsFinder)
		{
			return null;
		}

		internal static Encoding GetEncoding(string contentType)
		{
			return null;
		}

		internal static bool TryGetEncoding(string contentType, out Encoding result)
		{
			result = null;
			return false;
		}

		public static string HtmlAttributeEncode(string s)
		{
			return null;
		}

		public static void HtmlAttributeEncode(string s, TextWriter output)
		{
		}

		public static string HtmlDecode(string s)
		{
			return null;
		}

		public static void HtmlDecode(string s, TextWriter output)
		{
		}

		public static string HtmlEncode(string s)
		{
			return null;
		}

		public static void HtmlEncode(string s, TextWriter output)
		{
		}

		public static string UrlDecode(string s)
		{
			return null;
		}

		public static string UrlDecode(byte[] bytes, Encoding encoding)
		{
			return null;
		}

		public static string UrlDecode(string s, Encoding encoding)
		{
			return null;
		}

		public static string UrlDecode(byte[] bytes, int offset, int count, Encoding encoding)
		{
			return null;
		}

		public static byte[] UrlDecodeToBytes(byte[] bytes)
		{
			return null;
		}

		public static byte[] UrlDecodeToBytes(string s)
		{
			return null;
		}

		public static byte[] UrlDecodeToBytes(byte[] bytes, int offset, int count)
		{
			return null;
		}

		public static string UrlEncode(byte[] bytes)
		{
			return null;
		}

		public static string UrlEncode(string s)
		{
			return null;
		}

		public static string UrlEncode(string s, Encoding encoding)
		{
			return null;
		}

		public static string UrlEncode(byte[] bytes, int offset, int count)
		{
			return null;
		}

		public static byte[] UrlEncodeToBytes(byte[] bytes)
		{
			return null;
		}

		public static byte[] UrlEncodeToBytes(string s)
		{
			return null;
		}

		public static byte[] UrlEncodeToBytes(string s, Encoding encoding)
		{
			return null;
		}

		public static byte[] UrlEncodeToBytes(byte[] bytes, int offset, int count)
		{
			return null;
		}
	}
}
