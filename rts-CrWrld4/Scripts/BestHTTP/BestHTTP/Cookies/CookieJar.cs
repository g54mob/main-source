using System;
using System.Collections.Generic;
using System.Threading;

namespace BestHTTP.Cookies
{
	public static class CookieJar
	{
		private const int Version = 1;

		public static TimeSpan AccessThreshold;

		private static List<Cookie> Cookies;

		private static ReaderWriterLockSlim rwLock;

		private static bool _isSavingSupported;

		private static bool IsSupportCheckDone;

		private static bool Loaded;

		public static bool IsSavingSupported => false;

		private static string CookieFolder { get; set; }

		private static string LibraryPath { get; set; }

		internal static void SetupFolder()
		{
		}

		internal static bool Set(HTTPResponse response)
		{
			return false;
		}

		internal static void Maintain(bool sendEvent)
		{
		}

		internal static void Persist()
		{
		}

		internal static void Load()
		{
		}

		public static List<Cookie> Get(Uri uri)
		{
			return null;
		}

		public static void Set(Uri uri, Cookie cookie)
		{
		}

		public static void Set(Cookie cookie)
		{
		}

		public static List<Cookie> GetAll()
		{
			return null;
		}

		public static void Clear()
		{
		}

		public static void Clear(TimeSpan olderThan)
		{
		}

		public static void Clear(string domain)
		{
		}

		public static void Remove(Uri uri, string name)
		{
		}

		private static Cookie Find(Cookie cookie, out int idx)
		{
			idx = default(int);
			return null;
		}
	}
}
