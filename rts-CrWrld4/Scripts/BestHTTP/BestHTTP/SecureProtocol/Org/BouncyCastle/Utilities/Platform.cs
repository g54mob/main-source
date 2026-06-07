using System;
using System.Collections;
using System.Globalization;
using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities
{
	internal abstract class Platform
	{
		private static readonly CompareInfo InvariantCompareInfo;

		internal static readonly string NewLine;

		private static string GetNewLine()
		{
			return null;
		}

		internal static bool EqualsIgnoreCase(string a, string b)
		{
			return false;
		}

		internal static string GetEnvironmentVariable(string variable)
		{
			return null;
		}

		internal static Exception CreateNotImplementedException(string message)
		{
			return null;
		}

		internal static IList CreateArrayList()
		{
			return null;
		}

		internal static IList CreateArrayList(int capacity)
		{
			return null;
		}

		internal static IList CreateArrayList(ICollection collection)
		{
			return null;
		}

		internal static IList CreateArrayList(IEnumerable collection)
		{
			return null;
		}

		internal static IDictionary CreateHashtable()
		{
			return null;
		}

		internal static IDictionary CreateHashtable(int capacity)
		{
			return null;
		}

		internal static IDictionary CreateHashtable(IDictionary dictionary)
		{
			return null;
		}

		internal static string ToLowerInvariant(string s)
		{
			return null;
		}

		internal static string ToUpperInvariant(string s)
		{
			return null;
		}

		internal static void Dispose(Stream s)
		{
		}

		internal static void Dispose(TextWriter t)
		{
		}

		internal static int IndexOf(string source, string value)
		{
			return 0;
		}

		internal static int LastIndexOf(string source, string value)
		{
			return 0;
		}

		internal static bool StartsWith(string source, string prefix)
		{
			return false;
		}

		internal static bool EndsWith(string source, string suffix)
		{
			return false;
		}

		internal static string GetTypeName(object obj)
		{
			return null;
		}
	}
}
