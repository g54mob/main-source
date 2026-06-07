using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace BestHTTP.Caching
{
	public static class HTTPCacheService
	{
		private const int LibraryVersion = 3;

		private static bool isSupported;

		private static bool IsSupportCheckDone;

		private static Dictionary<Uri, HTTPCacheFileInfo> library;

		private static ReaderWriterLockSlim rwLock;

		private static Dictionary<ulong, HTTPCacheFileInfo> UsedIndexes;

		private static bool InClearThread;

		private static bool InMaintainenceThread;

		private static ulong NextNameIDX;

		public static bool IsSupported => false;

		internal static string CacheFolder { get; private set; }

		private static string LibraryPath { get; set; }

		public static bool IsDoingMaintainence => false;

		static HTTPCacheService()
		{
		}

		internal static void CheckSetup()
		{
		}

		internal static void SetupCacheFolder()
		{
		}

		internal static ulong GetNameIdx()
		{
			return 0uL;
		}

		public static bool HasEntity(Uri uri)
		{
			return false;
		}

		public static bool DeleteEntity(Uri uri, bool removeFromLibrary = true)
		{
			return false;
		}

		private static void DeleteEntityImpl(Uri uri, bool removeFromLibrary = true, bool useLocking = false)
		{
		}

		internal static bool IsCachedEntityExpiresInTheFuture(HTTPRequest request)
		{
			return false;
		}

		internal static void SetHeaders(HTTPRequest request)
		{
		}

		public static HTTPCacheFileInfo GetEntity(Uri uri)
		{
			return null;
		}

		internal static HTTPResponse GetFullResponse(HTTPRequest request)
		{
			return null;
		}

		internal static bool IsCacheble(Uri uri, HTTPMethods method, HTTPResponse response)
		{
			return false;
		}

		internal static HTTPCacheFileInfo Store(Uri uri, HTTPMethods method, HTTPResponse response)
		{
			return null;
		}

		internal static void SetUpCachingValues(Uri uri, HTTPResponse response)
		{
		}

		internal static Stream PrepareStreamed(Uri uri, HTTPResponse response)
		{
			return null;
		}

		public static void BeginClear()
		{
		}

		private static void ClearImpl()
		{
		}

		public static void BeginMaintainence(HTTPCacheMaintananceParams maintananceParam)
		{
		}

		private static void MaintananceImpl(HTTPCacheMaintananceParams maintananceParam)
		{
		}

		public static int GetCacheEntityCount()
		{
			return 0;
		}

		public static ulong GetCacheSize()
		{
			return 0uL;
		}

		private static ulong GetCacheSizeImpl()
		{
			return 0uL;
		}

		private static void LoadLibrary()
		{
		}

		internal static void SaveLibrary()
		{
		}

		internal static void SetBodyLength(Uri uri, int bodyLength)
		{
		}

		private static void DeleteUnusedFiles()
		{
		}
	}
}
