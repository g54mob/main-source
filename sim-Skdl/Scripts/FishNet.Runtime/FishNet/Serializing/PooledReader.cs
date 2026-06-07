using System;
using FishNet.Managing;

namespace FishNet.Serializing
{
	public sealed class PooledReader : Reader, IDisposable
	{
		internal PooledReader(byte[] bytes, NetworkManager networkManager, DataSource source = DataSource.Unset)
			: base(null, null)
		{
		}

		internal PooledReader(ArraySegment<byte> segment, NetworkManager networkManager, DataSource source = DataSource.Unset)
			: base(null, null)
		{
		}

		public void Store()
		{
		}

		[Obsolete("Use Store().")]
		public void Dispose()
		{
		}
	}
}
