using System;
using FishNet.Object;
using FishNet.Serializing;

namespace Assets.Scripts.Multiplayer.Extensions
{
	public static class NetworkBehaviourExtensions
	{
		public static PooledReaderDisposableWrapper GetPooledReader(this NetworkBehaviour networkBehaviour, ArraySegment<byte> arraySegment)
		{
			return ReaderPool.Retrieve(arraySegment, networkBehaviour.NetworkManager).AsDisposable();
		}

		public static PooledWriterDisposableWrapper GetPooledWriter(this NetworkBehaviour networkBehaviour)
		{
			return WriterPool.Retrieve().AsDisposable();
		}

		public static PooledWriterDisposableWrapper GetPooledWriter(this NetworkBehaviour networkBehaviour, int length)
		{
			return WriterPool.Retrieve(length).AsDisposable();
		}
	}
}
