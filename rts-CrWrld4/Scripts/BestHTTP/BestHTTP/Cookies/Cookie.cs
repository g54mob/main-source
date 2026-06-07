using System;
using System.Collections.Generic;
using System.IO;
using BestHTTP.Extensions;
using BestHTTP.Logger;

namespace BestHTTP.Cookies
{
	public sealed class Cookie : IComparable<Cookie>, IEquatable<Cookie>
	{
		private const int Version = 1;

		public string Name { get; private set; }

		public string Value { get; private set; }

		public DateTime Date { get; internal set; }

		public DateTime LastAccess { get; set; }

		public DateTime Expires { get; private set; }

		public long MaxAge { get; private set; }

		public bool IsSession { get; private set; }

		public string Domain { get; private set; }

		public string Path { get; private set; }

		public bool IsSecure { get; private set; }

		public bool IsHttpOnly { get; private set; }

		public string SameSite { get; private set; }

		public Cookie(string name, string value)
		{
		}

		public Cookie(string name, string value, string path)
		{
		}

		public Cookie(string name, string value, string path, string domain)
		{
		}

		public Cookie(Uri uri, string name, string value, DateTime expires, bool isSession = true)
		{
		}

		public Cookie(Uri uri, string name, string value, long maxAge = -1L, bool isSession = true)
		{
		}

		internal Cookie()
		{
		}

		public bool WillExpireInTheFuture()
		{
			return false;
		}

		public uint GuessSize()
		{
			return 0u;
		}

		public static Cookie Parse(string header, Uri defaultDomain, LoggingContext context)
		{
			return null;
		}

		internal void SaveTo(BinaryWriter stream)
		{
		}

		internal void LoadFrom(BinaryReader stream)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Cookie cookie)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		private static string ReadValue(string str, ref int pos)
		{
			return null;
		}

		private static List<HeaderValue> ParseCookieHeader(string str)
		{
			return null;
		}

		public int CompareTo(Cookie other)
		{
			return 0;
		}
	}
}
