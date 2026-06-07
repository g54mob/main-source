using System;

namespace FishNet.Serializing
{
	public sealed class PooledWriter : Writer, IDisposable
	{
		public void Store()
		{
		}

		public void StoreLength()
		{
		}

		[Obsolete("Use Store().")]
		public void Dispose()
		{
		}

		[Obsolete("Use StoreLength().")]
		public void DisposeLength()
		{
		}
	}
}
