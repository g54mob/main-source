using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Managing;

namespace FishNet.Serializing
{
	public static class WriterPool
	{
		private static readonly Stack<PooledWriter> _pool;

		private static readonly Dictionary<int, Stack<PooledWriter>> _lengthPool;

		internal const int LENGTH_BRACKET = 1000;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use Retrieve(NetworkManager).")]
		public static PooledWriter GetWriter(NetworkManager networkManager)
		{
			return null;
		}

		public static PooledWriter Retrieve(NetworkManager networkManager)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use Retrieve().")]
		public static PooledWriter GetWriter()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PooledWriter Retrieve()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use Retrieve(int).")]
		public static PooledWriter GetWriter(int length)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PooledWriter Retrieve(int length)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use Retrieve(NetworkManager, int).")]
		public static PooledWriter GetWriter(NetworkManager networkManager, int length)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PooledWriter Retrieve(NetworkManager networkManager, int length)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use StoreLength(PooledWriter).")]
		public static void RecycleLength(PooledWriter writer)
		{
		}

		public static void StoreLength(PooledWriter writer)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use Store(PooledWriter).")]
		public static void Recycle(PooledWriter writer)
		{
		}

		public static void Store(PooledWriter writer)
		{
		}

		private static int GetDictionaryIndex(int length)
		{
			return 0;
		}

		private static int GetDictionaryIndex(PooledWriter writer)
		{
			return 0;
		}
	}
}
