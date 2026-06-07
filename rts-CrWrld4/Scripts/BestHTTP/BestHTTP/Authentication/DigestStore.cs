using System;
using System.Collections.Generic;
using System.Threading;

namespace BestHTTP.Authentication
{
	public static class DigestStore
	{
		private static Dictionary<string, Digest> Digests;

		private static ReaderWriterLockSlim rwLock;

		private static string[] SupportedAlgorithms;

		public static Digest Get(Uri uri)
		{
			return null;
		}

		public static Digest GetOrCreate(Uri uri)
		{
			return null;
		}

		public static void Remove(Uri uri)
		{
		}

		public static string FindBest(List<string> authHeaders)
		{
			return null;
		}
	}
}
