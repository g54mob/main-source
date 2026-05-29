using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;

namespace ExitGames.Client.Photon
{
	public class SupportClass
	{
		[Obsolete("Use a Stopwatch (or equivalent) instead.")]
		public delegate int IntegerMillisecondsDelegate();

		public class ThreadSafeRandom
		{
			private static readonly Random _r;

			public static int Next()
			{
				return 0;
			}
		}

		private static List<Thread> threadList;

		private static readonly object ThreadListLock;

		[Obsolete("Use a Stopwatch (or equivalent) instead.")]
		protected internal static IntegerMillisecondsDelegate IntegerMilliseconds;

		private static uint[] crcLookupTable;

		public static List<MethodInfo> GetMethods(Type type, Type attribute)
		{
			return null;
		}

		[Obsolete("Use a Stopwatch (or equivalent) instead.")]
		public static int GetTickCount()
		{
			return 0;
		}

		public static byte StartBackgroundCalls(Func<bool> myThread, int millisecondsInterval = 100, string taskName = "")
		{
			return 0;
		}

		public static bool StopBackgroundCalls(byte id)
		{
			return false;
		}

		public static bool StopAllBackgroundCalls()
		{
			return false;
		}

		public static void WriteStackTrace(Exception throwable, TextWriter stream)
		{
		}

		public static void WriteStackTrace(Exception throwable)
		{
		}

		public static string DictionaryToString(IDictionary dictionary, bool includeTypes = true)
		{
			return null;
		}

		public static string DictionaryToString(NonAllocDictionary<byte, object> dictionary, bool includeTypes = true)
		{
			return null;
		}

		[Obsolete("Use DictionaryToString() instead.")]
		public static string HashtableToString(Hashtable hash)
		{
			return null;
		}

		public static string ByteArrayToString(byte[] list, int length = -1)
		{
			return null;
		}

		private static uint[] InitializeTable(uint polynomial)
		{
			return null;
		}

		public static uint CalculateCrc(byte[] buffer, int length)
		{
			return 0u;
		}
	}
}
