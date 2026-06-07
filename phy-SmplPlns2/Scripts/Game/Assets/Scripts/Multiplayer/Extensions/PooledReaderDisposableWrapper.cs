using System;
using FishNet.Serializing;

namespace Assets.Scripts.Multiplayer.Extensions
{
	public struct PooledReaderDisposableWrapper : IDisposable
	{
		public PooledReader Reader { get; }

		public PooledReaderDisposableWrapper(PooledReader reader)
		{
			Reader = reader;
		}

		public static implicit operator PooledReader(PooledReaderDisposableWrapper wrapper)
		{
			return wrapper.Reader;
		}

		public void Dispose()
		{
			Reader.Store();
		}
	}
}
