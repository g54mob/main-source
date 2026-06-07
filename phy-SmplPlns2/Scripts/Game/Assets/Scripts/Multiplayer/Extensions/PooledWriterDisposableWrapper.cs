using System;
using FishNet.Serializing;

namespace Assets.Scripts.Multiplayer.Extensions
{
	public struct PooledWriterDisposableWrapper : IDisposable
	{
		public PooledWriter Writer { get; }

		public PooledWriterDisposableWrapper(PooledWriter writer)
		{
			Writer = writer;
		}

		public static implicit operator PooledWriter(PooledWriterDisposableWrapper wrapper)
		{
			return wrapper.Writer;
		}

		public void Dispose()
		{
			Writer.Store();
		}

		public ArraySegment<byte> GetData()
		{
			return Writer.GetArraySegment();
		}
	}
}
