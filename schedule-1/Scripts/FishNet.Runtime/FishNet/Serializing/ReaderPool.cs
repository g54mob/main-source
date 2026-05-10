using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Managing;

namespace FishNet.Serializing
{
	public static class ReaderPool
	{
		private static readonly Stack<PooledReader> _pool;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use Retrieve(byte[], NetworkManager, DataSource)")]
		public static PooledReader GetReader(byte[] bytes, NetworkManager networkManager, Reader.DataSource source = Reader.DataSource.Unset)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PooledReader Retrieve(byte[] bytes, NetworkManager networkManager, Reader.DataSource source = Reader.DataSource.Unset)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use Retrieve(ArraySegment, NetworkManager, DataSource)")]
		public static PooledReader GetReader(ArraySegment<byte> segment, NetworkManager networkManager, Reader.DataSource source = Reader.DataSource.Unset)
		{
			return null;
		}

		public static PooledReader Retrieve(ArraySegment<byte> segment, NetworkManager networkManager, Reader.DataSource source = Reader.DataSource.Unset)
		{
			return null;
		}

		[Obsolete("Use Store(PooledReader)")]
		public static void Recycle(PooledReader reader)
		{
		}

		public static void Store(PooledReader reader)
		{
		}
	}
}
